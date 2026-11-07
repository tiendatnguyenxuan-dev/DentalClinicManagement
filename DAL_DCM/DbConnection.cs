using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DCM
{
    public class DbConnection
    {
        private readonly string connectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=DentalClinic;" +
            "Uid=root;" +
            "Pwd=1234;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
