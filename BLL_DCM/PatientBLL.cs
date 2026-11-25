using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class PatientBLL
    {
        private readonly PatientDAL _patientDAL = new();
        private readonly AppointmentDAL _appointmentDAL = new();

        // Lấy danh sách bệnh nhân
        public List<PatientDTO> GetAllPatients()
        {
            return _patientDAL.GetAll();
        }

        // Lấy thông tin bệnh nhân theo ID
        public PatientDTO? GetPatientById(int patientID)
        {
            if (patientID <= 0) return null;
            return _patientDAL.GetById(patientID);
        }

        // Thêm bệnh nhân
        public (bool IsSuccess, string Message) AddPatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient, isUpdate: false);
            if (!validation.IsValid)
                return (false, validation.Message);

            bool added = _patientDAL.Add(patient);
            return added ? (true, "Thêm bệnh nhân thành công!") : (false, "Không thể thêm bệnh nhân.");
        }

        // Đăng ký bệnh nhân mới VÀ tự động tiếp nhận vào hàng đợi khám với lý do khám
        public (bool IsSuccess, string Message, int PatientId) RegisterAndQueue(PatientDTO patient, string? reason, int? doctorId = null)
        {
            var validation = ValidatePatient(patient, isUpdate: false);
            if (!validation.IsValid)
                return (false, validation.Message, 0);

            try
            {
                int newPatientId = _patientDAL.AddAndReturnId(patient);
                if (newPatientId <= 0)
                {
                    return (false, "Không thể lưu thông tin bệnh nhân.", 0);
                }

                // Nếu chưa chỉ định bác sĩ, lấy bác sĩ đầu tiên có sẵn trong hệ thống
                int targetDoctorId = doctorId ?? 0;
                if (targetDoctorId <= 0)
                {
                    var doctors = _appointmentDAL.GetDoctorLookupList();
                    if (doctors.Count > 0)
                    {
                        targetDoctorId = doctors[0].EmployeeID;
                    }
                }

                if (targetDoctorId > 0)
                {
                    var appointment = new AppointmentDTO
                    {
                        PatientID = newPatientId,
                        DoctorID = targetDoctorId,
                        AppointmentDateTime = DateTime.Now,
                        AppointmentStatus = "Confirmed", // Trạng thái đã tiếp nhận tại phòng khám
                        Notes = string.IsNullOrWhiteSpace(reason) ? "Khám bệnh nhân mới" : reason.Trim()
                    };
                    _appointmentDAL.AddAppointment(appointment);
                }

                return (true, "Thêm bệnh nhân và chuyển vào tiếp nhận khám thành công!", newPatientId);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi tiếp nhận khám: " + ex.Message, 0);
            }
        }

        // Cập nhật bệnh nhân
        public (bool IsSuccess, string Message) UpdatePatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient, isUpdate: true);
            if (!validation.IsValid)
                return (false, validation.Message);

            bool updated = _patientDAL.Update(patient);
            return updated ? (true, "Cập nhật thông tin bệnh nhân thành công!") : (false, "Không tìm thấy bệnh nhân cần cập nhật.");
        }

        // Xóa bệnh nhân
        public (bool IsSuccess, string Message) DeletePatient(int patientID)
        {
            if (patientID <= 0)
                return (false, "Mã bệnh nhân không hợp lệ!");

            bool deleted = _patientDAL.Delete(patientID);
            return deleted ? (true, "Đã xóa bệnh nhân thành công!") : (false, "Không thể xóa bệnh nhân.");
        }

        // Tìm kiếm bệnh nhân trên danh sách trong bộ nhớ (Đáp ứng yêu cầu: Tìm kiếm trên ArrayList/List trong BUS)
        public List<PatientDTO> SearchPatients(string keyword)
        {
            List<PatientDTO> allList = GetAllPatients();
            if (string.IsNullOrWhiteSpace(keyword))
                return allList;

            string key = keyword.Trim().ToLower();
            var result = new List<PatientDTO>();

            // Duyệt tuần tự trên List<PatientDTO> trong tầng BUS
            foreach (var p in allList)
            {
                if (p.PatientID.ToString().Contains(key) ||
                    (!string.IsNullOrEmpty(p.FullName) && p.FullName.ToLower().Contains(key)) ||
                    (!string.IsNullOrEmpty(p.Phone) && p.Phone.Contains(key)) ||
                    (!string.IsNullOrEmpty(p.Email) && p.Email.ToLower().Contains(key)))
                {
                    result.Add(p);
                }
            }

            return result;
        }

        private (bool IsValid, string Message) ValidatePatient(PatientDTO patient, bool isUpdate)
        {
            if (patient == null)
                return (false, "Thông tin bệnh nhân không hợp lệ!");

            if (isUpdate && patient.PatientID <= 0)
                return (false, "Mã bệnh nhân không hợp lệ!");

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(patient.FullName))
                return (false, "Họ tên bệnh nhân không được để trống!");

            if (patient.FullName.Trim().Length < 2)
                return (false, "Họ tên phải có ít nhất 2 ký tự!");

            if (patient.FullName.Trim().Length > 100)
                return (false, "Họ tên bệnh nhân không được vượt quá 100 ký tự!");

            // Kiểm tra số điện thoại
            if (!string.IsNullOrWhiteSpace(patient.Phone))
            {
                if (!Regex.IsMatch(patient.Phone.Trim(), @"^0\d{9,10}$"))
                    return (false, "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!");
            }

            // Kiểm tra ngày sinh (có thể để trống)
            if (patient.DateOfBirth.HasValue && patient.DateOfBirth.Value.Date > DateTime.Today)
            {
                return (false, "Ngày sinh không được lớn hơn ngày hiện tại!");
            }

            return (true, string.Empty);
        }
    }
}
