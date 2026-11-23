using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class EmployeeDAL
    {
        private readonly DbConnection _db = new();

        public List<EmployeeDTO> GetAll()
        {
            var list = new List<EmployeeDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT e.*, s.SpecialtyName
                FROM Employee e
                LEFT JOIN Specialty s ON e.SpecialtyID = s.SpecialtyID
                ORDER BY e.EmployeeID";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new EmployeeDTO
                {
                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                    FullName = reader["FullName"].ToString()!,
                    Position = reader["Position"].ToString() ?? "Doctor",
                    Phone = reader["Phone"]?.ToString(),
                    Email = reader["Email"]?.ToString(),
                    HireDate = reader["HireDate"] != DBNull.Value ? Convert.ToDateTime(reader["HireDate"]) : null,
                    SpecialtyID = reader["SpecialtyID"] != DBNull.Value ? Convert.ToInt32(reader["SpecialtyID"]) : null,
                    SpecialtyName = reader["SpecialtyName"]?.ToString(),
                    PracticeLicenseNumber = reader["PracticeLicenseNumber"]?.ToString(),
                    EmploymentStatus = reader["EmploymentStatus"].ToString() ?? "Active"
                });
            }
            return list;
        }

        public bool Add(EmployeeDTO emp)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                INSERT INTO Employee (FullName, Position, Phone, Email, HireDate, SpecialtyID, PracticeLicenseNumber, EmploymentStatus)
                VALUES (@FullName, @Position, @Phone, @Email, @HireDate, @SpecialtyID, @License, @Status)";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FullName", emp.FullName);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@Phone", (object?)emp.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)emp.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@HireDate", (object?)emp.HireDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SpecialtyID", (object?)emp.SpecialtyID ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@License", (object?)emp.PracticeLicenseNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", emp.EmploymentStatus);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(EmployeeDTO emp)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                UPDATE Employee
                SET FullName = @FullName, Position = @Position, Phone = @Phone, Email = @Email,
                    SpecialtyID = @SpecialtyID, PracticeLicenseNumber = @License, EmploymentStatus = @Status
                WHERE EmployeeID = @EmployeeID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmd.Parameters.AddWithValue("@FullName", emp.FullName);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@Phone", (object?)emp.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)emp.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@SpecialtyID", (object?)emp.SpecialtyID ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@License", (object?)emp.PracticeLicenseNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", emp.EmploymentStatus);

            return cmd.ExecuteNonQuery() > 0;
        }

        public List<SpecialtyDTO> GetAllSpecialties()
        {
            var list = new List<SpecialtyDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = "SELECT SpecialtyID, SpecialtyName FROM Specialty ORDER BY SpecialtyName";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SpecialtyDTO
                {
                    SpecialtyID = Convert.ToInt32(reader["SpecialtyID"]),
                    SpecialtyName = reader["SpecialtyName"].ToString()!,
                    IsDeleted = false
                });
            }
            return list;
        }
    }
}
