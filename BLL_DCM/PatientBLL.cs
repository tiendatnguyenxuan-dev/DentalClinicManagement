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

        public (bool IsSuccess, string Message) AddPatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient, isUpdate: false);
            if (!validation.IsValid)
                return (false, validation.Message);

            bool added = _patientDAL.Add(patient);
            return added ? (true, "Thêm bệnh nhân thành công!") : (false, "Không thể thêm bệnh nhân.");
        }

        public (bool IsSuccess, string Message) UpdatePatient(PatientDTO patient)
        {
            var validation = ValidatePatient(patient, isUpdate: true);
            if (!validation.IsValid)
                return (false, validation.Message);

            bool updated = _patientDAL.Update(patient);
            return updated ? (true, "Cập nhật thông tin bệnh nhân thành công!") : (false, "Không tìm thấy bệnh nhân cần cập nhật.");
        }

        public (bool IsSuccess, string Message) DeletePatient(int patientID)
        {
            if (patientID <= 0)
                return (false, "Mã bệnh nhân không hợp lệ!");

            bool deleted = _patientDAL.Delete(patientID);
            return deleted ? (true, "Đã xóa bệnh nhân thành công!") : (false, "Không thể xóa bệnh nhân.");
        }

        public List<PatientDTO> SearchPatients(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllPatients();

            return _patientDAL.Search(keyword.Trim());
        }

        private (bool IsValid, string Message) ValidatePatient(PatientDTO patient, bool isUpdate)
        {
            if (patient == null)
                return (false, "Thông tin bệnh nhân không hợp lệ!");

            if (isUpdate && patient.PatientID <= 0)
                return (false, "Mã bệnh nhân không hợp lệ!");

            if (string.IsNullOrWhiteSpace(patient.FullName))
                return (false, "Họ tên bệnh nhân không được để trống!");

            if (patient.FullName.Trim().Length < 2)
                return (false, "Họ tên phải có ít nhất 2 ký tự!");

            if (!string.IsNullOrWhiteSpace(patient.Phone))
            {
                if (!Regex.IsMatch(patient.Phone.Trim(), @"^0\d{9,10}$"))
                    return (false, "Số điện thoại không đúng định dạng!");
            }

            if (patient.DateOfBirth.HasValue && patient.DateOfBirth.Value.Date > DateTime.Today)
            {
                return (false, "Ngày sinh không được lớn hơn ngày hiện tại!");
            }

            return (true, string.Empty);
        }
    }
}