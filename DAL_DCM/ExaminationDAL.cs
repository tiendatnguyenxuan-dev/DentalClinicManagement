using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class ExaminationDAL
    {
        private readonly DbConnection _db = new();

        public List<ExaminationDTO> GetAllExaminations()
        {
            var list = new List<ExaminationDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT e.*, p.FullName AS PatientName, p.Phone AS PatientPhone, doc.FullName AS DoctorName
                FROM Examination e
                INNER JOIN Patient p ON e.PatientID = p.PatientID
                INNER JOIN Employee doc ON e.DoctorID = doc.EmployeeID
                ORDER BY e.ExaminationDate DESC";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ExaminationDTO
                {
                    ExaminationID = Convert.ToInt32(reader["ExaminationID"]),
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    DoctorID = Convert.ToInt32(reader["DoctorID"]),
                    AppointmentID = reader["AppointmentID"] != DBNull.Value ? Convert.ToInt32(reader["AppointmentID"]) : null,
                    ExaminationDate = Convert.ToDateTime(reader["ExaminationDate"]),
                    ExaminationReason = reader["ExaminationReason"]?.ToString(),
                    Diagnosis = reader["Diagnosis"]?.ToString(),
                    Conclusion = reader["Conclusion"]?.ToString(),
                    FollowUpDate = reader["FollowUpDate"] != DBNull.Value ? Convert.ToDateTime(reader["FollowUpDate"]) : null,
                    ExaminationStatus = reader["ExaminationStatus"].ToString() ?? "Draft",
                    PatientName = reader["PatientName"]?.ToString(),
                    PatientPhone = reader["PatientPhone"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString()
                });
            }
            return list;
        }

        public int InsertExamination(ExaminationDTO exam)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                INSERT INTO Examination (PatientID, DoctorID, AppointmentID, ExaminationDate, ExaminationReason, Diagnosis, Conclusion, FollowUpDate, ExaminationStatus)
                VALUES (@PatientID, @DoctorID, @AppointmentID, @ExaminationDate, @ExaminationReason, @Diagnosis, @Conclusion, @FollowUpDate, @ExaminationStatus);
                SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PatientID", exam.PatientID);
            cmd.Parameters.AddWithValue("@DoctorID", exam.DoctorID);
            cmd.Parameters.AddWithValue("@AppointmentID", (object?)exam.AppointmentID ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ExaminationDate", exam.ExaminationDate);
            cmd.Parameters.AddWithValue("@ExaminationReason", (object?)exam.ExaminationReason ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Diagnosis", (object?)exam.Diagnosis ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Conclusion", (object?)exam.Conclusion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FollowUpDate", (object?)exam.FollowUpDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ExaminationStatus", exam.ExaminationStatus);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool UpdateExamination(ExaminationDTO exam)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                UPDATE Examination
                SET PatientID = @PatientID, DoctorID = @DoctorID, ExaminationReason = @ExaminationReason,
                    Diagnosis = @Diagnosis, Conclusion = @Conclusion, FollowUpDate = @FollowUpDate,
                    ExaminationStatus = @ExaminationStatus
                WHERE ExaminationID = @ExaminationID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ExaminationID", exam.ExaminationID);
            cmd.Parameters.AddWithValue("@PatientID", exam.PatientID);
            cmd.Parameters.AddWithValue("@DoctorID", exam.DoctorID);
            cmd.Parameters.AddWithValue("@ExaminationReason", (object?)exam.ExaminationReason ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Diagnosis", (object?)exam.Diagnosis ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Conclusion", (object?)exam.Conclusion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FollowUpDate", (object?)exam.FollowUpDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ExaminationStatus", exam.ExaminationStatus);

            return cmd.ExecuteNonQuery() > 0;
        }

        public List<ExaminationServiceDTO> GetServicesByExamId(int examId)
        {
            var list = new List<ExaminationServiceDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT es.*, s.ServiceName
                FROM ExaminationService es
                INNER JOIN Service s ON es.ServiceID = s.ServiceID
                WHERE es.ExaminationID = @ExaminationID AND es.IsVoided = 0";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ExaminationID", examId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ExaminationServiceDTO
                {
                    ExaminationServiceID = Convert.ToInt32(reader["ExaminationServiceID"]),
                    ExaminationID = Convert.ToInt32(reader["ExaminationID"]),
                    ServiceID = Convert.ToInt32(reader["ServiceID"]),
                    ToothNumber = reader["ToothNumber"]?.ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    Notes = reader["Notes"]?.ToString(),
                    ServiceName = reader["ServiceName"]?.ToString()
                });
            }
            return list;
        }

        public bool AddExaminationService(ExaminationServiceDTO item)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                INSERT INTO ExaminationService (ExaminationID, ServiceID, ToothNumber, Quantity, UnitPrice, Notes)
                VALUES (@ExaminationID, @ServiceID, @ToothNumber, @Quantity, @UnitPrice, @Notes)";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ExaminationID", item.ExaminationID);
            cmd.Parameters.AddWithValue("@ServiceID", item.ServiceID);
            cmd.Parameters.AddWithValue("@ToothNumber", (object?)item.ToothNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
            cmd.Parameters.AddWithValue("@Notes", (object?)item.Notes ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeleteExaminationService(int examServiceId)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = "DELETE FROM ExaminationService WHERE ExaminationServiceID = @ID";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", examServiceId);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
