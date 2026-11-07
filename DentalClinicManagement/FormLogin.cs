using System;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormLogin : Form
    {
        private readonly AccountBLL _accountBLL = new();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtNameLogin.Text.Trim();
            string password = txtPassword.Text;

            // Gọi xử lý nghiệp vụ ở tầng BLL
            var result = _accountBLL.Login(username, password);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrWhiteSpace(username))
                {
                    txtNameLogin.Focus();
                }
                else
                {
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
                return;
            }

            MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mở giao diện chính (FormMain) và truyền thông tin tài khoản đăng nhập
            this.Hide();
            FormMain formMain = new FormMain(result.Account!);
            formMain.FormClosed += (s, args) =>
            {
                // Khi FormMain đóng, reset lại ô mật khẩu và hiện lại form đăng nhập
                txtPassword.Clear();
                this.Show();
                txtNameLogin.Focus();
            };
            formMain.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblHint_Click(object sender, EventArgs e)
        {

        }
    }
}

