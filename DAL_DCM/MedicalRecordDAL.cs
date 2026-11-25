using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class MedicalRecordDAL
    {
        private readonly DbConnection _db = new();

        /// <summary>
        /// Lấy hồ sơ bệnh án theo PatientID (chưa bị xóa)
        /// </summary>
        public MedicalRecordDTO? GetByPatientId(int patientId)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT mr.*, p.FullName AS PatientName, p.Phone, p.Gender, p.DateOfBirth, 
                       p.Address, p.MedicalHistory, p.Allergies
                FROM MedicalRecord mr
                INNER JOIN Patient p ON mr.PatientID = p.PatientID
                WHERE mr.PatientID = @PatientID AND mr.IsDeleted = FALSE
                LIMIT 1;";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PatientID", patientId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapReaderToDTO(reader);
            }
            return null;
        }

        /// <summary>
        /// Tạo hoặc lấy hồ sơ bệnh án cho bệnh nhân.
        /// Đảm bảo mỗi bệnh nhân có 1 MedicalRecord duy nhất.
        /// </summary>
        public MedicalRecordDTO EnsureMedicalRecordExists(int patientId)
        {
            var existing = GetByPatientId(patientId);
            if (existing != null) return existing;

            using var conn = _db.GetConnection();
            conn.Open();

            // Sinh mã hồ sơ: HSBA + PatientID định dạng 5 chữ số
            string recordCode = $"HSBA{patientId:D5}";

            string insertQuery = @"
                INSERT INTO MedicalRecord (PatientID, RecordCode, CreatedDate, RecordStatus, IsDeleted)
                VALUES (@PatientID, @RecordCode, CURRENT_DATE(), 'Active', FALSE)
                ON DUPLICATE KEY UPDATE RecordStatus = 'Active', IsDeleted = FALSE;
                SELECT MedicalRecordID FROM MedicalRecord WHERE PatientID = @PatientID LIMIT 1;";

            using var cmd = new MySqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.Parameters.AddWithValue("@RecordCode", recordCode);

            cmd.ExecuteScalar();

            return GetByPatientId(patientId)!;
        }

        /// <summary>
        /// Lấy danh sách tất cả các lần khám bệnh của bệnh nhân
        /// </summary>
        public List<ExaminationDTO> GetExaminationsByPatientId(int patientId)
        {
            var list = new List<ExaminationDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT e.*, p.FullName AS PatientName, p.Phone AS PatientPhone, doc.FullName AS DoctorName
                FROM Examination e
                INNER JOIN Patient p ON e.PatientID = p.PatientID
                INNER JOIN Employee doc ON e.DoctorID = doc.EmployeeID
                WHERE e.PatientID = @PatientID
                ORDER BY e.ExaminationDate DESC;";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PatientID", patientId);

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
                    ExaminationStatus = reader["ExaminationStatus"]?.ToString() ?? "Draft",
                    PatientName = reader["PatientName"]?.ToString(),
                    PatientPhone = reader["PatientPhone"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString()
                });
            }
            return list;
        }

        private static MedicalRecordDTO MapReaderToDTO(MySqlDataReader reader)
        {
            return new MedicalRecordDTO
            {
                MedicalRecordID = Convert.ToInt32(reader["MedicalRecordID"]),
                PatientID = Convert.ToInt32(reader["PatientID"]),
                RecordCode = reader["RecordCode"].ToString() ?? string.Empty,
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                RecordStatus = reader["RecordStatus"].ToString() ?? "Active",
                IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
                DeletedAt = reader["DeletedAt"] != DBNull.Value ? Convert.ToDateTime(reader["DeletedAt"]) : null,
                PatientName = reader["PatientName"]?.ToString(),
                Phone = reader["Phone"]?.ToString(),
                Gender = reader["Gender"]?.ToString(),
                DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : null,
                Address = reader["Address"]?.ToString(),
                MedicalHistory = reader["MedicalHistory"]?.ToString(),
                Allergies = reader["Allergies"]?.ToString()
            };
        }
    }
}
