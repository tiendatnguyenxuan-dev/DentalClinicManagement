using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class WorkScheduleBLL
    {
        private readonly WorkScheduleDAL _workScheduleDAL = new();

        // Lấy toàn bộ lịch làm việc
        public List<WorkScheduleDTO> GetAllSchedules()
        {
            return _workScheduleDAL.GetAll();
        }

        // Lấy lịch làm việc theo khoảng ngày (dành cho chế độ xem lịch theo tuần)
        public List<WorkScheduleDTO> GetSchedulesByDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                return new List<WorkScheduleDTO>();

            return _workScheduleDAL.GetSchedulesByDateRange(fromDate, toDate);
        }

        // Lấy lịch theo ID
        public WorkScheduleDTO? GetScheduleById(int scheduleID)
        {
            if (scheduleID <= 0)
                return null;

            return _workScheduleDAL.GetById(scheduleID);
        }

        // Thêm lịch làm việc
        public (bool IsSuccess, string Message) AddSchedule(WorkScheduleDTO schedule)
        {
            // Kiểm tra không thêm lịch trong quá khứ
            if (schedule.WorkDate.Date < DateTime.Today)
            {
                return (false, "Không được phép thêm lịch làm việc trong quá khứ!");
            }

            var validation = ValidateSchedule(schedule, excludeScheduleID: 0);
            if (!validation.IsValid)
                return (false, validation.Message);

            bool added = _workScheduleDAL.Add(schedule);
            if (added)
            {
                LogAction($"[THÊM LỊCH] Thành công - Mã BS: {schedule.DoctorID}, Ngày: {schedule.WorkDate:dd/MM/yyyy}, Ca: {schedule.Shift}");
                return (true, "Thêm lịch làm việc thành công!");
            }

            return (false, "Không thể thêm lịch làm việc vào cơ sở dữ liệu.");
        }

        // Cập nhật lịch làm việc
        public (bool IsSuccess, string Message) UpdateSchedule(WorkScheduleDTO schedule)
        {
            if (schedule == null || schedule.ScheduleID <= 0)
                return (false, "Vui lòng chọn lịch cần cập nhật!");

            var validation = ValidateSchedule(schedule, excludeScheduleID: schedule.ScheduleID);
            if (!validation.IsValid)
                return (false, validation.Message);

            bool updated = _workScheduleDAL.Update(schedule);
            if (updated)
            {
                LogAction($"[CẬP NHẬT LỊCH] Thành công - Mã Lịch: {schedule.ScheduleID}, Mã BS: {schedule.DoctorID}, Ngày: {schedule.WorkDate:dd/MM/yyyy}, Ca: {schedule.Shift}");
                return (true, "Cập nhật lịch làm việc thành công!");
            }

            return (false, "Không tìm thấy lịch cần cập nhật hoặc dữ liệu không thay đổi.");
        }

        // Xóa lịch làm việc
        public (bool IsSuccess, string Message) DeleteSchedule(int scheduleID)
        {
            if (scheduleID <= 0)
                return (false, "Mã lịch làm việc không hợp lệ!");

            bool deleted = _workScheduleDAL.Delete(scheduleID);
            if (deleted)
            {
                LogAction($"[XÓA LỊCH] Thành công - Mã Lịch: {scheduleID}");
                return (true, "Xóa lịch làm việc thành công!");
            }

            return (false, "Không tìm thấy lịch cần xóa.");
        }

        // Tìm kiếm lịch làm việc
        public List<WorkScheduleDTO> SearchSchedules(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllSchedules();

            return _workScheduleDAL.Search(keyword.Trim());
        }

        // Lấy danh sách nhân viên để chọn trên ComboBox
        public List<DoctorLookupDTO> GetDoctorLookupList()
        {
            return _workScheduleDAL.GetEmployees();
        }

        // Kiểm tra tính hợp lệ và các quy tắc nghiệp vụ
        private (bool IsValid, string Message) ValidateSchedule(WorkScheduleDTO schedule, int excludeScheduleID)
        {
            if (schedule == null)
                return (false, "Thông tin lịch làm việc không hợp lệ!");

            if (schedule.DoctorID <= 0)
                return (false, "Vui lòng chọn nhân viên/bác sĩ phụ trách!");

            if (schedule.WorkDate == default)
                return (false, "Vui lòng chọn ngày làm việc hợp lệ!");

            // 1. Chỉ cho phép phân lịch cho nhân viên đang hoạt động (Active)
            if (!_workScheduleDAL.IsEmployeeActive(schedule.DoctorID))
            {
                return (false, "Chỉ được phép phân lịch cho nhân viên đang ở trạng thái hoạt động (Active)!");
            }

            // 2. Chuẩn hóa giá trị ca làm việc sang: Morning, Afternoon, FullDay
            string shift = schedule.Shift?.Trim() ?? string.Empty;
            if (string.Equals(shift, "Morning", StringComparison.OrdinalIgnoreCase) || shift.Contains("Sáng"))
            {
                schedule.Shift = "Morning";
            }
            else if (string.Equals(shift, "Afternoon", StringComparison.OrdinalIgnoreCase) || shift.Contains("Chiều"))
            {
                schedule.Shift = "Afternoon";
            }
            else if (string.Equals(shift, "FullDay", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(shift, "Fullday", StringComparison.OrdinalIgnoreCase) ||
                     shift.Contains("Cả ngày"))
            {
                schedule.Shift = "FullDay";
            }
            else
            {
                return (false, "Ca làm việc không hợp lệ! Hệ thống chỉ hỗ trợ 3 ca: Sáng (Morning), Chiều (Afternoon) hoặc Cả ngày (FullDay).");
            }

            // 3. Kiểm tra trùng lịch và xung đột ca làm việc của nhân viên trong ngày
            var existingSchedules = _workScheduleDAL.GetSchedulesByDoctorAndDate(
                schedule.DoctorID,
                schedule.WorkDate.Date,
                excludeScheduleID);

            // Quy tắc: Không cho phép trùng ca cùng ngày
            if (existingSchedules.Any(s => string.Equals(s.Shift, schedule.Shift, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, $"Nhân viên đã có lịch làm việc ca '{schedule.ShiftDisplayName}' trong ngày {schedule.WorkDate:dd/MM/yyyy}!");
            }

            // Quy tắc: Nếu ca mới là "Cả ngày", không được phép có ca Sáng hoặc Chiều
            if (schedule.Shift == "FullDay" && existingSchedules.Count > 0)
            {
                return (false, $"Nhân viên đã có ca làm việc khác trong ngày {schedule.WorkDate:dd/MM/yyyy}, không thể phân thêm ca 'Cả ngày'!");
            }

            // Quy tắc: Nếu trong ngày đã có ca "Cả ngày", không được phép phân thêm ca Sáng hoặc Chiều
            if (existingSchedules.Any(s => string.Equals(s.Shift, "FullDay", StringComparison.OrdinalIgnoreCase) ||
                                           string.Equals(s.Shift, "Fullday", StringComparison.OrdinalIgnoreCase)))
            {
                return (false, $"Nhân viên đã được phân ca 'Cả ngày' trong ngày {schedule.WorkDate:dd/MM/yyyy}, không thể phân thêm ca khác!");
            }

            return (true, string.Empty);
        }

        // Ghi log hoạt động khi thêm, cập nhật hoặc xóa lịch làm việc
        private void LogAction(string message)
        {
            try
            {
                string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
                System.Diagnostics.Debug.WriteLine(logLine);
                File.AppendAllText("schedule_activity.log", logLine);
            }
            catch
            {
                // Bỏ qua lỗi ghi file log để không làm gián đoạn nghiệp vụ người dùng
            }
        }
    }
}
