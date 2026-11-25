
using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class ServiceBLL
    {
        private readonly ServiceDAL _serviceDAL = new();

        // Lấy danh sách dịch vụ
        public List<ServiceDTO> GetAllServices()
        {
            return _serviceDAL.GetAll();
        }

        // Lấy dịch vụ theo ID
        public ServiceDTO? GetServiceById(int serviceID)
        {
            if (serviceID <= 0)
                return null;

            return _serviceDAL.GetById(serviceID);
        }

        // Thêm dịch vụ
        public (bool IsSuccess, string Message) AddService(ServiceDTO service)
        {
            var validation = ValidateService(service);

            if (!validation.IsValid)
                return (false, validation.Message);

            bool added = _serviceDAL.Add(service);

            return added
                ? (true, "Thêm dịch vụ thành công!")
                : (false, "Không thể thêm dịch vụ.");
        }

        // Cập nhật dịch vụ
        public (bool IsSuccess, string Message) UpdateService(ServiceDTO service)
        {
            if (service == null || service.ServiceID <= 0)
                return (false, "Vui lòng chọn dịch vụ cần cập nhật!");

            var validation = ValidateService(service);

            if (!validation.IsValid)
                return (false, validation.Message);

            bool updated = _serviceDAL.Update(service);

            return updated
                ? (true, "Cập nhật dịch vụ thành công!")
                : (false, "Không tìm thấy dịch vụ cần cập nhật hoặc dữ liệu không thay đổi.");
        }

        // Xóa dịch vụ
        public (bool IsSuccess, string Message) DeleteService(int serviceID)
        {
            if (serviceID <= 0)
                return (false, "Mã dịch vụ không hợp lệ!");

            bool deleted = _serviceDAL.Delete(serviceID);

            return deleted
                ? (true, "Xóa dịch vụ thành công!")
                : (false, "Không tìm thấy dịch vụ cần xóa.");
        }

        // Tìm kiếm dịch vụ
        public List<ServiceDTO> SearchServices(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllServices();

            return _serviceDAL.Search(keyword.Trim());
        }

        // Kiểm tra dữ liệu dịch vụ
        private (bool IsValid, string Message) ValidateService(ServiceDTO service)
        {
            if (service == null)
                return (false, "Thông tin dịch vụ không hợp lệ!");

            if (string.IsNullOrWhiteSpace(service.ServiceName))
                return (false, "Tên dịch vụ không được để trống!");

            if (service.ServiceName.Trim().Length > 150)
                return (false, "Tên dịch vụ không được vượt quá 150 ký tự!");

            if (service.ServiceCategory?.Trim().Length > 50)
                return (false, "Danh mục không được vượt quá 50 ký tự!");

            if (service.Unit?.Trim().Length > 30)
                return (false, "Đơn vị không được vượt quá 30 ký tự!");

            if (service.UnitPrice < 0)
                return (false, "Đơn giá không được nhỏ hơn 0!");

            if (service.UnitPrice > 999999999999m)
                return (false, "Đơn giá vượt quá giới hạn cho phép!");

            if (service.UnitPrice != decimal.Truncate(service.UnitPrice))
                return (false, "Đơn giá không được chứa phần thập phân!");

            return (true, string.Empty);
        }
    }
}
