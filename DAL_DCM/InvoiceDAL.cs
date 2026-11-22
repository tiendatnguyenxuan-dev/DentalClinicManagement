using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class InvoiceDAL
    {
        private readonly DbConnection _db = new();

        public List<InvoiceDTO> GetAll()
        {
            var list = new List<InvoiceDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT i.*, p.FullName AS PatientName, doc.FullName AS DoctorName, cash.FullName AS CashierName
                FROM Invoice i
                INNER JOIN Examination ex ON i.ExaminationID = ex.ExaminationID
                INNER JOIN Patient p ON ex.PatientID = p.PatientID
                INNER JOIN Employee doc ON ex.DoctorID = doc.EmployeeID
                INNER JOIN Employee cash ON i.EmployeeID = cash.EmployeeID
                ORDER BY i.InvoiceDate DESC";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new InvoiceDTO
                {
                    InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                    ExaminationID = Convert.ToInt32(reader["ExaminationID"]),
                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                    InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                    TotalAmountMedicine = Convert.ToDecimal(reader["TotalAmountMedicine"]),
                    TotalAmountService = Convert.ToDecimal(reader["TotalAmountService"]),
                    DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]),
                    PaymentStatus = reader["PaymentStatus"].ToString() ?? "Unpaid",
                    InvoiceStatus = reader["InvoiceStatus"].ToString() ?? "Issued",
                    CancelReason = reader["CancelReason"]?.ToString(),
                    PatientName = reader["PatientName"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    CashierName = reader["CashierName"]?.ToString()
                });
            }
            return list;
        }

        public int CreateInvoiceFromExam(int examId, int employeeId, decimal discount)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            // Tính tiền dịch vụ từ ExaminationService
            decimal totalService = 0;
            string qService = @"SELECT IFNULL(SUM(Quantity * UnitPrice), 0) FROM ExaminationService WHERE ExaminationID = @EID AND IsVoided = 0";
            using (var cmdS = new MySqlCommand(qService, conn))
            {
                cmdS.Parameters.AddWithValue("@EID", examId);
                totalService = Convert.ToDecimal(cmdS.ExecuteScalar());
            }

            // Tính tiền thuốc từ PrescriptionDetail
            decimal totalMedicine = 0;
            string qMed = @"SELECT IFNULL(SUM(pd.Quantity * m.UnitPrice), 0)
                            FROM PrescriptionDetail pd
                            INNER JOIN Medicine m ON pd.MedicineID = m.MedicineID
                            INNER JOIN Prescription p ON pd.PrescriptionID = p.PrescriptionID
                            WHERE p.ExaminationID = @EID AND pd.IsVoided = 0";
            using (var cmdM = new MySqlCommand(qMed, conn))
            {
                cmdM.Parameters.AddWithValue("@EID", examId);
                totalMedicine = Convert.ToDecimal(cmdM.ExecuteScalar());
            }

            string qInsert = @"
                INSERT INTO Invoice (ExaminationID, EmployeeID, InvoiceDate, TotalAmountMedicine, TotalAmountService, DiscountAmount, PaymentStatus, InvoiceStatus)
                VALUES (@EID, @EmpID, NOW(), @TotalMed, @TotalServ, @Discount, 'Unpaid', 'Issued')
                ON DUPLICATE KEY UPDATE 
                    EmployeeID = @EmpID, TotalAmountMedicine = @TotalMed, TotalAmountService = @TotalServ, DiscountAmount = @Discount;
                SELECT InvoiceID FROM Invoice WHERE ExaminationID = @EID LIMIT 1;";

            int invoiceId = 0;
            using (var cmdI = new MySqlCommand(qInsert, conn))
            {
                cmdI.Parameters.AddWithValue("@EID", examId);
                cmdI.Parameters.AddWithValue("@EmpID", employeeId);
                cmdI.Parameters.AddWithValue("@TotalMed", totalMedicine);
                cmdI.Parameters.AddWithValue("@TotalServ", totalService);
                cmdI.Parameters.AddWithValue("@Discount", discount);
                invoiceId = Convert.ToInt32(cmdI.ExecuteScalar());
            }

            // Đồng bộ chi tiết dịch vụ vào bảng InvoiceServiceDetail
            string qSyncServDetail = @"
                DELETE FROM InvoiceServiceDetail WHERE InvoiceID = @IID;
                INSERT INTO InvoiceServiceDetail (InvoiceID, ServiceID, Quantity, UnitPrice)
                SELECT @IID, ServiceID, Quantity, UnitPrice 
                FROM ExaminationService 
                WHERE ExaminationID = @EID AND IsVoided = 0;";
            using (var cmdSync = new MySqlCommand(qSyncServDetail, conn))
            {
                cmdSync.Parameters.AddWithValue("@IID", invoiceId);
                cmdSync.Parameters.AddWithValue("@EID", examId);
                cmdSync.ExecuteNonQuery();
            }

            // Gán InvoiceID vào PrescriptionDetail
            string qSyncPresDetail = @"
                UPDATE PrescriptionDetail pd
                INNER JOIN Prescription p ON pd.PrescriptionID = p.PrescriptionID
                SET pd.InvoiceID = @IID
                WHERE p.ExaminationID = @EID;";
            using (var cmdSyncP = new MySqlCommand(qSyncPresDetail, conn))
            {
                cmdSyncP.Parameters.AddWithValue("@IID", invoiceId);
                cmdSyncP.Parameters.AddWithValue("@EID", examId);
                cmdSyncP.ExecuteNonQuery();
            }

            return invoiceId;
        }

        public bool AddPayment(PaymentDTO payment)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string qPay = @"
                INSERT INTO Payment (InvoiceID, PaymentDate, Amount, PaymentMethod, PaymentStatus, ReversedBy)
                VALUES (@IID, NOW(), @Amount, @Method, 'Completed', @RecordedBy)";

            using (var cmd = new MySqlCommand(qPay, conn))
            {
                cmd.Parameters.AddWithValue("@IID", payment.InvoiceID);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@Method", payment.PaymentMethod);
                cmd.Parameters.AddWithValue("@RecordedBy", (object?)payment.ReversedBy ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            // Cập nhật trạng thái Invoice
            string qUpdate = @"
                UPDATE Invoice
                SET PaymentStatus = 'Paid'
                WHERE InvoiceID = @IID";
            using (var cmdU = new MySqlCommand(qUpdate, conn))
            {
                cmdU.Parameters.AddWithValue("@IID", payment.InvoiceID);
                cmdU.ExecuteNonQuery();
            }

            return true;
        }

        public List<PaymentDTO> GetPaymentsByInvoice(int invoiceId)
        {
            var list = new List<PaymentDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string q = "SELECT * FROM Payment WHERE InvoiceID = @IID";
            using var cmd = new MySqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@IID", invoiceId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new PaymentDTO
                {
                    PaymentID = Convert.ToInt32(r["PaymentID"]),
                    InvoiceID = Convert.ToInt32(r["InvoiceID"]),
                    PaymentDate = Convert.ToDateTime(r["PaymentDate"]),
                    Amount = Convert.ToDecimal(r["Amount"]),
                    PaymentMethod = r["PaymentMethod"].ToString() ?? "Cash",
                    PaymentStatus = r["PaymentStatus"].ToString() ?? "Completed",
                    ReversedBy = r["ReversedBy"] != DBNull.Value ? Convert.ToInt32(r["ReversedBy"]) : null
                });
            }
            return list;
        }
    }
}
