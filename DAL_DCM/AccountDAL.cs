using DTO_DCM;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_DCM
{
    public class AccountDAL
    {
        private readonly DbConnection db = new DbConnection();

        public AccountDAL()
        {
            // Khởi tạo kết nối CSDL ở đây nếu cần
        }


        /// <summary>
        /// Kiểm tra thông tin đăng nhập từ MySQL
        /// </summary>
        public AccountDTO? CheckLogin(string username, string password)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT *
                        FROM Account
                        WHERE Username = @username
                        AND PasswordHash = @password
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountDTO(
                                    reader["Username"].ToString()!,
                                    reader["PasswordHash"].ToString()!
                            
                                );
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception(
                        "Lỗi kết nối hoặc truy vấn MySQL: " + ex.Message);
                }
            }

            return null;
        }
    }
}

