using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class PatientDAL
    {
        private readonly DbConnection _db = new();

        // 1. Thêm mới bệnh nhân
        public bool Add(PatientDTO patient)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO Patient
                    (FullName, DateOfBirth, Gender, Phone, Email, Address, MedicalHistory, Allergies, IsDeleted)
                    VALUES
                    (@FullName, @DateOfBirth, @Gender, @Phone, @Email, @Address, @MedicalHistory, @Allergies, 0);";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", patient.FullName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object?)patient.DateOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", (object?)patient.Gender ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object?)patient.Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object?)patient.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object?)patient.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MedicalHistory", (object?)patient.MedicalHistory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Allergies", (object?)patient.Allergies ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 2. Lấy tất cả bệnh nhân chưa bị xóa mềm
        public List<PatientDTO> GetAll()
        {
            List<PatientDTO> list = new();
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT * FROM Patient
                    WHERE IsDeleted = 0
                    ORDER BY PatientID DESC;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapReaderToPatient(reader));
                    }
                }
            }
            return list;
        }

        // 3. Lấy thông tin bệnh nhân theo ID
        public PatientDTO? GetById(int patientId)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT * FROM Patient
                    WHERE PatientID = @PatientID AND IsDeleted = 0
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToPatient(reader);
                        }
                    }
                }
            }
            return null;
        }

        // 4. Cập nhật thông tin bệnh nhân
        public bool Update(PatientDTO patient)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Patient
                    SET FullName = @FullName,
                        DateOfBirth = @DateOfBirth,
                        Gender = @Gender,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address,
                        MedicalHistory = @MedicalHistory,
                        Allergies = @Allergies
                    WHERE PatientID = @PatientID AND IsDeleted = 0;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
                    cmd.Parameters.AddWithValue("@FullName", patient.FullName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object?)patient.DateOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", (object?)patient.Gender ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object?)patient.Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object?)patient.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object?)patient.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MedicalHistory", (object?)patient.MedicalHistory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Allergies", (object?)patient.Allergies ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 5. XÓA MỀM BỆNH NHÂN (Cập nhật IsDeleted = 1)
        public bool Delete(int patientId)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE Patient
                    SET IsDeleted = 1
                    WHERE PatientID = @PatientID;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 6. Tìm kiếm bệnh nhân (chỉ lấy bệnh nhân đang hoạt động)
        public List<PatientDTO> Search(string keyword)
        {
            List<PatientDTO> list = new();
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT * FROM Patient
                    WHERE IsDeleted = 0 
                      AND (CAST(PatientID AS CHAR) LIKE @Keyword
                           OR FullName LIKE @Keyword
                           OR Phone LIKE @Keyword
                           OR Email LIKE @Keyword)
                    ORDER BY PatientID DESC;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword.Trim()}%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToPatient(reader));
                        }
                    }
                }
            }
            return list;
        }

        private static PatientDTO MapReaderToPatient(MySqlDataReader reader)
        {
            return new PatientDTO
            {
                PatientID = Convert.ToInt32(reader["PatientID"]),
                FullName = reader["FullName"].ToString() ?? string.Empty,
                DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : Convert.ToDateTime(reader["DateOfBirth"]),
                Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString(),
                Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString(),
                MedicalHistory = reader["MedicalHistory"] == DBNull.Value ? null : reader["MedicalHistory"].ToString(),
                Allergies = reader["Allergies"] == DBNull.Value ? null : reader["Allergies"].ToString(),
                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]),
                IsDeleted = reader["IsDeleted"] != DBNull.Value && Convert.ToBoolean(reader["IsDeleted"])
            };
        }
    }
}