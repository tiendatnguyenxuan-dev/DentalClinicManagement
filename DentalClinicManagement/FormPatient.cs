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
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            if (cboGender.Items.Count > 0)
                cboGender.SelectedIndex = 0;

            LoadPatientList();
            ResetForm();
        }

        private void LoadPatientList(List<PatientDTO>? list = null)
        {
            try
            {
                dgvPatients.AutoGenerateColumns = false;
                dgvPatients.DataSource = null;
                dgvPatients.DataSource = list ?? _patientBLL.GetAllPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách bệnh nhân: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void ResetForm()
        {
            txtPatientId.Text = "Tự động";
            txtFullName.Clear();

            if (cboGender.Items.Count > 0)
                cboGender.SelectedIndex = 0;

            dtpDOB.Text = "";
            txtAllergies.Clear();

            txtPhone.Clear();
            txtAddress.Clear();
            txtMedicalHistory.Clear();
            txtInitialReason.Clear();

            btnAdd.Enabled = true;
            btnRegisterAndQueue.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnViewRecord.Enabled = false;

            txtFullName.Focus();
        }

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
                    dtpDOB.Text = patient.DateOfBirth.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    dtpDOB.Text = "";
                }

                txtPhone.Text = patient.Phone ?? "";
                txtAddress.Text = patient.Address ?? "";
                txtMedicalHistory.Text = patient.MedicalHistory ?? "";
                txtAllergies.Text = patient.Allergies ?? "";
                txtInitialReason.Clear();

                btnAdd.Enabled = false;
                btnRegisterAndQueue.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnViewRecord.Enabled = true;
            }
        }

        private DateTime? GetDOBFromInput()
        {
            string raw = dtpDOB.Text.Replace("_", "").Trim();
            if (string.IsNullOrWhiteSpace(raw) || raw == "//" || raw.Length < 8)
                return null;
            if (DateTime.TryParseExact(dtpDOB.Text, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dob))
                return dob;
            return null;
        }

        private PatientDTO GetPatientFromForm()
        {
            return new PatientDTO
            {
                FullName = txtFullName.Text.Trim(),
                Gender = GetDatabaseGender(),
                DateOfBirth = GetDOBFromInput(),
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                MedicalHistory = string.IsNullOrWhiteSpace(txtMedicalHistory.Text) ? null : txtMedicalHistory.Text.Trim(),
                Allergies = string.IsNullOrWhiteSpace(txtAllergies.Text) ? null : txtAllergies.Text.Trim()
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PatientDTO newPatient = GetPatientFromForm();
            var (isSuccess, message) = _patientBLL.AddPatient(newPatient);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPatientList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegisterAndQueue_Click(object sender, EventArgs e)
        {
            PatientDTO newPatient = GetPatientFromForm();
            string reason = txtInitialReason.Text.Trim();

            var (isSuccess, message, patientId) = _patientBLL.RegisterAndQueue(newPatient, reason);

            if (isSuccess)
            {
                MessageBox.Show(
                    $"{message}\n\n• Mã bệnh nhân: {patientId}\n• Lý do khám: {(string.IsNullOrWhiteSpace(reason) ? "Khám bệnh nhân mới" : reason)}\n\nBệnh nhân đã được đưa vào hàng đợi tại mục Lịch Hẹn & Khám Bệnh!",
                    "Tiếp nhận thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadPatientList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientID))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PatientDTO updatedPatient = GetPatientFromForm();
            updatedPatient.PatientID = patientID;

            var (isSuccess, message) = _patientBLL.UpdatePatient(updatedPatient);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPatientList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text, out int patientID))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bệnh nhân '{fullName}' (Mã BN: {patientID}) khỏi danh sách?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (isSuccess, message) = _patientBLL.DeletePatient(patientID);

                if (isSuccess)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPatientList();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var results = _patientBLL.SearchPatients(keyword);
            LoadPatientList(results);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadPatientList();
            ResetForm();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            OpenMedicalRecordOfSelectedPatient();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPatients.Rows.Count)
            {
                if (dgvPatients.Rows[e.RowIndex].DataBoundItem is PatientDTO patient)
                {
                    OpenMedicalRecordOfSelectedPatient(patient.PatientID);
                    return;
                }
                OpenMedicalRecordOfSelectedPatient();
            }
        }

        private void OpenMedicalRecordOfSelectedPatient(int? specificPatientId = null)
        {
            int patientId = 0;
            if (specificPatientId.HasValue && specificPatientId.Value > 0)
            {
                patientId = specificPatientId.Value;
            }
            else if (dgvPatients.CurrentRow?.DataBoundItem is PatientDTO p)
            {
                patientId = p.PatientID;
            }
            else if (int.TryParse(txtPatientId.Text, out int id) && id > 0)
            {
                patientId = id;
            }

            if (patientId <= 0)
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách để xem hồ sơ bệnh án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var formRecord = new FormMedicalRecord(patientId);
            formRecord.ShowDialog();
        }
    }
}
