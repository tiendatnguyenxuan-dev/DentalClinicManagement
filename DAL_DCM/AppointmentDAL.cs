using MySqlConnector;
using DTO_DCM;
using System;
using System.Collections.Generic;

namespace DAL_DCM
{
    public class AppointmentDAL
    {
        private readonly DbConnection _db = new DbConnection();

        /// <summary>
        /// Lấy toàn bộ danh sách lịch hẹn kèm thông tin chi tiết bệnh nhân, bác sĩ, chuyên khoa
        /// </summary>
        public List<AppointmentDTO> GetAllAppointments()
        {
            var list = new List<AppointmentDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    SELECT 
                        a.AppointmentID, 
                        a.PatientID, 
                        a.DoctorID, 
                        a.AppointmentDateTime, 
                        a.AppointmentStatus, 
                        a.Notes,
                        p.FullName AS PatientName, 
                        p.Phone AS PatientPhone,
                        e.FullName AS DoctorName, 
                        s.SpecialtyName
                    FROM Appointment a
                    INNER JOIN Patient p ON a.PatientID = p.PatientID
                    INNER JOIN Employee e ON a.DoctorID = e.EmployeeID
                    LEFT JOIN Specialty s ON e.SpecialtyID = s.SpecialtyID
                    ORDER BY a.AppointmentDateTime DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToAppointmentDTO(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Tra cứu & lọc danh sách lịch hẹn theo điều kiện (Từ ngày - Đến ngày, Trạng thái, Bác sĩ, Từ khóa bệnh nhân)
        /// </summary>
        public List<AppointmentDTO> SearchAppointments(DateTime? fromDate, DateTime? toDate, string? status, int? doctorId, string? keyword)
        {
            var list = new List<AppointmentDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    SELECT 
                        a.AppointmentID, 
                        a.PatientID, 
                        a.DoctorID, 
                        a.AppointmentDateTime, 
                        a.AppointmentStatus, 
                        a.Notes,
                        p.FullName AS PatientName, 
                        p.Phone AS PatientPhone,
                        e.FullName AS DoctorName, 
                        s.SpecialtyName
                    FROM Appointment a
                    INNER JOIN Patient p ON a.PatientID = p.PatientID
                    INNER JOIN Employee e ON a.DoctorID = e.EmployeeID
                    LEFT JOIN Specialty s ON e.SpecialtyID = s.SpecialtyID
                    WHERE 1=1";

                if (fromDate.HasValue)
                    query += " AND DATE(a.AppointmentDateTime) >= DATE(@fromDate)";
                if (toDate.HasValue)
                    query += " AND DATE(a.AppointmentDateTime) <= DATE(@toDate)";
                if (!string.IsNullOrEmpty(status) && status != "Tất cả")
                    query += " AND a.AppointmentStatus = @status";
                if (doctorId.HasValue && doctorId > 0)
                    query += " AND a.DoctorID = @doctorId";
                if (!string.IsNullOrWhiteSpace(keyword))
                    query += " AND (p.FullName LIKE @keyword OR p.Phone LIKE @keyword)";

                query += " ORDER BY a.AppointmentDateTime DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (fromDate.HasValue) cmd.Parameters.AddWithValue("@fromDate", fromDate.Value);
                    if (toDate.HasValue) cmd.Parameters.AddWithValue("@toDate", toDate.Value);
                    if (!string.IsNullOrEmpty(status) && status != "Tất cả") cmd.Parameters.AddWithValue("@status", status);
                    if (doctorId.HasValue && doctorId > 0) cmd.Parameters.AddWithValue("@doctorId", doctorId.Value);
                    if (!string.IsNullOrWhiteSpace(keyword)) cmd.Parameters.AddWithValue("@keyword", $"%{keyword.Trim()}%");

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToAppointmentDTO(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Thêm mới lịch hẹn
        /// </summary>
        public bool AddAppointment(AppointmentDTO appointment)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    INSERT INTO Appointment (PatientID, DoctorID, AppointmentDateTime, AppointmentStatus, Notes)
                    VALUES (@PatientID, @DoctorID, @AppointmentDateTime, @AppointmentStatus, @Notes)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                    cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                    cmd.Parameters.AddWithValue("@AppointmentDateTime", appointment.AppointmentDateTime);
                    cmd.Parameters.AddWithValue("@AppointmentStatus", appointment.AppointmentStatus);
                    cmd.Parameters.AddWithValue("@Notes", (object?)appointment.Notes ?? DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Cập nhật toàn bộ thông tin lịch hẹn
        /// </summary>
        public bool UpdateAppointment(AppointmentDTO appointment)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    UPDATE Appointment
                    SET PatientID = @PatientID,
                        DoctorID = @DoctorID,
                        AppointmentDateTime = @AppointmentDateTime,
                        AppointmentStatus = @AppointmentStatus,
                        Notes = @Notes
                    WHERE AppointmentID = @AppointmentID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
                    cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                    cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                    cmd.Parameters.AddWithValue("@AppointmentDateTime", appointment.AppointmentDateTime);
                    cmd.Parameters.AddWithValue("@AppointmentStatus", appointment.AppointmentStatus);
                    cmd.Parameters.AddWithValue("@Notes", (object?)appointment.Notes ?? DBNull.Value);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Cập nhật nhanh trạng thái lịch hẹn (Pending, Confirmed, Completed, Cancelled, NoShow)
        /// </summary>
        public bool UpdateStatus(int appointmentId, string status)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    UPDATE Appointment
                    SET AppointmentStatus = @status
                    WHERE AppointmentID = @appointmentId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Xóa lịch hẹn
        /// </summary>
        public bool DeleteAppointment(int appointmentId)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = "DELETE FROM Appointment WHERE AppointmentID = @appointmentId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem bác sĩ đã có lịch trùng vào cùng thời điểm hay chưa (trừ những ca đã Hủy)
        /// </summary>
        public bool HasDoctorConflict(int doctorId, DateTime appointmentDateTime, int excludeAppointmentId = 0)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    SELECT COUNT(1) 
                    FROM Appointment
                    WHERE DoctorID = @doctorId 
                      AND AppointmentDateTime = @appointmentDateTime
                      AND AppointmentStatus <> 'Cancelled'
                      AND AppointmentID <> @excludeAppointmentId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@doctorId", doctorId);
                    cmd.Parameters.AddWithValue("@appointmentDateTime", appointmentDateTime);
                    cmd.Parameters.AddWithValue("@excludeAppointmentId", excludeAppointmentId);

                    conn.Open();
                    long count = Convert.ToInt64(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// Lấy danh sách bác sĩ đang hoạt động để nạp ComboBox
        /// </summary>
        public List<DoctorLookupDTO> GetDoctorLookupList()
        {
            var list = new List<DoctorLookupDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    SELECT 
                        e.EmployeeID, 
                        e.FullName, 
                        s.SpecialtyName
                    FROM Employee e
                    LEFT JOIN Specialty s ON e.SpecialtyID = s.SpecialtyID
                    WHERE e.Position = 'Doctor' AND e.EmploymentStatus = 'Active'
                    ORDER BY e.FullName ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DoctorLookupDTO
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                FullName = reader["FullName"].ToString()!,
                                SpecialtyName = reader["SpecialtyName"] != DBNull.Value ? reader["SpecialtyName"].ToString() : null
                            });
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy danh sách bệnh nhân để nạp ComboBox
        /// </summary>
        public List<PatientLookupDTO> GetPatientLookupList()
        {
            var list = new List<PatientLookupDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                string query = @"
                    SELECT PatientID, FullName, Phone
                    FROM Patient
                    ORDER BY FullName ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PatientLookupDTO
                            {
                                PatientID = Convert.ToInt32(reader["PatientID"]),
                                FullName = reader["FullName"].ToString()!,
                                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null
                            });
                        }
                    }
                }
            }

            return list;
        }

        private AppointmentDTO MapReaderToAppointmentDTO(MySqlDataReader reader)
        {
            return new AppointmentDTO
            {
                AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                PatientID = Convert.ToInt32(reader["PatientID"]),
                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                AppointmentDateTime = Convert.ToDateTime(reader["AppointmentDateTime"]),
                AppointmentStatus = reader["AppointmentStatus"].ToString()!,
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                PatientName = reader["PatientName"].ToString(),
                PatientPhone = reader["PatientPhone"] != DBNull.Value ? reader["PatientPhone"].ToString() : null,
                DoctorName = reader["DoctorName"].ToString(),
                SpecialtyName = reader["SpecialtyName"] != DBNull.Value ? reader["SpecialtyName"].ToString() : null
            };
        }
    }
}