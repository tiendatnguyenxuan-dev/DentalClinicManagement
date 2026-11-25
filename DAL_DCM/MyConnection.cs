using MySqlConnector;
using System;

namespace DAL_DCM
{
    public class MyConnection
    {
        private readonly string connectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=DentalClinic;" +
            "Uid=root;" +
            "Pwd=1234;" +
            "CharSet=utf8mb4;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
