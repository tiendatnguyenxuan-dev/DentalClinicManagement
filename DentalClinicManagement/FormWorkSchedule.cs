using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormWorkSchedule : Form
    {
        private readonly WorkScheduleBLL _workScheduleBLL = new();

        public FormWorkSchedule()
        {
            InitializeComponent();
        }

        private void FormWorkSchedule_Load(object sender, EventArgs e)
        {
            LoadDoctorList();
            ResetForm();
            LoadScheduleList();
        }

        /// <summary>
        /// Nạp danh sách bác sĩ vào ComboBox
        /// </summary>
        private void LoadDoctorList()
        {
            try
            {
                var doctors = _workScheduleBLL.GetDoctorLookupList();
                cboDoctor.DataSource = doctors;
                cboDoctor.DisplayMember = "DisplayText";
                cboDoctor.ValueMember = "EmployeeID";
                cboDoctor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải danh sách bác sĩ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách lịch làm việc lên DataGridView
        /// </summary>
        private void LoadScheduleList(List<WorkScheduleDTO>? list = null)
        {
            try
            {
                dgvSchedules.AutoGenerateColumns = false;
                dgvSchedules.DataSource = null;
                dgvSchedules.DataSource = list ?? _workScheduleBLL.GetAllSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch làm việc: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chuyển vị trí chọn ComboBox ca làm việc thành mã ca lưu vào CSDL (Morning, Afternoon, Evening)
        /// </summary>
        private string GetShiftCode()
        {
            return cboShift.SelectedIndex switch
            {
                0 => "Morning",
                1 => "Afternoon",
                2 => "Evening",
                _ => "Morning"
            };
        }

        /// <summary>
        /// Chọn đúng mục trên ComboBox khi người dùng chọn dòng trên bảng
        /// </summary>
        private void SetShiftIndex(string shift)
        {
            cboShift.SelectedIndex = shift switch
            {
                "Morning" => 0,
                "Afternoon" => 1,
                "Evening" => 2,
                _ => 0
            };
        }

        /// <summary>
        /// Xóa trắng các ô nhập và đưa về chế độ Thêm mới
        /// </summary>
        private void ResetForm()
        {
            txtScheduleID.Text = "(Tự động sinh)";
            cboDoctor.SelectedIndex = -1;
            dtpWorkDate.Value = DateTime.Today;
            cboShift.SelectedIndex = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            cboDoctor.Focus();
        }

        /// <summary>
        /// Đổ dữ liệu từ hàng được chọn lên form
        /// </summary>
        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSchedules.Rows.Count) return;

            if (dgvSchedules.Rows[e.RowIndex].DataBoundItem is WorkScheduleDTO schedule)
            {
                txtScheduleID.Text = schedule.ScheduleID.ToString();
                cboDoctor.SelectedValue = schedule.DoctorID;
                dtpWorkDate.Value = schedule.WorkDate;
                SetShiftIndex(schedule.Shift);

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        /// <summary>
        /// Xử lý thêm mới lịch làm việc
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDoctor.Focus();
                return;
            }

            WorkScheduleDTO newSchedule = new WorkScheduleDTO
            {
                DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                WorkDate = dtpWorkDate.Value.Date,
                Shift = GetShiftCode()
            };

            var (isSuccess, message) = _workScheduleBLL.AddSchedule(newSchedule);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScheduleList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý cập nhật lịch làm việc
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtScheduleID.Text, out int scheduleID) || scheduleID <= 0)
            {
                MessageBox.Show("Vui lòng chọn lịch làm việc cần cập nhật từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDoctor.Focus();
                return;
            }

            WorkScheduleDTO updatedSchedule = new WorkScheduleDTO
            {
                ScheduleID = scheduleID,
                DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                WorkDate = dtpWorkDate.Value.Date,
                Shift = GetShiftCode()
            };

            var (isSuccess, message) = _workScheduleBLL.UpdateSchedule(updatedSchedule);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScheduleList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý xóa lịch làm việc
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtScheduleID.Text, out int scheduleID) || scheduleID <= 0)
            {
                MessageBox.Show("Vui lòng chọn lịch cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string doctorName = cboDoctor.Text;
            string dateStr = dtpWorkDate.Value.ToString("dd/MM/yyyy");
            string shiftStr = cboShift.Text;

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lịch làm việc của Bác sĩ: '{doctorName}' ngày {dateStr} ({shiftStr}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (isSuccess, message) = _workScheduleBLL.DeleteSchedule(scheduleID);
                if (isSuccess)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadScheduleList();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Làm mới ô nhập
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Tìm kiếm lịch làm việc
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var results = _workScheduleBLL.SearchSchedules(keyword);
            LoadScheduleList(results);
        }

        /// <summary>
        /// Tải lại tất cả danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadScheduleList();
            ResetForm();
        }

        /// <summary>
        /// Nhấn Enter trong ô tìm kiếm
        /// </summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }
    }
}
