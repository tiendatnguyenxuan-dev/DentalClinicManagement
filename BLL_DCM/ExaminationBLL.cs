using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class ExaminationBLL
    {
        private readonly ExaminationDAL _dal = new();

        public List<ExaminationDTO> GetAllExaminations() => _dal.GetAllExaminations();

        public OperationResult<int> CreateExamination(ExaminationDTO exam)
        {
            if (exam.PatientID <= 0) return OperationResult<int>.Failure("Vui lòng chọn bệnh nhân!");
            if (exam.DoctorID <= 0) return OperationResult<int>.Failure("Vui lòng chọn bác sĩ khám!");

            try
            {
                int id = _dal.InsertExamination(exam);
                return OperationResult<int>.Success(id, "Tạo hồ sơ khám thành công!");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure("Lỗi lưu hồ sơ khám: " + ex.Message);
            }
        }

        public OperationResult UpdateExamination(ExaminationDTO exam)
        {
            if (exam.ExaminationID <= 0) return OperationResult.Failure("Mã hồ sơ khám không hợp lệ!");
            try
            {
                bool ok = _dal.UpdateExamination(exam);
                return ok ? OperationResult.Success("Cập nhật thành công!") : OperationResult.Failure("Không tìm thấy hồ sơ để cập nhật!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public List<ExaminationServiceDTO> GetServicesByExamId(int examId) => _dal.GetServicesByExamId(examId);

        public OperationResult AddExaminationService(ExaminationServiceDTO item)
        {
            if (item.ExaminationID <= 0) return OperationResult.Failure("Chưa chọn ca khám!");
            if (item.ServiceID <= 0) return OperationResult.Failure("Chưa chọn dịch vụ điều trị!");
            if (item.Quantity <= 0) return OperationResult.Failure("Số lượng phải lớn hơn 0!");

            try
            {
                bool ok = _dal.AddExaminationService(item);
                return ok ? OperationResult.Success("Đã thêm dịch vụ vào ca khám!") : OperationResult.Failure("Thêm dịch vụ thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public OperationResult DeleteExaminationService(int examServiceId)
        {
            try
            {
                bool ok = _dal.DeleteExaminationService(examServiceId);
                return ok ? OperationResult.Success("Đã xóa dịch vụ!") : OperationResult.Failure("Xóa thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }
    }
}
