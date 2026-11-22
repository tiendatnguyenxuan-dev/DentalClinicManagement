using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormExamination : Form
    {
        private readonly ExaminationBLL _examBLL = new();
        private readonly PatientBLL _patientBLL = new();
        private readonly EmployeeBLL _empBLL = new();
        private readonly ServiceBLL _serviceBLL = new();
        private readonly MedicineBLL _medBLL = new();
        private readonly AuditLogBLL _auditBLL = new();

        private int _selectedExamId = 0;
        private int _currentPrescriptionId = 0;
        private readonly AccountDTO? _currentUser;

        // Constructor mặc định
        public FormExamination() : this(null, null)
        {
        }

        // Constructor khi mở từ Lịch hẹn (truyền lịch hẹn vào)
        public FormExamination(AppointmentDTO? appointmentFromBooking, AccountDTO? currentUser = null)
        {
            InitializeComponent();
            _currentUser = currentUser;

            if (appointmentFromBooking != null)
            {
                this.Tag = appointmentFromBooking;
            }
        }

        private void FormExamination_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadExaminationList();

            // Nếu mở từ FormAppointment
            if (this.Tag is AppointmentDTO app)
            {
                cboPatient.SelectedValue = app.PatientID;
                cboDoctor.SelectedValue = app.DoctorID;
                txtReason.Text = app.Notes ?? "Khám theo lịch hẹn";
                txtDiagnosis.Focus();
            }
        }

        private void LoadDropdowns()
        {
            try
            {
                var patients = _patientBLL.GetAllPatients();
                cboPatient.DataSource = patients;
                cboPatient.DisplayMember = "FullName";
                cboPatient.ValueMember = "PatientID";

                var emps = _empBLL.GetAll().FindAll(x => x.Position == "Doctor" || x.Position == "Admin");
                cboDoctor.DataSource = emps;
                cboDoctor.DisplayMember = "FullName";
                cboDoctor.ValueMember = "EmployeeID";

                var services = _serviceBLL.GetAllServices();
                cboService.DataSource = services;
                cboService.DisplayMember = "ServiceName";
                cboService.ValueMember = "ServiceID";

                var meds = _medBLL.GetAll();
                cboMedicine.DataSource = meds;
                cboMedicine.DisplayMember = "MedicineName";
                cboMedicine.ValueMember = "MedicineID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void LoadExaminationList()
        {
            try
            {
                dgvExaminations.AutoGenerateColumns = false;
                dgvExaminations.DataSource = null;
                dgvExaminations.DataSource = _examBLL.GetAllExaminations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khám: " + ex.Message);
            }
        }

        private void dgvExaminations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvExaminations.Rows.Count) return;
            if (dgvExaminations.Rows[e.RowIndex].DataBoundItem is ExaminationDTO exam)
            {
                _selectedExamId = exam.ExaminationID;
                txtExamID.Text = exam.ExaminationID.ToString();
                cboPatient.SelectedValue = exam.PatientID;
                cboDoctor.SelectedValue = exam.DoctorID;
                txtReason.Text = exam.ExaminationReason ?? "";
                txtDiagnosis.Text = exam.Diagnosis ?? "";
                txtConclusion.Text = exam.Conclusion ?? "";
                dtpFollowUp.Value = exam.FollowUpDate ?? DateTime.Today.AddDays(7);
                cboStatus.Text = exam.ExaminationStatus;

                btnUpdate.Enabled = true;
                btnAddService.Enabled = true;
                btnAddMedicine.Enabled = true;

                LoadExamServices();
                LoadPrescription();
            }
        }

        private void LoadExamServices()
        {
            if (_selectedExamId <= 0) return;
            dgvExamServices.AutoGenerateColumns = false;
            dgvExamServices.DataSource = null;
            dgvExamServices.DataSource = _examBLL.GetServicesByExamId(_selectedExamId);
        }

        private void LoadPrescription()
        {
            if (_selectedExamId <= 0) return;
            var pres = _medBLL.GetPrescriptionByExamId(_selectedExamId);
            if (pres != null)
            {
                _currentPrescriptionId = pres.PrescriptionID;
                dgvPrescription.AutoGenerateColumns = false;
                dgvPrescription.DataSource = null;
                dgvPrescription.DataSource = _medBLL.GetDetails(_currentPrescriptionId);
            }
            else
            {
                _currentPrescriptionId = 0;
                dgvPrescription.DataSource = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? apptId = (this.Tag is AppointmentDTO a) ? a.AppointmentID : null;

            var exam = new ExaminationDTO
            {
                PatientID = Convert.ToInt32(cboPatient.SelectedValue),
                DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                AppointmentID = apptId,
                ExaminationDate = DateTime.Now,
                ExaminationReason = txtReason.Text.Trim(),
                Diagnosis = txtDiagnosis.Text.Trim(),
                Conclusion = txtConclusion.Text.Trim(),
                FollowUpDate = dtpFollowUp.Value,
                ExaminationStatus = cboStatus.Text
            };

            var res = _examBLL.CreateExamination(exam);
            if (res.IsSuccess)
            {
                _auditBLL.Log(_currentUser?.AccountID, "INSERT", "Examination", res.Data, $"Tạo hồ sơ khám bệnh #{res.Data} cho bệnh nhân ID={exam.PatientID}");
                MessageBox.Show(res.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadExaminationList();
                ResetForm();
            }
            else
            {
                MessageBox.Show(res.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedExamId <= 0) return;
            var exam = new ExaminationDTO
            {
                ExaminationID = _selectedExamId,
                PatientID = Convert.ToInt32(cboPatient.SelectedValue),
                DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                ExaminationReason = txtReason.Text.Trim(),
                Diagnosis = txtDiagnosis.Text.Trim(),
                Conclusion = txtConclusion.Text.Trim(),
                FollowUpDate = dtpFollowUp.Value,
                ExaminationStatus = cboStatus.Text
            };

            var res = _examBLL.UpdateExamination(exam);
            if (res.IsSuccess)
            {
                _auditBLL.Log(_currentUser?.AccountID, "UPDATE", "Examination", _selectedExamId, $"Cập nhật chẩn đoán/kết luận ca khám #{_selectedExamId}");
                MessageBox.Show(res.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadExaminationList();
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (_selectedExamId <= 0)
            {
                MessageBox.Show("Vui lòng chọn hoặc lưu hồ sơ khám trước khi thêm dịch vụ!", "Thông báo");
                return;
            }

            if (cboService.SelectedItem is ServiceDTO s)
            {
                var item = new ExaminationServiceDTO
                {
                    ExaminationID = _selectedExamId,
                    ServiceID = s.ServiceID,
                    ToothNumber = txtToothNumber.Text.Trim(),
                    Quantity = (int)nudQuantity.Value,
                    UnitPrice = s.UnitPrice,
                    Notes = txtServiceNotes.Text.Trim()
                };

                var res = _examBLL.AddExaminationService(item);
                if (res.IsSuccess)
                {
                    LoadExamServices();
                    txtToothNumber.Clear();
                    txtServiceNotes.Clear();
                    nudQuantity.Value = 1;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvExamServices.CurrentRow?.DataBoundItem is ExaminationServiceDTO item)
            {
                if (MessageBox.Show("Bạn có muốn xóa dịch vụ này khỏi ca khám?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _examBLL.DeleteExaminationService(item.ExaminationServiceID);
                    LoadExamServices();
                }
            }
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            if (_selectedExamId <= 0)
            {
                MessageBox.Show("Vui lòng chọn hoặc lưu ca khám trước khi kê đơn!", "Thông báo");
                return;
            }

            // Tạo Prescription nếu chưa có
            if (_currentPrescriptionId <= 0)
            {
                var p = new PrescriptionDTO
                {
                    ExaminationID = _selectedExamId,
                    PrescriptionDate = DateTime.Today,
                    Instructions = "Theo chỉ dẫn bác sĩ",
                    PrescriptionStatus = "Draft"
                };
                var createRes = _medBLL.CreatePrescription(p);
                if (createRes.IsSuccess)
                {
                    _currentPrescriptionId = createRes.Data;
                }
                else
                {
                    MessageBox.Show(createRes.Message);
                    return;
                }
            }

            if (cboMedicine.SelectedItem is MedicineDTO med)
            {
                var detail = new PrescriptionDetailDTO
                {
                    PrescriptionID = _currentPrescriptionId,
                    MedicineID = med.MedicineID,
                    Quantity = (int)nudMedQty.Value,
                    Dosage = txtDosage.Text.Trim()
                };

                var res = _medBLL.AddDetail(detail);
                if (res.IsSuccess)
                {
                    LoadPrescription();
                    txtDosage.Clear();
                    nudMedQty.Value = 1;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }

        private void btnDeleteMed_Click(object sender, EventArgs e)
        {
            if (dgvPrescription.CurrentRow?.DataBoundItem is PrescriptionDetailDTO item)
            {
                if (MessageBox.Show($"Xóa thuốc {item.MedicineName} khỏi đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _medBLL.DeleteDetail(item.PrescriptionID, item.MedicineID);
                    LoadPrescription();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _selectedExamId = 0;
            _currentPrescriptionId = 0;
            txtExamID.Text = "(Tự động)";
            txtReason.Clear();
            txtDiagnosis.Clear();
            txtConclusion.Clear();
            btnUpdate.Enabled = false;
            btnAddService.Enabled = false;
            btnAddMedicine.Enabled = false;
            dgvExamServices.DataSource = null;
            dgvPrescription.DataSource = null;
        }
    }
}
