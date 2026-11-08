using System;
using System.Collections.Generic;
using MySqlConnector;
using DTO_DCM;

namespace DAL_DCM
{
    public class WorkScheduleDAL
    {
        private readonly DbConnection _db = new();

        // Lấy toàn bộ lịch làm việc
        public List<WorkScheduleDTO> GetAll()
        {
            List<WorkScheduleDTO> schedules = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ws.ScheduleID,
                       ws.DoctorID,
                       e.FullName AS DoctorName,
                       ws.WorkDate,
                       ws.Shift
                FROM WorkSchedule ws
                INNER JOIN Employee e ON ws.DoctorID = e.EmployeeID
                ORDER BY ws.WorkDate DESC, ws.Shift";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schedules.Add(MapReaderToSchedule(reader));
            }

            return schedules;
        }

        // Lấy lịch theo khoảng thời gian (phục vụ xem lịch tuần)
        public List<WorkScheduleDTO> GetSchedulesByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<WorkScheduleDTO> schedules = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ws.ScheduleID,
                       ws.DoctorID,
                       e.FullName AS DoctorName,
                       ws.WorkDate,
                       ws.Shift
                FROM WorkSchedule ws
                INNER JOIN Employee e ON ws.DoctorID = e.EmployeeID
                WHERE ws.WorkDate >= @FromDate AND ws.WorkDate <= @ToDate
                ORDER BY ws.WorkDate ASC, ws.Shift ASC";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
            cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schedules.Add(MapReaderToSchedule(reader));
            }

            return schedules;
        }

        // Lấy lịch của 1 nhân viên trong 1 ngày cụ thể (để kiểm tra xung đột ca làm việc)
        public List<WorkScheduleDTO> GetSchedulesByDoctorAndDate(int doctorID, DateTime workDate, int excludeScheduleID = 0)
        {
            List<WorkScheduleDTO> schedules = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ws.ScheduleID,
                       ws.DoctorID,
                       e.FullName AS DoctorName,
                       ws.WorkDate,
                       ws.Shift
                FROM WorkSchedule ws
                INNER JOIN Employee e ON ws.DoctorID = e.EmployeeID
                WHERE ws.DoctorID = @DoctorID 
                  AND ws.WorkDate = @WorkDate
                  AND ws.ScheduleID != @ExcludeScheduleID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);
            cmd.Parameters.AddWithValue("@WorkDate", workDate.Date);
            cmd.Parameters.AddWithValue("@ExcludeScheduleID", excludeScheduleID);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schedules.Add(MapReaderToSchedule(reader));
            }

            return schedules;
        }

        // Kiểm tra nhân viên có đang hoạt động (Active) hay không
        public bool IsEmployeeActive(int doctorID)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = "SELECT COUNT(1) FROM Employee WHERE EmployeeID = @DoctorID AND EmploymentStatus = 'Active'";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // Lấy lịch theo ID
        public WorkScheduleDTO? GetById(int scheduleID)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ws.ScheduleID,
                       ws.DoctorID,
                       e.FullName AS DoctorName,
                       ws.WorkDate,
                       ws.Shift
                FROM WorkSchedule ws
                INNER JOIN Employee e ON ws.DoctorID = e.EmployeeID
                WHERE ws.ScheduleID = @ScheduleID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
                return MapReaderToSchedule(reader);

            return null;
        }

        // Thêm lịch làm việc
        public bool Add(WorkScheduleDTO schedule)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                INSERT INTO WorkSchedule (DoctorID, WorkDate, Shift)
                VALUES (@DoctorID, @WorkDate, @Shift)";

            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@DoctorID", schedule.DoctorID);
            cmd.Parameters.AddWithValue("@WorkDate", schedule.WorkDate.Date);
            cmd.Parameters.AddWithValue("@Shift", schedule.Shift);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Cập nhật lịch làm việc
        public bool Update(WorkScheduleDTO schedule)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                UPDATE WorkSchedule
                SET DoctorID = @DoctorID,
                    WorkDate = @WorkDate,
                    Shift = @Shift
                WHERE ScheduleID = @ScheduleID";

            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ScheduleID", schedule.ScheduleID);
            cmd.Parameters.AddWithValue("@DoctorID", schedule.DoctorID);
            cmd.Parameters.AddWithValue("@WorkDate", schedule.WorkDate.Date);
            cmd.Parameters.AddWithValue("@Shift", schedule.Shift);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Xóa lịch làm việc
        public bool Delete(int scheduleID)
        {
            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                DELETE FROM WorkSchedule
                WHERE ScheduleID = @ScheduleID";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Tìm kiếm theo mã bác sĩ, tên bác sĩ hoặc ca làm
        public List<WorkScheduleDTO> Search(string keyword)
        {
            List<WorkScheduleDTO> schedules = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT ws.ScheduleID,
                       ws.DoctorID,
                       e.FullName AS DoctorName,
                       ws.WorkDate,
                       ws.Shift
                FROM WorkSchedule ws
                INNER JOIN Employee e ON ws.DoctorID = e.EmployeeID
                WHERE CAST(ws.DoctorID AS CHAR) LIKE @Keyword
                   OR e.FullName LIKE @Keyword
                   OR ws.Shift LIKE @Keyword
                ORDER BY ws.WorkDate DESC, ws.Shift";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                schedules.Add(MapReaderToSchedule(reader));
            }

            return schedules;
        }

        // Lấy danh sách tất cả nhân viên đang hoạt động
        public List<DoctorLookupDTO> GetEmployees()
        {
            List<DoctorLookupDTO> employees = new();

            using var conn = _db.GetConnection();
            conn.Open();

            string query = @"
                SELECT e.EmployeeID, e.FullName, s.SpecialtyName
                FROM Employee e
                LEFT JOIN Specialty s ON e.SpecialtyID = s.SpecialtyID
                WHERE e.EmploymentStatus = 'Active'
                ORDER BY e.FullName ASC";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new DoctorLookupDTO
                {
                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                    FullName = reader["FullName"].ToString()!,
                    SpecialtyName = reader["SpecialtyName"] != DBNull.Value
                        ? reader["SpecialtyName"].ToString()
                        : null
                });
            }

            return employees;
        }

        // Giữ tương thích ngược với code cũ gọi GetDoctors()
        public List<DoctorLookupDTO> GetDoctors() => GetEmployees();

        // Chuyển dữ liệu từ MySQL sang DTO
        private WorkScheduleDTO MapReaderToSchedule(MySqlDataReader reader)
        {
            return new WorkScheduleDTO
            {
                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                DoctorName = reader["DoctorName"] != DBNull.Value ? reader["DoctorName"].ToString() : string.Empty,
                WorkDate = Convert.ToDateTime(reader["WorkDate"]),
                Shift = reader["Shift"].ToString()!
            };
        }
    }
}
