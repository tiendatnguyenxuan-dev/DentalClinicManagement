using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class MedicineBLL
    {
        private readonly MedicineDAL _dal = new();

        public List<MedicineDTO> GetAll() => _dal.GetAll();

        public OperationResult AddMedicine(MedicineDTO med)
        {
            if (string.IsNullOrWhiteSpace(med.MedicineName)) return OperationResult.Failure("Tên thuốc không được để trống!");
            if (med.UnitPrice < 0) return OperationResult.Failure("Đơn giá không thể âm!");
            if (med.StockQuantity < 0) return OperationResult.Failure("Số lượng tồn kho không thể âm!");

            try
            {
                bool ok = _dal.Add(med);
                return ok ? OperationResult.Success("Thêm thuốc thành công!") : OperationResult.Failure("Thêm thuốc thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public OperationResult UpdateMedicine(MedicineDTO med)
        {
            if (string.IsNullOrWhiteSpace(med.MedicineName)) return OperationResult.Failure("Tên thuốc không được để trống!");
            try
            {
                bool ok = _dal.Update(med);
                return ok ? OperationResult.Success("Cập nhật thông tin thuốc thành công!") : OperationResult.Failure("Cập nhật thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public OperationResult DeleteMedicine(int medicineId)
        {
            try
            {
                bool ok = _dal.Delete(medicineId);
                return ok ? OperationResult.Success("Đã xóa thuốc khỏi danh mục!") : OperationResult.Failure("Xóa thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        // --- Prescription ---
        public PrescriptionDTO? GetPrescriptionByExamId(int examId) => _dal.GetPrescriptionByExamId(examId);

        public OperationResult<int> CreatePrescription(PrescriptionDTO p)
        {
            try
            {
                int id = _dal.CreatePrescription(p);
                return OperationResult<int>.Success(id, "Đã tạo đơn thuốc!");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure("Lỗi: " + ex.Message);
            }
        }

        public List<PrescriptionDetailDTO> GetDetails(int pId) => _dal.GetDetails(pId);

        public OperationResult AddDetail(PrescriptionDetailDTO item)
        {
            if (item.Quantity <= 0) return OperationResult.Failure("Số lượng thuốc phải lớn hơn 0!");
            try
            {
                bool ok = _dal.AddDetail(item);
                return ok ? OperationResult.Success("Đã thêm thuốc vào đơn!") : OperationResult.Failure("Thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public OperationResult DeleteDetail(int pId, int mId)
        {
            try
            {
                bool ok = _dal.DeleteDetail(pId, mId);
                return ok ? OperationResult.Success("Đã bỏ thuốc khỏi đơn!") : OperationResult.Failure("Thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }
    }
}
