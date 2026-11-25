using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormEmployee : Form
    {
        private readonly EmployeeBLL _empBLL = new();
        private int _selectedEmpId = 0;

        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            LoadSpecialties();
            LoadEmployees();
            ResetForm();
        }

        private void LoadSpecialties()
        {
            try
            {
                var specs = _empBLL.GetAllSpecialties();
                cboSpecialty.DataSource = specs;
                cboSpecialty.DisplayMember = "SpecialtyName";
                cboSpecialty.ValueMember = "SpecialtyID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chuyên khoa: " + ex.Message);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                dgvEmployees.AutoGenerateColumns = false;
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = _empBLL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEmployees.Rows.Count) return;
            if (dgvEmployees.Rows[e.RowIndex].DataBoundItem is EmployeeDTO emp)
            {
                _selectedEmpId = emp.EmployeeID;
                txtEmpID.Text = emp.EmployeeID.ToString();
                txtName.Text = emp.FullName;
                cboPosition.Text = emp.Position;
                txtPhone.Text = emp.Phone ?? "";
                txtEmail.Text = emp.Email ?? "";
                txtLicense.Text = emp.PracticeLicenseNumber ?? "";
                cboStatus.Text = emp.EmploymentStatus;
                if (emp.SpecialtyID.HasValue)
                {
                    cboSpecialty.SelectedValue = emp.SpecialtyID.Value;
                }

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var emp = new EmployeeDTO
            {
                FullName = txtName.Text.Trim(),
                Position = cboPosition.Text,
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HireDate = DateTime.Today,
                SpecialtyID = cboSpecialty.SelectedValue != null ? Convert.ToInt32(cboSpecialty.SelectedValue) : null,
                PracticeLicenseNumber = txtLicense.Text.Trim(),
                EmploymentStatus = cboStatus.Text
            };

            var res = _empBLL.Add(emp);
            if (res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
                ResetForm();
            }
            else
            {
                MessageBox.Show(res.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedEmpId <= 0) return;
            var emp = new EmployeeDTO
            {
                EmployeeID = _selectedEmpId,
                FullName = txtName.Text.Trim(),
                Position = cboPosition.Text,
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                SpecialtyID = cboSpecialty.SelectedValue != null ? Convert.ToInt32(cboSpecialty.SelectedValue) : null,
                PracticeLicenseNumber = txtLicense.Text.Trim(),
                EmploymentStatus = cboStatus.Text
            };

            var res = _empBLL.Update(emp);
            if (res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
                ResetForm();
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _selectedEmpId = 0;
            txtEmpID.Text = "(Tự động)";
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtLicense.Clear();
            cboPosition.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            txtName.Focus();
        }
    }
}
