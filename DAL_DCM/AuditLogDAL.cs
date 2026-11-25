using System;
using System.Collections.Generic;
using DTO_DCM;
using MySqlConnector;

namespace DAL_DCM
{
    public class AuditLogDAL
    {
        private readonly DbConnection _db = new();

        public void InsertLog(int? accountId, string actionType, string entityName, int entityId, string description)
        {
            try
            {
                using var conn = _db.GetConnection();
                conn.Open();

                string query = @"
                    INSERT INTO AuditLog (AccountID, ActionType, EntityName, EntityID, Description, CreatedAt)
                    VALUES (@AccountID, @ActionType, @EntityName, @EntityID, @Description, NOW())";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AccountID", (object?)accountId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ActionType", actionType);
                cmd.Parameters.AddWithValue("@EntityName", entityName);
                cmd.Parameters.AddWithValue("@EntityID", entityId);
                cmd.Parameters.AddWithValue("@Description", (object?)description ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                // Không chặn luồng nghiệp vụ chính nếu ghi log gặp sự cố
            }
        }

        public List<AuditLogDTO> GetAllLogs()
        {
            var list = new List<AuditLogDTO>();
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT al.*, a.Username
                FROM AuditLog al
                LEFT JOIN Account a ON al.AccountID = a.AccountID
                ORDER BY al.LogID DESC
                LIMIT 200";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AuditLogDTO
                {
                    LogID = Convert.ToInt64(reader["LogID"]),
                    AccountID = reader["AccountID"] != DBNull.Value ? Convert.ToInt32(reader["AccountID"]) : null,
                    Username = reader["Username"]?.ToString() ?? "(System)",
                    ActionType = reader["ActionType"].ToString()!,
                    EntityName = reader["EntityName"].ToString()!,
                    EntityID = Convert.ToInt32(reader["EntityID"]),
                    Description = reader["Description"]?.ToString(),
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                });
            }
            return list;
        }
    }
}
