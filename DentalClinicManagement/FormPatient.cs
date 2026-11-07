
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormPatient : Form
    {
        private readonly PatientBLL _patientBLL = new();

        public FormPatient()
        {
            InitializeComponent();

            // Cho phép người dùng không nhập ngày sinh
            dtpDOB.ShowCheckBox = true;
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            if (cboGender.Items.Count > 0)
                cboGender.SelectedIndex = 0;

            LoadPatientList();
            ResetForm();
        }

        // Hiển thị danh sách bệnh nhân
        private void LoadPatientList(List<PatientDTO>? list = null)
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = list ?? _patientBLL.GetAllPatients();
        }

        // Đổi giới tính hiển thị sang giá trị ENUM trong database
        private string GetDatabaseGender()
        {
            string gender = cboGender.SelectedItem?.ToString() ?? "";

            return gender switch
            {
                "Nam" => "Male",
                "Nữ" => "Female",
                "Khác" => "Other",
                _ => gender
            };
        }

        // Đổi giá trị ENUM trong database sang tiếng Việt
        private string GetDisplayGender(string? gender)
        {
            return gender switch
            {
                "Male" => "Nam",
                "Female" => "Nữ",
                "Other" => "Khác",
                _ => ""
            };
        }

        // Làm mới form
        private void ResetForm()
        {
            // ID được MySQL tự động tạo
            txtPatientId.Text = "Tự động";

            txtFullName.Clear();

            if (cboGender.Items.Count > 0)
                cboGender.SelectedIndex = 0;

            dtpDOB.Value = DateTime.Today;
            dtpDOB.Checked = false;

            txtPhone.Clear();
            txtAddress.Clear();
            txtMedicalHistory.Clear();

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtFullName.Focus();
        }

        // Chọn bệnh nhân trên DataGridView
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPatients.Rows.Count)
                return;

            if (dgvPatients.Rows[e.RowIndex].DataBoundItem is PatientDTO patient)
            {
                txtPatientId.Text = patient.PatientID.ToString();
                txtFullName.Text = patient.FullName;

                cboGender.SelectedItem = GetDisplayGender(patient.Gender);

                if (patient.DateOfBirth.HasValue)
                {
                    dtpDOB.Value = patient.DateOfBirth.Value;
                    dtpDOB.Checked = true;
                }
                else
                {
                    dtpDOB.Value = DateTime.Today;
                    dtpDOB.Checked = false;
                }

                txtPhone.Text = patient.Phone ?? "";
                txtAddress.Text = patient.Address ?? "";
                txtMedicalHistory.Text = patient.MedicalHistory ?? "";

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        // Tạo đối tượng PatientDTO từ dữ liệu trên form
        private PatientDTO GetPatientFromForm()
        {
            return new PatientDTO
            {
                FullName = txtFullName.Text.Trim(),
                Gender = GetDatabaseGender(),
                DateOfBirth = dtpDOB.Checked
                    ? dtpDOB.Value.Date
                    : null,
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text)
                    ? null
                    : txtPhone.Text.Trim(),
                Address = string.IsNullOrWhiteSpace(txtAddress.Text)
                    ? null
                    : txtAddress.Text.Trim(),
                MedicalHistory = string.IsNullOrWhiteSpace(txtMedicalHistory.Text)
                    ? null
                    : txtMedicalHistory.Text.Trim()
            };
        }

        // Thêm bệnh nhân
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PatientDTO newPatient = GetPatientFromForm();

            var (isSuccess, message) = _patientBLL.AddPatient(newPatient);

            if (isSuccess)
            {
                MessageBox.Show(
                    message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadPatientList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Cập nhật bệnh nhân
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientID))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần cập nhật!");
                return;
            }

            PatientDTO updatedPatient = GetPatientFromForm();
            updatedPatient.PatientID = patientID;

            var (isSuccess, message) = _patientBLL.UpdatePatient(updatedPatient);

            if (isSuccess)
            {
                MessageBox.Show(
                    message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadPatientList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Xóa bệnh nhân
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientID))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa!");
                return;
            }

            string fullName = txtFullName.Text.Trim();

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bệnh nhân '{fullName}' (Mã: {patientID}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (isSuccess, message) = _patientBLL.DeletePatient(patientID);

                if (isSuccess)
                {
                    MessageBox.Show(
                        message,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadPatientList();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(
                        message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // Làm mới form
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        // Tìm kiếm bệnh nhân
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            var results = _patientBLL.SearchPatients(keyword);

            LoadPatientList(results);
        }

        // Tải lại danh sách
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadPatientList();
            ResetForm();
        }

        // Nhấn Enter để tìm kiếm
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
