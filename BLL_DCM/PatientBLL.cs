
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

        // Lấy danh sách bệnh nhân
        public List<PatientDTO> GetAllPatients()
        {
            return _patientDAL.GetAll();
        }

        // Thêm bệnh nhân
        public (bool IsSuccess, string Message) AddPatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient, false);

            if (!validation.IsValid)
                return (false, validation.Message);

            bool added = _patientDAL.Add(patient);

            return added
                ? (true, "Thêm bệnh nhân thành công!")
                : (false, "Không thể thêm bệnh nhân.");
        }

        // Cập nhật bệnh nhân
        public (bool IsSuccess, string Message) UpdatePatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient, true);

            if (!validation.IsValid)
                return (false, validation.Message);

            bool updated = _patientDAL.Update(patient);

            return updated
                ? (true, "Cập nhật thông tin bệnh nhân thành công!")
                : (false, "Không tìm thấy bệnh nhân cần cập nhật.");
        }

        // Xóa bệnh nhân
        public (bool IsSuccess, string Message) DeletePatient(int patientID)
        {
            if (patientID <= 0)
                return (false, "Mã bệnh nhân không hợp lệ!");

            bool deleted = _patientDAL.Delete(patientID);

            return deleted
                ? (true, "Xóa bệnh nhân thành công!")
                : (false, "Không tìm thấy bệnh nhân cần xóa.");
        }

        // Tìm kiếm bệnh nhân
        public List<PatientDTO> SearchPatients(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllPatients();

            return _patientDAL.Search(keyword.Trim());
        }

        // Kiểm tra dữ liệu bệnh nhân
        private (bool IsValid, string Message) ValidatePatient(
            PatientDTO patient, bool isUpdate)
        {
            if (patient == null)
                return (false, "Thông tin bệnh nhân không hợp lệ!");

            // Khi cập nhật phải có PatientID
            if (isUpdate && patient.PatientID <= 0)
                return (false, "Mã bệnh nhân không hợp lệ!");

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(patient.FullName))
                return (false, "Họ tên bệnh nhân không được để trống!");

            if (patient.FullName.Trim().Length < 2)
                return (false, "Họ tên bệnh nhân phải có ít nhất 2 ký tự!");

            if (patient.FullName.Trim().Length > 100)
                return (false, "Họ tên bệnh nhân không được vượt quá 100 ký tự!");

            // Kiểm tra số điện thoại (không bắt buộc vì database cho phép NULL)
            if (!string.IsNullOrWhiteSpace(patient.Phone))
            {
                string phone = patient.Phone.Trim();

                if (!Regex.IsMatch(phone, @"^0\d{9}$"))
                    return (false, "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!");
            }

            // Kiểm tra ngày sinh (có thể để trống)
            if (patient.DateOfBirth.HasValue &&
                patient.DateOfBirth.Value.Date > DateTime.Today)
            {
                return (false, "Ngày sinh không được lớn hơn ngày hiện tại!");
            }

            // Kiểm tra giới tính theo ENUM trong database
            if (!string.IsNullOrWhiteSpace(patient.Gender))
            {
                if (patient.Gender != "Male" &&
                    patient.Gender != "Female" &&
                    patient.Gender != "Other")
                {
                    return (false, "Giới tính không hợp lệ!");
                }
            }

            return (true, string.Empty);
        }
    }
}
