using BLL_DCM;
using DTO_DCM;

namespace GUI_DCM
{
    public partial class FormAppointment : Form
    {
        private readonly AppointmentBLL _appointmentBLL = new AppointmentBLL();
        private List<AppointmentDTO> _currentList = new List<AppointmentDTO>();

        public FormAppointment()
        {
            InitializeComponent();
            InitFilterControls();
            LoadAppointments();
        }

        private void InitFilterControls()
        {
            // Nạp ComboBox trạng thái lọc
            cbFilterStatus.Items.Clear();
            cbFilterStatus.Items.Add("Tất cả");
            cbFilterStatus.Items.AddRange(new object[] { "Pending", "Confirmed", "Completed", "Cancelled", "NoShow" });
            cbFilterStatus.SelectedIndex = 0;

            // Nạp ComboBox Bác sĩ lọc
            var doctors = _appointmentBLL.GetDoctorLookupList();
            doctors.Insert(0, new DoctorLookupDTO { EmployeeID = 0, FullName = "-- Tất cả bác sĩ --" });
            cbFilterDoctor.DataSource = doctors;
            cbFilterDoctor.DisplayMember = "DisplayText";
            cbFilterDoctor.ValueMember = "EmployeeID";

            // Tắt checked mặc định cho DateTimePicker
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
        }

        private void LoadAppointments()
        {
            DateTime? fromDate = dtpFromDate.Checked ? dtpFromDate.Value : null;
            DateTime? toDate = dtpToDate.Checked ? dtpToDate.Value : null;
            string? status = cbFilterStatus.SelectedItem?.ToString();
            int? doctorId = cbFilterDoctor.SelectedValue is int id && id > 0 ? id : null;
            string keyword = txtSearch.Text.Trim();

            _currentList = _appointmentBLL.SearchAppointments(fromDate, toDate, status, doctorId, keyword);
            BindGridData(_currentList);
        }

        private void BindGridData(List<AppointmentDTO> list)
        {
            dgvAppointments.DataSource = null;
            dgvAppointments.DataSource = list;

            // Cấu hình hiển thị cột trên GridView
            if (dgvAppointments.Columns["AppointmentID"] != null) dgvAppointments.Columns["AppointmentID"]!.HeaderText = "Mã Lịch";
            if (dgvAppointments.Columns["PatientName"] != null) dgvAppointments.Columns["PatientName"]!.HeaderText = "Tên Bệnh Nhân";
            if (dgvAppointments.Columns["PatientPhone"] != null) dgvAppointments.Columns["PatientPhone"]!.HeaderText = "Số Điện Thoại";
            if (dgvAppointments.Columns["DoctorName"] != null) dgvAppointments.Columns["DoctorName"]!.HeaderText = "Bác Sĩ";
            if (dgvAppointments.Columns["SpecialtyName"] != null) dgvAppointments.Columns["SpecialtyName"]!.HeaderText = "Chuyên Khoa";
            if (dgvAppointments.Columns["AppointmentDateTime"] != null)
            {
                dgvAppointments.Columns["AppointmentDateTime"]!.HeaderText = "Thời Gian Hẹn";
                dgvAppointments.Columns["AppointmentDateTime"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvAppointments.Columns["AppointmentStatus"] != null) dgvAppointments.Columns["AppointmentStatus"]!.HeaderText = "Trạng Thái";
            if (dgvAppointments.Columns["Notes"] != null) dgvAppointments.Columns["Notes"]!.HeaderText = "Ghi Chú";

            // Ẩn các cột FK ID không cần hiển thị trực tiếp
            if (dgvAppointments.Columns["PatientID"] != null) dgvAppointments.Columns["PatientID"]!.Visible = false;
            if (dgvAppointments.Columns["DoctorID"] != null) dgvAppointments.Columns["DoctorID"]!.Visible = false;
        }

        private AppointmentDTO? GetSelectedAppointment()
        {
            if (dgvAppointments.CurrentRow == null || dgvAppointments.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return dgvAppointments.CurrentRow.DataBoundItem as AppointmentDTO;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
            cbFilterStatus.SelectedIndex = 0;
            cbFilterDoctor.SelectedIndex = 0;
            txtSearch.Clear();
            LoadAppointments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormAppointmentEdit(null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAppointments();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedAppointment();
            if (selected == null) return;

            using (var form = new FormAppointmentEdit(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAppointments();
                }
            }
        }

        private void dgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedAppointment();
            if (selected == null) return;

            // Hiển thị menu ngữ cảnh nhanh để chọn trạng thái mới
            ContextMenuStrip menu = new ContextMenuStrip();
            string[] statuses = { "Pending", "Confirmed", "Completed", "Cancelled", "NoShow" };

            foreach (var st in statuses)
            {
                var item = menu.Items.Add($"Chuyển sang: {st}");
                string currentStatus = st;
                item.Click += (s, args) =>
                {
                    var res = _appointmentBLL.UpdateStatus(selected.AppointmentID, currentStatus);
                    if (res.IsSuccess)
                    {
                        MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAppointments();
                    }
                    else
                    {
                        MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
            }

            menu.Show(btnUpdateStatus, new Point(0, btnUpdateStatus.Height));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedAppointment();
            if (selected == null) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lịch hẹn của bệnh nhân '{selected.PatientName}' lúc {selected.AppointmentDateTime:dd/MM/yyyy HH:mm} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var result = _appointmentBLL.DeleteAppointment(selected.AppointmentID);
                if (result.IsSuccess)
                {
                    MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointments();
                }
                else
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}