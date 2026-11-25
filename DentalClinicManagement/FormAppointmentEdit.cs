using BLL_DCM;
using DTO_DCM;

namespace GUI_DCM
{
    public partial class FormAppointmentEdit : Form
    {
        private readonly AppointmentBLL _appointmentBLL = new AppointmentBLL();
        private AppointmentDTO? _editingAppointment;
        private int _selectedPatientId = 0; // Lưu ID bệnh nhân đã chọn

        public FormAppointmentEdit(AppointmentDTO? appointmentToEdit = null)
        {
            InitializeComponent();
            _editingAppointment = appointmentToEdit;

            LoadDoctorsAndStatuses();

            if (_editingAppointment == null)
            {
                lblTitle.Text = "THÊM LỊCH HẸN MỚI";
                dtpDateTime.Value = DateTime.Now.AddHours(1);
                cbStatus.SelectedItem = "Pending";

                // MẶC ĐỊNH ĐỂ TRỐNG BỆNH NHÂN
                txtPatientDisplay.Text = "--- Bấm [Chọn bệnh nhân] để tìm ---";
                _selectedPatientId = 0;
            }
            else
            {
                lblTitle.Text = "CẬP NHẬT LỊCH HẸN";
                FillFormWithData(_editingAppointment);
            }
        }

        private void LoadDoctorsAndStatuses()
        {
            // Bác sĩ
            var doctors = _appointmentBLL.GetDoctorLookupList();
            cbDoctor.DataSource = doctors;
            cbDoctor.DisplayMember = "DisplayText";
            cbDoctor.ValueMember = "EmployeeID";

            // Trạng thái
            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new object[] { "Pending", "Confirmed", "Completed", "Cancelled", "NoShow" });
            cbStatus.SelectedIndex = 0;
        }

        private void FillFormWithData(AppointmentDTO app)
        {
            _selectedPatientId = app.PatientID;
            txtPatientDisplay.Text = $"{app.PatientName} - SĐT: {app.PatientPhone}";
            cbDoctor.SelectedValue = app.DoctorID;
            dtpDateTime.Value = app.AppointmentDateTime;
            cbStatus.SelectedItem = app.AppointmentStatus;
            txtNotes.Text = app.Notes ?? string.Empty;
        }

        // Sự kiện khi bấm nút "Chọn bệnh nhân"
        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            using (var lookupForm = new FormPatientLookup())
            {
                if (lookupForm.ShowDialog() == DialogResult.OK && lookupForm.SelectedPatient != null)
                {
                    _selectedPatientId = lookupForm.SelectedPatient.PatientID;
                    txtPatientDisplay.Text = lookupForm.SelectedPatient.DisplayText;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedPatientId <= 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppointmentDTO dto = _editingAppointment ?? new AppointmentDTO();
            dto.PatientID = _selectedPatientId;
            dto.DoctorID = Convert.ToInt32(cbDoctor.SelectedValue);
            dto.AppointmentDateTime = dtpDateTime.Value;
            dto.AppointmentStatus = cbStatus.SelectedItem?.ToString() ?? "Pending";
            dto.Notes = txtNotes.Text.Trim();

            OperationResult result = _editingAppointment == null
                ? _appointmentBLL.AddAppointment(dto)
                : _appointmentBLL.UpdateAppointment(dto);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}