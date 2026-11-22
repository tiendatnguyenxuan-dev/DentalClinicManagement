using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormMedicine : Form
    {
        private readonly MedicineBLL _medBLL = new();
        private int _selectedMedId = 0;

        public FormMedicine()
        {
            InitializeComponent();
        }

        private void FormMedicine_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            ResetForm();
        }

        private void LoadMedicines()
        {
            try
            {
                dgvMedicines.AutoGenerateColumns = false;
                dgvMedicines.DataSource = null;
                dgvMedicines.DataSource = _medBLL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục thuốc: " + ex.Message);
            }
        }

        private void dgvMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMedicines.Rows.Count) return;
            if (dgvMedicines.Rows[e.RowIndex].DataBoundItem is MedicineDTO med)
            {
                _selectedMedId = med.MedicineID;
                txtMedID.Text = med.MedicineID.ToString();
                txtName.Text = med.MedicineName;
                cboUnit.Text = med.Unit ?? "";
                nudPrice.Value = med.UnitPrice;
                nudStock.Value = med.StockQuantity;

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var med = new MedicineDTO
            {
                MedicineName = txtName.Text.Trim(),
                Unit = cboUnit.Text.Trim(),
                UnitPrice = nudPrice.Value,
                StockQuantity = (int)nudStock.Value
            };

            var res = _medBLL.AddMedicine(med);
            if (res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMedicines();
                ResetForm();
            }
            else
            {
                MessageBox.Show(res.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMedId <= 0) return;
            var med = new MedicineDTO
            {
                MedicineID = _selectedMedId,
                MedicineName = txtName.Text.Trim(),
                Unit = cboUnit.Text.Trim(),
                UnitPrice = nudPrice.Value,
                StockQuantity = (int)nudStock.Value
            };

            var res = _medBLL.UpdateMedicine(med);
            if (res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMedicines();
                ResetForm();
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMedId <= 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa loại thuốc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = _medBLL.DeleteMedicine(_selectedMedId);
                if (res.IsSuccess)
                {
                    MessageBox.Show(res.Message, "Thông báo");
                    LoadMedicines();
                    ResetForm();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _selectedMedId = 0;
            txtMedID.Text = "(Tự động)";
            txtName.Clear();
            cboUnit.SelectedIndex = -1;
            nudPrice.Value = 0;
            nudStock.Value = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtName.Focus();
        }
    }
}
