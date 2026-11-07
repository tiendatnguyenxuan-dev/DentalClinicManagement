using System;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class AccountBLL
    {
        private readonly AccountDAL _accountDAL = new();

        /// <summary>
        /// Xử lý nghiệp vụ đăng nhập: kiểm tra ràng buộc dữ liệu đầu vào và gọi DAL
        /// </summary>
        public (bool IsSuccess, string Message, AccountDTO? Account) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return (false, "Vui lòng nhập tên đăng nhập!", null);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Vui lòng nhập mật khẩu!", null);
            }

            AccountDTO? account = _accountDAL.CheckLogin(username.Trim(), password);
            if (account == null)
            {
                return (false, "Tên đăng nhập hoặc mật khẩu không chính xác!", null);
            }

            return (true, $"Đăng nhập thành công! Xin chào {account.FullName}.", account);
        }
    }
}

