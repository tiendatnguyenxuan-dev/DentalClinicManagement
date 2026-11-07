
using System;
using System.Collections.Generic;
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

        // Lấy lịch theo ID
        public WorkScheduleDTO? GetScheduleById(int scheduleID)
        {
            if (scheduleID <= 0)
                return null;

            return _workScheduleDAL.GetById(scheduleID);
        }

        // Thêm lịch làm việc
        public (bool IsSuccess, string Message) AddSchedule(
            WorkScheduleDTO schedule)
        {
            var validation = ValidateSchedule(schedule);

            if (!validation.IsValid)
                return (false, validation.Message);

            bool added = _workScheduleDAL.Add(schedule);

            return added ? (true, "Thêm lịch làm việc thành công!"): (false, "Không thể thêm lịch làm việc.");
        }

        // Cập nhật lịch làm việc
        public (bool IsSuccess, string Message) UpdateSchedule(
            WorkScheduleDTO schedule)
        {
            if (schedule == null || schedule.ScheduleID <= 0)
                return (false, "Vui lòng chọn lịch cần cập nhật!");

            var validation = ValidateSchedule(schedule);

            if (!validation.IsValid)
                return (false, validation.Message);

            bool updated = _workScheduleDAL.Update(schedule);

            return updated
                ? (true, "Cập nhật lịch làm việc thành công!")
                : (false, "Không tìm thấy lịch cần cập nhật hoặc dữ liệu không thay đổi.");
        }

        // Xóa lịch làm việc
        public (bool IsSuccess, string Message) DeleteSchedule(int scheduleID)
        {
            if (scheduleID <= 0)
                return (false, "Mã lịch làm việc không hợp lệ!");

            bool deleted = _workScheduleDAL.Delete(scheduleID);

            return deleted
                ? (true, "Xóa lịch làm việc thành công!")
                : (false, "Không tìm thấy lịch cần xóa.");
        }

        // Tìm kiếm lịch làm việc
        public List<WorkScheduleDTO> SearchSchedules(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllSchedules();

            return _workScheduleDAL.Search(keyword.Trim());
        }

        // Lấy danh sách bác sĩ để chọn trên ComboBox
        public List<DoctorLookupDTO> GetDoctorLookupList()
        {
            return _workScheduleDAL.GetDoctors();
        }

        // Kiểm tra dữ liệu đầu vào
        private (bool IsValid, string Message) ValidateSchedule(
            WorkScheduleDTO schedule)
        {
            if (schedule == null)
                return (false, "Thông tin lịch làm việc không hợp lệ!");

            if (schedule.DoctorID <= 0)
                return (false, "Mã bác sĩ không hợp lệ!");

            if (schedule.WorkDate == default)
                return (false, "Vui lòng chọn ngày làm việc!");

            if (schedule.Shift != "Morning" &&
                schedule.Shift != "Afternoon" &&
                schedule.Shift != "Evening")
            {
                return (false, "Ca làm việc không hợp lệ!");
            }

            return (true, string.Empty);
        }
    }
}
