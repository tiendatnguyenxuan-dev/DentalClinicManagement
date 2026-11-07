using DAL_DCM;
using DTO_DCM;
using System;
using System.Collections.Generic;

namespace BLL_DCM
{
    public class AppointmentBLL
    {
        private readonly AppointmentDAL _appointmentDAL = new AppointmentDAL();

        /// <summary>
        /// Lấy toàn bộ danh sách lịch hẹn
        /// </summary>
        public List<AppointmentDTO> GetAllAppointments()
        {
            return _appointmentDAL.GetAllAppointments();
        }

        /// <summary>
        /// Tra cứu & lọc lịch hẹn
        /// </summary>
        public List<AppointmentDTO> SearchAppointments(DateTime? fromDate, DateTime? toDate, string? status, int? doctorId, string? keyword)
        {
            return _appointmentDAL.SearchAppointments(fromDate, toDate, status, doctorId, keyword);
        }

        /// <summary>
        /// Lấy danh sách chọn Bác sĩ
        /// </summary>
        public List<DoctorLookupDTO> GetDoctorLookupList()
        {
            return _appointmentDAL.GetDoctorLookupList();
        }

        /// <summary>
        /// Lấy danh sách chọn Bệnh nhân
        /// </summary>
        public List<PatientLookupDTO> GetPatientLookupList()
        {
            return _appointmentDAL.GetPatientLookupList();
        }

        /// <summary>
        /// Thêm mới lịch hẹn
        /// </summary>
        public OperationResult AddAppointment(AppointmentDTO appointment)
        {
            // 1. Kiểm tra thông tin bắt buộc
            if (appointment.PatientID <= 0)
            {
                return OperationResult.Failure("Vui lòng chọn bệnh nhân.");
            }

            if (appointment.DoctorID <= 0)
            {
                return OperationResult.Failure("Vui lòng chọn bác sĩ khám.");
            }

            // 2. Kiểm tra thời gian đặt hẹn không được nằm trong quá khứ (trừ sai lệch vài phút)
            if (appointment.AppointmentDateTime < DateTime.Now.AddMinutes(-5))
            {
                return OperationResult.Failure("Thời gian đặt hẹn không thể ở trong quá khứ.");
            }

            // 3. Kiểm tra trùng lịch của bác sĩ
            if (_appointmentDAL.HasDoctorConflict(appointment.DoctorID, appointment.AppointmentDateTime))
            {
                return OperationResult.Failure("Bác sĩ đã có lịch hẹn khác vào thời điểm này. Vui lòng chọn thời gian hoặc bác sĩ khác.");
            }

            // 4. Mặc định trạng thái khi tạo mới nếu chưa có
            if (string.IsNullOrWhiteSpace(appointment.AppointmentStatus))
            {
                appointment.AppointmentStatus = "Pending";
            }

            // 5. Thực hiện thêm vào CSDL
            bool result = _appointmentDAL.AddAppointment(appointment);
            if (result)
            {
                return OperationResult.Success("Thêm lịch hẹn mới thành công!");
            }

            return OperationResult.Failure("Thêm lịch hẹn thất bại. Vui lòng thử lại.");
        }

        /// <summary>
        /// Cập nhật chi tiết lịch hẹn
        /// </summary>
        public OperationResult UpdateAppointment(AppointmentDTO appointment)
        {
            if (appointment.AppointmentID <= 0)
            {
                return OperationResult.Failure("Mã lịch hẹn không hợp lệ.");
            }

            if (appointment.PatientID <= 0)
            {
                return OperationResult.Failure("Vui lòng chọn bệnh nhân.");
            }

            if (appointment.DoctorID <= 0)
            {
                return OperationResult.Failure("Vui lòng chọn bác sĩ.");
            }

            // Kiểm tra trùng lịch của bác sĩ (loại trừ chính lịch hẹn đang sửa)
            if (_appointmentDAL.HasDoctorConflict(appointment.DoctorID, appointment.AppointmentDateTime, appointment.AppointmentID))
            {
                return OperationResult.Failure("Bác sĩ đã có lịch hẹn khác vào thời điểm này.");
            }

            bool result = _appointmentDAL.UpdateAppointment(appointment);
            if (result)
            {
                return OperationResult.Success("Cập nhật thông tin lịch hẹn thành công!");
            }

            return OperationResult.Failure("Cập nhật lịch hẹn thất bại.");
        }

        /// <summary>
        /// Cập nhật nhanh trạng thái lịch hẹn
        /// </summary>
        public OperationResult UpdateStatus(int appointmentId, string newStatus)
        {
            if (appointmentId <= 0)
            {
                return OperationResult.Failure("Mã lịch hẹn không hợp lệ.");
            }

            string[] validStatuses = { "Pending", "Confirmed", "Completed", "Cancelled", "NoShow" };
            if (Array.IndexOf(validStatuses, newStatus) < 0)
            {
                return OperationResult.Failure("Trạng thái lịch hẹn không hợp lệ.");
            }

            bool result = _appointmentDAL.UpdateStatus(appointmentId, newStatus);
            if (result)
            {
                return OperationResult.Success($"Đã cập nhật trạng thái lịch hẹn thành '{newStatus}'.");
            }

            return OperationResult.Failure("Cập nhật trạng thái thất bại.");
        }

        /// <summary>
        /// Xóa lịch hẹn
        /// </summary>
        public OperationResult DeleteAppointment(int appointmentId)
        {
            if (appointmentId <= 0)
            {
                return OperationResult.Failure("Vui lòng chọn lịch hẹn cần xóa.");
            }

            bool result = _appointmentDAL.DeleteAppointment(appointmentId);
            if (result)
            {
                return OperationResult.Success("Xóa lịch hẹn thành công!");
            }

            return OperationResult.Failure("Xóa lịch hẹn thất bại.");
        }
    }
}