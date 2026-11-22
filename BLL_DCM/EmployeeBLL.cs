using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL _dal = new();

        public List<EmployeeDTO> GetAll() => _dal.GetAll();
        public List<SpecialtyDTO> GetAllSpecialties() => _dal.GetAllSpecialties();

        public OperationResult Add(EmployeeDTO emp)
        {
            if (string.IsNullOrWhiteSpace(emp.FullName)) return OperationResult.Failure("Họ tên nhân viên không được để trống!");
            try
            {
                bool ok = _dal.Add(emp);
                return ok ? OperationResult.Success("Thêm nhân viên thành công!") : OperationResult.Failure("Thêm nhân viên thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public OperationResult Update(EmployeeDTO emp)
        {
            if (string.IsNullOrWhiteSpace(emp.FullName)) return OperationResult.Failure("Họ tên nhân viên không được để trống!");
            try
            {
                bool ok = _dal.Update(emp);
                return ok ? OperationResult.Success("Cập nhật nhân viên thành công!") : OperationResult.Failure("Cập nhật thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }
    }
}
