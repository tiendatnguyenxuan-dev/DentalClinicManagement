
using System.Collections.Generic;
using MySqlConnector;
using DTO_DCM;

namespace DAL_DCM
{
    public class ServiceDAL
    {
        private readonly DbConnection _db = new();

        // Lấy danh sách dịch vụ
        public List<ServiceDTO> GetAll()
        {
            List<ServiceDTO> services = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ServiceID, ServiceName, ServiceCategory,
                       UnitPrice, Unit
                FROM Service
                ORDER BY ServiceID";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                services.Add(MapReaderToService(reader));
            }

            return services;
        }

        // Lấy dịch vụ theo ID
        public ServiceDTO? GetById(int serviceID)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ServiceID, ServiceName, ServiceCategory,
                       UnitPrice, Unit
                FROM Service
                WHERE ServiceID = @ServiceID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ServiceID", serviceID);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
                return MapReaderToService(reader);

            return null;
        }

        // Thêm dịch vụ
        public bool Add(ServiceDTO service)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                INSERT INTO Service
                    (ServiceName, ServiceCategory, UnitPrice, Unit)
                VALUES
                    (@ServiceName, @ServiceCategory, @UnitPrice, @Unit)";

            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceCategory",
                (object?)service.ServiceCategory ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitPrice", service.UnitPrice);
            cmd.Parameters.AddWithValue("@Unit",
                (object?)service.Unit ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Cập nhật dịch vụ
        public bool Update(ServiceDTO service)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                UPDATE Service
                SET ServiceName = @ServiceName,
                    ServiceCategory = @ServiceCategory,
                    UnitPrice = @UnitPrice,
                    Unit = @Unit
                WHERE ServiceID = @ServiceID";

            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ServiceID", service.ServiceID);
            cmd.Parameters.AddWithValue("@ServiceName", service.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceCategory",
                (object?)service.ServiceCategory ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitPrice", service.UnitPrice);
            cmd.Parameters.AddWithValue("@Unit",
                (object?)service.Unit ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Xóa dịch vụ
        public bool Delete(int serviceID)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                DELETE FROM Service
                WHERE ServiceID = @ServiceID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ServiceID", serviceID);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Tìm kiếm dịch vụ theo tên hoặc danh mục
        public List<ServiceDTO> Search(string keyword)
        {
            List<ServiceDTO> services = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ServiceID, ServiceName, ServiceCategory,
                       UnitPrice, Unit
                FROM Service
                WHERE ServiceName LIKE @Keyword
                   OR ServiceCategory LIKE @Keyword
                ORDER BY ServiceID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                services.Add(MapReaderToService(reader));
            }

            return services;
        }

        // Chuyển dữ liệu từ MySQL sang ServiceDTO
        private ServiceDTO MapReaderToService(MySqlDataReader reader)
        {
            return new ServiceDTO
            {
                ServiceID = Convert.ToInt32(reader["ServiceID"]),
                ServiceName = reader["ServiceName"].ToString()!,
                ServiceCategory = reader["ServiceCategory"] == DBNull.Value
                    ? null
                    : reader["ServiceCategory"].ToString(),
                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                Unit = reader["Unit"] == DBNull.Value
                    ? null
                    : reader["Unit"].ToString()
            };
        }
    }
}
