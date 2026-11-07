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

        public List<PatientDTO> GetAllPatients()
        {
            return _patientDAL.GetAll();
        }

        public string GetNextPatientId()
        {
            return _patientDAL.GenerateNextId();
        }

        public (bool IsSuccess, string Message) AddPatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient);
            if (!validation.IsValid)
            {
                return (false, validation.Message);
            }

            if (_patientDAL.GetById(patient.PatientId) != null)
            {
                return (false, $"Mã bệnh nhân '{patient.PatientId}' đã tồn tại trong hệ thống!");
            }

            bool added = _patientDAL.Add(patient);
            return added ? (true, "Thêm bệnh nhân mới thành công!") : (false, "Không thể thêm bệnh nhân.");
        }

        public (bool IsSuccess, string Message) UpdatePatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient);
            if (!validation.IsValid)
            {
                return (false, validation.Message);
            }

            bool updated = _patientDAL.Update(patient);
            return updated ? (true, "Cập nhật thông tin bệnh nhân thành công!") : (false, "Không tìm thấy bệnh nhân để cập nhật.");
        }

        public (bool IsSuccess, string Message) DeletePatient(string patientId)
        {
            if (string.IsNullOrWhiteSpace(patientId))
            {
                return (false, "Vui lòng chọn bệnh nhân cần xóa!");
            }

            bool deleted = _patientDAL.Delete(patientId);
            return deleted ? (true, "Xóa bệnh nhân thành công!") : (false, "Không tìm thấy bệnh nhân cần xóa.");
        }

        public List<PatientDTO> SearchPatients(string keyword)
        {
            return _patientDAL.Search(keyword);
        }

        private (bool IsValid, string Message) ValidatePatient(PatientDTO patient)
        {
            if (string.IsNullOrWhiteSpace(patient.PatientId))
                return (false, "Mã bệnh nhân không được để trống!");

            if (string.IsNullOrWhiteSpace(patient.FullName))
                return (false, "Họ tên bệnh nhân không được để trống!");

            if (patient.FullName.Trim().Length < 2)
                return (false, "Họ tên bệnh nhân phải có ít nhất 2 ký tự!");

            if (string.IsNullOrWhiteSpace(patient.PhoneNumber))
                return (false, "Số điện thoại không được để trống!");

            // Kiểm tra số điện thoại: 10 chữ số, bắt đầu bằng 0
            if (!Regex.IsMatch(patient.PhoneNumber.Trim(), @"^0\d{9}$"))
                return (false, "Số điện thoại không hợp lệ! (Phải là 10 chữ số và bắt đầu bằng số 0)");

            if (patient.DateOfBirth > DateTime.Now)
                return (false, "Ngày sinh không được lớn hơn ngày hiện tại!");

            return (true, string.Empty);
        }
    }
}

