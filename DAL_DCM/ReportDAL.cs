using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class ReportDAL
    {
        private readonly DbConnection _db = new();

        public List<RevenueReportDTO> GetRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            var list = new List<RevenueReportDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT 
                    DATE(InvoiceDate) AS InvDay,
                    COUNT(InvoiceID) AS TotalInvoices,
                    IFNULL(SUM(TotalAmountService), 0) AS ServiceRev,
                    IFNULL(SUM(TotalAmountMedicine), 0) AS MedRev,
                    IFNULL(SUM(DiscountAmount), 0) AS DiscountRev
                FROM Invoice
                WHERE InvoiceStatus = 'Issued'
                  AND DATE(InvoiceDate) >= @FromDate
                  AND DATE(InvoiceDate) <= @ToDate
                GROUP BY DATE(InvoiceDate)
                ORDER BY InvDay DESC";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
            cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new RevenueReportDTO
                {
                    TimeLabel = Convert.ToDateTime(reader["InvDay"]).ToString("dd/MM/yyyy"),
                    InvoiceCount = Convert.ToInt32(reader["TotalInvoices"]),
                    TotalServiceRevenue = Convert.ToDecimal(reader["ServiceRev"]),
                    TotalMedicineRevenue = Convert.ToDecimal(reader["MedRev"]),
                    TotalDiscount = Convert.ToDecimal(reader["DiscountRev"])
                });
            }
            return list;
        }

        public List<QuarterRevenueDTO> GetRevenueByDoctorAndQuarter(int year)
        {
            var list = new List<QuarterRevenueDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT 
                    doc.FullName AS DoctorName,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 1 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q1,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 2 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q2,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 3 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q3,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 4 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q4
                FROM Employee doc
                LEFT JOIN Examination ex ON doc.EmployeeID = ex.DoctorID
                LEFT JOIN Invoice i ON ex.ExaminationID = i.ExaminationID AND YEAR(i.InvoiceDate) = @Year AND i.InvoiceStatus = 'Issued'
                WHERE doc.Position IN ('Doctor', 'Admin')
                GROUP BY doc.EmployeeID, doc.FullName
                ORDER BY DoctorName";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Year", year);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new QuarterRevenueDTO
                {
                    EntityName = reader["DoctorName"].ToString()!,
                    Q1 = Convert.ToDecimal(reader["Q1"]),
                    Q2 = Convert.ToDecimal(reader["Q2"]),
                    Q3 = Convert.ToDecimal(reader["Q3"]),
                    Q4 = Convert.ToDecimal(reader["Q4"])
                });
            }
            return list;
        }

        public List<QuarterRevenueDTO> GetRevenueByPatientAndQuarter(int year)
        {
            var list = new List<QuarterRevenueDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT 
                    p.FullName AS PatientName,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 1 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q1,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 2 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q2,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 3 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q3,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 4 THEN (i.TotalAmountService + i.TotalAmountMedicine - i.DiscountAmount) ELSE 0 END), 0) AS Q4
                FROM Patient p
                INNER JOIN Examination ex ON p.PatientID = ex.PatientID
                INNER JOIN Invoice i ON ex.ExaminationID = i.ExaminationID AND YEAR(i.InvoiceDate) = @Year AND i.InvoiceStatus = 'Issued'
                GROUP BY p.PatientID, p.FullName
                ORDER BY PatientName";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Year", year);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new QuarterRevenueDTO
                {
                    EntityName = reader["PatientName"].ToString()!,
                    Q1 = Convert.ToDecimal(reader["Q1"]),
                    Q2 = Convert.ToDecimal(reader["Q2"]),
                    Q3 = Convert.ToDecimal(reader["Q3"]),
                    Q4 = Convert.ToDecimal(reader["Q4"])
                });
            }
            return list;
        }

        public List<QuarterRevenueDTO> GetRevenueByMedicineAndQuarter(int year)
        {
            var list = new List<QuarterRevenueDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT 
                    m.MedicineName,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 1 THEN (pd.Quantity * m.UnitPrice) ELSE 0 END), 0) AS Q1,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 2 THEN (pd.Quantity * m.UnitPrice) ELSE 0 END), 0) AS Q2,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 3 THEN (pd.Quantity * m.UnitPrice) ELSE 0 END), 0) AS Q3,
                    IFNULL(SUM(CASE WHEN QUARTER(i.InvoiceDate) = 4 THEN (pd.Quantity * m.UnitPrice) ELSE 0 END), 0) AS Q4
                FROM Medicine m
                INNER JOIN PrescriptionDetail pd ON m.MedicineID = pd.MedicineID AND pd.IsVoided = 0
                INNER JOIN Invoice i ON pd.InvoiceID = i.InvoiceID AND YEAR(i.InvoiceDate) = @Year AND i.InvoiceStatus = 'Issued'
                GROUP BY m.MedicineID, m.MedicineName
                ORDER BY m.MedicineName";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Year", year);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new QuarterRevenueDTO
                {
                    EntityName = reader["MedicineName"].ToString()!,
                    Q1 = Convert.ToDecimal(reader["Q1"]),
                    Q2 = Convert.ToDecimal(reader["Q2"]),
                    Q3 = Convert.ToDecimal(reader["Q3"]),
                    Q4 = Convert.ToDecimal(reader["Q4"])
                });
            }
            return list;
        }

        public (decimal TotalRevenue, int TotalExams, int TotalPatients, int TotalAppointments) GetDashboardSummary()
        {
            using var conn = _db.GetConnection();
            conn.Open();

            decimal totalRev = 0;
            int totalExams = 0;
            int totalPatients = 0;
            int totalAppointments = 0;

            string qRev = "SELECT IFNULL(SUM(Amount), 0) FROM Payment WHERE PaymentStatus = 'Completed'";
            using (var cmd = new MySqlCommand(qRev, conn))
            {
                totalRev = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            string qExam = "SELECT COUNT(*) FROM Examination";
            using (var cmd = new MySqlCommand(qExam, conn))
            {
                totalExams = Convert.ToInt32(cmd.ExecuteScalar());
            }

            string qPat = "SELECT COUNT(*) FROM Patient WHERE PatientStatus = 'Active'";
            using (var cmd = new MySqlCommand(qPat, conn))
            {
                totalPatients = Convert.ToInt32(cmd.ExecuteScalar());
            }

            string qApp = "SELECT COUNT(*) FROM Appointment";
            using (var cmd = new MySqlCommand(qApp, conn))
            {
                totalAppointments = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return (totalRev, totalExams, totalPatients, totalAppointments);
        }
    }
}
