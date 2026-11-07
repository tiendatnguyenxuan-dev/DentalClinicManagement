using DTO_DCM;
using GUI_DCM;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            string fullName = string.IsNullOrWhiteSpace(_currentUser.FullName) ? _currentUser.Username : _currentUser.FullName;
            string role = string.IsNullOrWhiteSpace(_currentUser.Role) ? "User" : _currentUser.Role;

            lblUserInfo.Text = $"Xin chào: {fullName} | Quyền: [{role}]";
            lblWelcome.Text = $"Xin chào {fullName} ({role})!\nChúc bạn một ngày làm việc hiệu quả.";
        }

        /// <summary>
        /// Phân quyền các tính năng trên Menu theo vai trò (Role-based access control)
        /// </summary>
        private void ApplyRolePermissions()
        {
            string role = (_currentUser?.Role ?? "").ToUpper();

            switch (role)
            {
                case "ADMIN":
                    // Admin có toàn quyền truy cập tất cả chức năng
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnBilling.Enabled = true;
                    btnServices.Enabled = true;
                    btnWorkSchedule.Enabled = true;
                    btnReports.Enabled = true;
                    break;

                case "DOCTOR":
                    // Bác sĩ xem bệnh nhân, lịch khám, lịch làm việc; không xem báo cáo doanh thu
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnBilling.Enabled = false;
                    btnServices.Enabled = true;
                    btnWorkSchedule.Enabled = true;
                    btnReports.Enabled = false;
                    btnReports.BackColor = Color.LightGray;
                    btnBilling.BackColor = Color.LightGray;
                    break;

                case "RECEPTIONIST":
                    // Lễ tân tiếp đón bệnh nhân, đặt hẹn, thu ngân, lịch làm việc; không xem báo cáo
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnBilling.Enabled = true;
                    btnServices.Enabled = true;
                    btnWorkSchedule.Enabled = true;
                    btnReports.Enabled = false;
                    btnReports.BackColor = Color.LightGray;
                    break;

                default:
                    btnManagePatients.Enabled = true;
                    btnAppointments.Enabled = true;
                    btnServices.Enabled = true;
                    btnWorkSchedule.Enabled = true;
                    btnBilling.Enabled = false;
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

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            FormAppointment formApp = new FormAppointment();
            formApp.ShowDialog();
        }
        private void btnWorkSchedule_Click(object sender, EventArgs e)
        {
            FormWorkSchedule form = new FormWorkSchedule();

            form.ShowDialog();
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
