using System;
using System.Drawing;
using System.Windows.Forms;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormMain : Form
    {
        private readonly AccountDTO _currentUser;

        public FormMain(AccountDTO user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadUserInfo();
            ApplyRolePermissions();
        }

        private void LoadUserInfo()
        {
            lblUserInfo.Text = $"Xin chào: {_currentUser.FullName} | Quyền: [{_currentUser.Role}]";
            lblWelcome.Text = $"Xin chào {_currentUser.FullName} ({_currentUser.Role})!\nChúc bạn một ngày làm việc hiệu quả.";
        }

        /// <summary>
        /// Phân quyền các tính năng trên Menu theo vai trò (Role-based access control)
        /// </summary>
        private void ApplyRolePermissions()
        {
            switch (_currentUser.Role.ToUpper())
            {
                case "ADMIN":
                    // Admin có toàn quyền truy cập tất cả chức năng
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnBilling.Enabled = true;
                    btnServices.Enabled = true;
                    btnReports.Enabled = true;
                    break;

                case "DOCTOR":
                    // Bác sĩ xem bệnh nhân, lịch khám; không xem báo cáo doanh thu
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnBilling.Enabled = false;
                    btnServices.Enabled = true;
                    btnReports.Enabled = false;
                    btnReports.BackColor = Color.LightGray;
                    btnBilling.BackColor = Color.LightGray;
                    break;

                case "RECEPTIONIST":
                    // Lễ tân tiếp đón bệnh nhân, đặt hẹn, thu ngân; không xem báo cáo
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnBilling.Enabled = true;
                    btnServices.Enabled = true;
                    btnReports.Enabled = false;
                    btnReports.BackColor = Color.LightGray;
                    break;

                default:
                    btnReports.Enabled = false;
                    break;
            }
        }

        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            FormPatient formPatient = new FormPatient();
            formPatient.ShowDialog();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            FormService formService = new FormService();
            formService.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Bạn có muốn đăng xuất khỏi tài khoản này?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                this.Close(); // Đóng FormMain, FormLogin sẽ tự động hiện lại
            }
        }
    }
}

