using System;
using System.Collections.Generic;
using System.Linq;
using DTO_DCM;

namespace DAL_DCM
{
    public class AccountDAL
    {
        // Dữ liệu mẫu giả lập trong bộ nhớ (khi chưa kết nối CSDL)
        private static readonly List<AccountDTO> _accounts = new()
        {
            new AccountDTO("admin", "123456", "Quản Trị Viên", "Admin"),
            new AccountDTO("bacsi", "123456", "BS. Nguyễn Văn An", "Doctor"),
            new AccountDTO("letan", "123456", "Lễ Tân Trần Thị Mai", "Receptionist")
        };

        /// <summary>
        /// Kiểm tra thông tin đăng nhập.
        /// Khi kết nối SQL Server, hàm này sẽ thực thi câu lệnh SQL:
        /// SELECT * FROM Accounts WHERE Username = @u AND Password = @p
        /// </summary>
        public AccountDTO? CheckLogin(string username, string password)
        {
            return _accounts.FirstOrDefault(a =>
                a.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                a.Password == password);
        }
    }
}

