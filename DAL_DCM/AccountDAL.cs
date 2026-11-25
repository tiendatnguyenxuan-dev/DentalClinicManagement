using DTO_DCM;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace DAL_DCM
{
    public class AccountDAL
    {
        private readonly DbConnection db = new DbConnection();

        public AccountDAL()
        {
        }

        /// <summary>
        /// Kiểm tra thông tin đăng nhập từ MySQL và nạp đầy đủ AccountID, EmployeeID, FullName, Role
        /// </summary>
        public AccountDTO? CheckLogin(string username, string password)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT a.AccountID, a.EmployeeID, a.Username, a.PasswordHash, a.AccountStatus,
                               COALESCE(e.FullName, a.Username) AS FullName,
                               COALESCE(e.Position, 'Admin') AS Role
                        FROM Account a
                        LEFT JOIN Employee e ON a.EmployeeID = e.EmployeeID
                        WHERE a.Username = @username
                          AND a.PasswordHash = @password
                          AND a.AccountStatus = 'Active'
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountDTO
                                {
                                    AccountID = Convert.ToInt32(reader["AccountID"]),
                                    EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : 0,
                                    Username = reader["Username"].ToString()!,
                                    Password = reader["PasswordHash"].ToString()!,
                                    FullName = reader["FullName"].ToString()!,
                                    Role = reader["Role"].ToString()!,
                                    AccountStatus = reader["AccountStatus"].ToString()!
                                };
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Lỗi kết nối hoặc truy vấn MySQL: " + ex.Message);
                }
            }

            return null;
        }
    }
}
