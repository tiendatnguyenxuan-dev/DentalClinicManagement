using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace GUI_DCM
{
    public partial class FormAppointmentEdit : Form
    {
        private readonly AppointmentBLL _appointmentBLL = new AppointmentBLL();
        private AppointmentDTO? _editingAppointment;

        public FormAppointmentEdit(AppointmentDTO? appointmentToEdit = null)
        {
            InitializeComponent();
            _editingAppointment = appointmentToEdit;

            LoadDataComboboxes();

            if (_editingAppointment == null)
            {
                lblTitle.Text = "THÊM LỊCH HẸN MỚI";
                dtpDateTime.Value = DateTime.Now.AddHours(1);
                cbStatus.SelectedItem = "Pending";
            }
            else
            {
                lblTitle.Text = "CẬP NHẬT LỊCH HẸN";
                FillFormWithData(_editingAppointment);
            }
        }

        private void LoadDataComboboxes()
        {
            // Nạp danh sách bệnh nhân
            var patients = _appointmentBLL.GetPatientLookupList();
            cbPatient.DataSource = patients;
            cbPatient.DisplayMember = "DisplayText";
            cbPatient.ValueMember = "PatientID";

            // Nạp danh sách bác sĩ
            var doctors = _appointmentBLL.GetDoctorLookupList();
            cbDoctor.DataSource = doctors;
            cbDoctor.DisplayMember = "DisplayText";
            cbDoctor.ValueMember = "EmployeeID";

            // Nạp trạng thái
            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new object[] { "Pending", "Confirmed", "Completed", "Cancelled", "NoShow" });
            cbStatus.SelectedIndex = 0;
        }

        private void FillFormWithData(AppointmentDTO app)
        {
            cbPatient.SelectedValue = app.PatientID;
            cbDoctor.SelectedValue = app.DoctorID;
            dtpDateTime.Value = app.AppointmentDateTime;
            cbStatus.SelectedItem = app.AppointmentStatus;
            txtNotes.Text = app.Notes ?? string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbPatient.SelectedValue == null)
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
            dto.PatientID = Convert.ToInt32(cbPatient.SelectedValue);
            dto.DoctorID = Convert.ToInt32(cbDoctor.SelectedValue);
            dto.AppointmentDateTime = dtpDateTime.Value;
            dto.AppointmentStatus = cbStatus.SelectedItem?.ToString() ?? "Pending";
            dto.Notes = txtNotes.Text.Trim();

            OperationResult result;

            if (_editingAppointment == null)
            {
                result = _appointmentBLL.AddAppointment(dto);
            }
            else
            {
                result = _appointmentBLL.UpdateAppointment(dto);
            }

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