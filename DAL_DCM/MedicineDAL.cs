using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class MedicineDAL
    {
        private readonly DbConnection _db = new();

        public List<MedicineDTO> GetAll()
        {
            var list = new List<MedicineDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Medicine WHERE IsDeleted = 0 ORDER BY MedicineName";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new MedicineDTO
                {
                    MedicineID = Convert.ToInt32(reader["MedicineID"]),
                    MedicineName = reader["MedicineName"].ToString()!,
                    Unit = reader["Unit"]?.ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                });
            }
            return list;
        }

        public bool Add(MedicineDTO med)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Medicine (MedicineName, Unit, UnitPrice, StockQuantity, IsDeleted)
                             VALUES (@Name, @Unit, @Price, @Stock, 0)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", med.MedicineName);
            cmd.Parameters.AddWithValue("@Unit", (object?)med.Unit ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", med.UnitPrice);
            cmd.Parameters.AddWithValue("@Stock", med.StockQuantity);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(MedicineDTO med)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"UPDATE Medicine SET MedicineName = @Name, Unit = @Unit,
                             UnitPrice = @Price, StockQuantity = @Stock WHERE MedicineID = @ID";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", med.MedicineID);
            cmd.Parameters.AddWithValue("@Name", med.MedicineName);
            cmd.Parameters.AddWithValue("@Unit", (object?)med.Unit ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", med.UnitPrice);
            cmd.Parameters.AddWithValue("@Stock", med.StockQuantity);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int medicineId)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = "UPDATE Medicine SET IsDeleted = 1 WHERE MedicineID = @ID";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", medicineId);

            return cmd.ExecuteNonQuery() > 0;
        }

        // --- Prescription & Details ---
        public PrescriptionDTO? GetPrescriptionByExamId(int examId)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Prescription WHERE ExaminationID = @ExamID LIMIT 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ExamID", examId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new PrescriptionDTO
                {
                    PrescriptionID = Convert.ToInt32(reader["PrescriptionID"]),
                    ExaminationID = Convert.ToInt32(reader["ExaminationID"]),
                    PrescriptionDate = Convert.ToDateTime(reader["PrescriptionDate"]),
                    Instructions = reader["Instructions"]?.ToString(),
                    PrescriptionStatus = reader["PrescriptionStatus"].ToString() ?? "Draft"
                };
            }
            return null;
        }

        public int CreatePrescription(PrescriptionDTO p)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Prescription (ExaminationID, PrescriptionDate, Instructions, PrescriptionStatus)
                             VALUES (@ExamID, @Date, @Instructions, @Status);
                             SELECT LAST_INSERT_ID();";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ExamID", p.ExaminationID);
            cmd.Parameters.AddWithValue("@Date", p.PrescriptionDate);
            cmd.Parameters.AddWithValue("@Instructions", (object?)p.Instructions ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", p.PrescriptionStatus);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public List<PrescriptionDetailDTO> GetDetails(int prescriptionId)
        {
            var list = new List<PrescriptionDetailDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT pd.*, m.MedicineName, m.Unit, m.UnitPrice
                FROM PrescriptionDetail pd
                INNER JOIN Medicine m ON pd.MedicineID = m.MedicineID
                WHERE pd.PrescriptionID = @PID AND pd.IsVoided = 0";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PID", prescriptionId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PrescriptionDetailDTO
                {
                    PrescriptionID = Convert.ToInt32(reader["PrescriptionID"]),
                    MedicineID = Convert.ToInt32(reader["MedicineID"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Dosage = reader["Dosage"]?.ToString(),
                    MedicineName = reader["MedicineName"].ToString(),
                    Unit = reader["Unit"]?.ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                });
            }
            return list;
        }

        public bool AddDetail(PrescriptionDetailDTO item)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // 1. Kiểm tra tồn kho trước khi kê
                string qCheck = "SELECT StockQuantity FROM Medicine WHERE MedicineID = @MID FOR UPDATE";
                using (var cmdC = new MySqlCommand(qCheck, conn, tran))
                {
                    cmdC.Parameters.AddWithValue("@MID", item.MedicineID);
                    int currentStock = Convert.ToInt32(cmdC.ExecuteScalar());
                    if (currentStock < item.Quantity)
                    {
                        throw new Exception($"Thuốc không đủ tồn kho! Hiện còn: {currentStock}, yêu cầu: {item.Quantity}");
                    }
                }

                // 2. Thêm vào chi tiết đơn thuốc
                string query = @"
                    INSERT INTO PrescriptionDetail (PrescriptionID, MedicineID, Quantity, Dosage, IsVoided)
                    VALUES (@PID, @MID, @Qty, @Dosage, 0)
                    ON DUPLICATE KEY UPDATE Quantity = Quantity + @Qty, Dosage = @Dosage;";

                using (var cmd = new MySqlCommand(query, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@PID", item.PrescriptionID);
                    cmd.Parameters.AddWithValue("@MID", item.MedicineID);
                    cmd.Parameters.AddWithValue("@Qty", item.Quantity);
                    cmd.Parameters.AddWithValue("@Dosage", (object?)item.Dosage ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                // 3. Tự động trừ tồn kho Medicine (Bán hàng / Xuất đơn -> giảm số lượng có)
                string qStock = "UPDATE Medicine SET StockQuantity = StockQuantity - @Qty WHERE MedicineID = @MID";
                using (var cmdS = new MySqlCommand(qStock, conn, tran))
                {
                    cmdS.Parameters.AddWithValue("@Qty", item.Quantity);
                    cmdS.Parameters.AddWithValue("@MID", item.MedicineID);
                    cmdS.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public bool DeleteDetail(int prescriptionId, int medicineId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // 1. Lấy số lượng đã kê để hoàn trả lại kho
                int qty = 0;
                string qGet = "SELECT Quantity FROM PrescriptionDetail WHERE PrescriptionID = @PID AND MedicineID = @MID";
                using (var cmdG = new MySqlCommand(qGet, conn, tran))
                {
                    cmdG.Parameters.AddWithValue("@PID", prescriptionId);
                    cmdG.Parameters.AddWithValue("@MID", medicineId);
                    object? res = cmdG.ExecuteScalar();
                    if (res != null) qty = Convert.ToInt32(res);
                }

                // 2. Xóa khỏi đơn thuốc
                string query = "DELETE FROM PrescriptionDetail WHERE PrescriptionID = @PID AND MedicineID = @MID";
                using (var cmd = new MySqlCommand(query, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@PID", prescriptionId);
                    cmd.Parameters.AddWithValue("@MID", medicineId);
                    cmd.ExecuteNonQuery();
                }

                // 3. Hoàn lại số lượng vào tồn kho
                if (qty > 0)
                {
                    string qRefund = "UPDATE Medicine SET StockQuantity = StockQuantity + @Qty WHERE MedicineID = @MID";
                    using (var cmdR = new MySqlCommand(qRefund, conn, tran))
                    {
                        cmdR.Parameters.AddWithValue("@Qty", qty);
                        cmdR.Parameters.AddWithValue("@MID", medicineId);
                        cmdR.ExecuteNonQuery();
                    }
                }

                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
}
