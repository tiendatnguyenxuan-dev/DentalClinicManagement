using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormService : Form
    {
        private readonly ServiceBLL _serviceBLL = new();

        public FormService()
        {
            InitializeComponent();
        }

        private void FormService_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadServiceList();
        }

        /// <summary>
        /// Tải danh sách dịch vụ lên DataGridView
        /// </summary>
        private void LoadServiceList(List<ServiceDTO>? list = null)
        {
            try
            {
                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = null;
                dgvServices.DataSource = list ?? _serviceBLL.GetAllServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải danh sách dịch vụ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa trắng form nhập liệu và đưa về trạng thái Thêm mới
        /// </summary>
        private void ResetForm()
        {
            txtServiceID.Text = "(Tự động sinh)";
            txtServiceName.Clear();
            cboCategory.SelectedIndex = -1;
            cboCategory.Text = string.Empty;
            nudUnitPrice.Value = 0;
            cboUnit.SelectedIndex = -1;
            cboUnit.Text = string.Empty;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtServiceName.Focus();
        }

        /// <summary>
        /// Đổ dữ liệu từ hàng được chọn lên form nhập
        /// </summary>
        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvServices.Rows.Count) return;

            if (dgvServices.Rows[e.RowIndex].DataBoundItem is ServiceDTO service)
            {
                txtServiceID.Text = service.ServiceID.ToString();
                txtServiceName.Text = service.ServiceName;
                cboCategory.Text = service.ServiceCategory ?? string.Empty;
                nudUnitPrice.Value = Math.Min(nudUnitPrice.Maximum, Math.Max(nudUnitPrice.Minimum, service.UnitPrice));
                cboUnit.Text = service.Unit ?? string.Empty;

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        /// <summary>
        /// Xử lý thêm dịch vụ mới
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServiceDTO newService = new ServiceDTO
            {
                ServiceName = txtServiceName.Text.Trim(),
                ServiceCategory = string.IsNullOrWhiteSpace(cboCategory.Text) ? null : cboCategory.Text.Trim(),
                UnitPrice = nudUnitPrice.Value,
                Unit = string.IsNullOrWhiteSpace(cboUnit.Text) ? null : cboUnit.Text.Trim()
            };

            var (isSuccess, message) = _serviceBLL.AddService(newService);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServiceList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý cập nhật thông tin dịch vụ
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtServiceID.Text, out int serviceId) || serviceId <= 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ServiceDTO updatedService = new ServiceDTO
            {
                ServiceID = serviceId,
                ServiceName = txtServiceName.Text.Trim(),
                ServiceCategory = string.IsNullOrWhiteSpace(cboCategory.Text) ? null : cboCategory.Text.Trim(),
                UnitPrice = nudUnitPrice.Value,
                Unit = string.IsNullOrWhiteSpace(cboUnit.Text) ? null : cboUnit.Text.Trim()
            };

            var (isSuccess, message) = _serviceBLL.UpdateService(updatedService);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServiceList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý xóa dịch vụ
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtServiceID.Text, out int serviceId) || serviceId <= 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serviceName = txtServiceName.Text.Trim();

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa dịch vụ '{serviceName}' (Mã: {serviceId}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (isSuccess, message) = _serviceBLL.DeleteService(serviceId);
                if (isSuccess)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServiceList();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Nút làm mới nhập liệu
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Tìm kiếm dịch vụ theo từ khóa
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var results = _serviceBLL.SearchServices(keyword);
            LoadServiceList(results);
        }

        /// <summary>
        /// Tải lại tất cả danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadServiceList();
            ResetForm();
        }

        /// <summary>
        /// Nhấn phím Enter trong ô tìm kiếm để kích hoạt tìm kiếm
        /// </summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
