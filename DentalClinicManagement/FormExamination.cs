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
        private readonly MedicalRecordBLL _medicalRecordBLL = new();

        private int _selectedExamId = 0;
        private int _currentPrescriptionId = 0;
        private readonly AccountDTO? _currentUser;
        private bool _isLoadingPatient = false;

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

        private bool IsReadOnlyUser()
        {
            return (_currentUser?.Role ?? "").Equals("Receptionist", StringComparison.OrdinalIgnoreCase);
        }

        private void FormExamination_Load(object sender, EventArgs e)
        {
            LoadDropdowns();

            // Nếu mở từ FormAppointment
            if (this.Tag is AppointmentDTO app)
            {
                cboPatient.SelectedValue = app.PatientID;
                cboDoctor.SelectedValue = app.DoctorID;
                txtReason.Text = app.Notes ?? "Khám theo lịch hẹn";
                cboStatus.Text = "Draft";
                txtDiagnosis.Focus();
                LoadPatientHistoryAndAllergies(app.PatientID);

                // Kiểm tra xem Lịch hẹn này đã có ca khám tương ứng trong CSDL chưa
                var existingExam = _examBLL.GetByAppointmentId(app.AppointmentID);
                if (existingExam != null)
                {
                    // Lịch hẹn này đã được tạo hồ sơ khám trước đó -> Load lại chi tiết ca khám để tiếp tục chỉnh sửa / xem
                    BindExaminationDetails(existingExam);
                }
            }
            else
            {
                if (cboPatient.SelectedValue is int pId && pId > 0)
                {
                    LoadPatientHistoryAndAllergies(pId);
                }
                else
                {
                    LoadExaminationList();
                }
            }

            // Phân quyền: Receptionist chỉ được xem, không CRUD
            if (IsReadOnlyUser())
            {
                ApplyReadOnlyMode();
            }
        }

        /// <summary>
        /// Khóa/mở các ô nhập liệu tùy theo trạng thái xem hoặc chỉnh sửa.
        /// </summary>
        private void SetInputsReadOnly(bool isReadOnly)
        {
            txtReason.ReadOnly = isReadOnly;
            txtDiagnosis.ReadOnly = isReadOnly;
            txtConclusion.ReadOnly = isReadOnly;
            txtToothNumber.ReadOnly = isReadOnly;
            txtServiceNotes.ReadOnly = isReadOnly;
            txtDosage.ReadOnly = isReadOnly;
            cboPatient.Enabled = !isReadOnly;
            cboDoctor.Enabled = !isReadOnly;
            cboStatus.Enabled = !isReadOnly;
            cboService.Enabled = !isReadOnly;
            cboMedicine.Enabled = !isReadOnly;
            nudQuantity.Enabled = !isReadOnly;
            nudMedQty.Enabled = !isReadOnly;
            dtpFollowUp.Enabled = !isReadOnly;
        }

        /// <summary>
        /// Khóa toàn bộ chức năng CRUD — chỉ cho phép xem danh sách.
        /// </summary>
        private void ApplyReadOnlyMode()
        {
            this.Text = "Hồ sơ khám bệnh, điều trị & kê đơn - [CHỈ XEM]";
            lblTitle.Text = "HỒ SƠ KHÁM BỆNH, ĐIỀU TRỊ _KÊ ĐƠN - [DÀNH CHO LỄ TÂN: CHỈ XEM]";

            // Khóa các nút thao tác chính
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnReset.Enabled = false;
            btnFinishExam.Enabled = false;
            btnAddService.Enabled = false;
            btnDeleteService.Enabled = false;
            btnAddMedicine.Enabled = false;
            btnDeleteMed.Enabled = false;

            // Làm mờ màu để người dùng nhận biết chế độ chỉ xem
            btnSave.BackColor = Color.LightGray;
            btnUpdate.BackColor = Color.LightGray;
            btnReset.BackColor = Color.LightGray;
            btnFinishExam.BackColor = Color.LightGray;
            btnAddService.BackColor = Color.LightGray;
            btnDeleteService.BackColor = Color.LightGray;
            btnAddMedicine.BackColor = Color.LightGray;
            btnDeleteMed.BackColor = Color.LightGray;

            SetInputsReadOnly(true);
        }

        private void LoadDropdowns()
        {
            try
            {
                _isLoadingPatient = true;
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
            finally
            {
                _isLoadingPatient = false;
            }
        }

        private void cboPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingPatient) return;
            if (cboPatient.SelectedValue is int patientId && patientId > 0)
            {
                LoadPatientHistoryAndAllergies(patientId);
            }
        }

        private void LoadPatientHistoryAndAllergies(int patientId)
        {
            try
            {
                // 1. Hiển thị thông tin dị ứng & tiền sử bệnh của bệnh nhân
                var patient = _patientBLL.GetPatientById(patientId);
                if (patient != null)
                {
                    string allergyText = string.IsNullOrWhiteSpace(patient.Allergies) ? "Không ghi nhận" : patient.Allergies;
                    lblPatientAllergies.Text = $"[Dị ứng: {allergyText}]";

                    // Cảnh báo màu đỏ nổi bật nếu có dị ứng
                    if (!string.IsNullOrWhiteSpace(patient.Allergies) && !patient.Allergies.Equals("Không có", StringComparison.OrdinalIgnoreCase))
                    {
                        lblPatientAllergies.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblPatientAllergies.ForeColor = Color.DimGray;
                    }
                }
                else
                {
                    lblPatientAllergies.Text = "";
                }

                // 2. Tải lịch sử các lần khám trước đây của riêng bệnh nhân này
                var examList = _medicalRecordBLL.GetExaminationsByPatientId(patientId);
                dgvExaminations.AutoGenerateColumns = false;
                dgvExaminations.DataSource = null;
                dgvExaminations.DataSource = examList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử khám bệnh nhân: " + ex.Message);
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

        private void BindExaminationDetails(ExaminationDTO exam)
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

            // Chỉ enable các nút nếu không phải chế độ chỉ xem và ca khám chưa bị chốt (Finalized)
            bool isReadOnly = IsReadOnlyUser();
            bool isFinalized = string.Equals(exam.ExaminationStatus, "Finalized", StringComparison.OrdinalIgnoreCase);
            bool canEdit = !isReadOnly && !isFinalized;

            btnUpdate.Enabled = canEdit;
            btnAddService.Enabled = canEdit;
            btnAddMedicine.Enabled = canEdit;
            btnDeleteService.Enabled = canEdit;
            btnDeleteMed.Enabled = canEdit;
            btnSave.Enabled = !isReadOnly && !isFinalized;
            btnFinishExam.Enabled = !isReadOnly && !isFinalized;

            // Khóa/mở ô nhập liệu dựa trên trạng thái ca khám
            SetInputsReadOnly(!canEdit);

            LoadExamServices();
            LoadPrescription();
        }

        private void dgvExaminations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvExaminations.Rows.Count) return;
            if (dgvExaminations.Rows[e.RowIndex].DataBoundItem is ExaminationDTO exam)
            {
                BindExaminationDetails(exam);
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
            if (IsReadOnlyUser())
            {
                MessageBox.Show("Tài khoản Lễ tân chỉ có quyền xem, không được thêm hồ sơ khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? apptId = (this.Tag is AppointmentDTO a) ? a.AppointmentID : null;

            // Nếu lịch hẹn này đã có ca khám trước đó, chuyển sang chế độ cập nhật thay vì tạo trùng
            if (apptId.HasValue && apptId.Value > 0)
            {
                var existingExam = _examBLL.GetByAppointmentId(apptId.Value);
                if (existingExam != null)
                {
                    _selectedExamId = existingExam.ExaminationID;
                    btnUpdate_Click(sender, e);
                    return;
                }
            }

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
                // Tự động lưu/tạo hồ sơ bệnh án (MedicalRecord) cho bệnh nhân khi bác sĩ đã khám xong và lưu hồ sơ
                try
                {
                    var record = _medicalRecordBLL.EnsureMedicalRecordExists(exam.PatientID);
                    _auditBLL.Log(_currentUser?.AccountID, "INSERT", "MedicalRecord", record.MedicalRecordID, $"Tự động lập/cập nhật hồ sơ bệnh án mã {record.RecordCode} cho bệnh nhân ID={exam.PatientID}");
                }
                catch (Exception ex)
                {
                    // Không chặn luồng nếu tạo hồ sơ bệnh án gặp lỗi ngoài ý muốn
                    Console.WriteLine("Lỗi cập nhật hồ sơ bệnh án: " + ex.Message);
                }

                _auditBLL.Log(_currentUser?.AccountID, "INSERT", "Examination", res.Data, $"Tạo hồ sơ khám bệnh #{res.Data} cho bệnh nhân ID={exam.PatientID}");
                MessageBox.Show(res.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Giữ lại ca khám vừa tạo để bác sĩ tiếp tục chỉ định Dịch vụ & Kê đơn thuốc
                _selectedExamId = res.Data;
                txtExamID.Text = _selectedExamId.ToString();
                btnUpdate.Enabled = true;
                btnFinishExam.Enabled = true;
                btnAddService.Enabled = true;
                btnAddMedicine.Enabled = true;
                btnDeleteService.Enabled = true;
                btnDeleteMed.Enabled = true;

                LoadPatientHistoryAndAllergies(exam.PatientID);
                LoadExamServices();
                LoadPrescription();
            }
            else
            {
                MessageBox.Show(res.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsReadOnlyUser())
            {
                MessageBox.Show("Tài khoản Lễ tân chỉ có quyền xem, không được cập nhật hồ sơ khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                LoadPatientHistoryAndAllergies(exam.PatientID);
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (IsReadOnlyUser() || string.Equals(cboStatus.Text, "Finalized", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ca khám đã chốt (Finalized) hoặc bạn không có quyền thêm dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (IsReadOnlyUser() || string.Equals(cboStatus.Text, "Finalized", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ca khám đã chốt (Finalized) hoặc bạn không có quyền xóa dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (IsReadOnlyUser() || string.Equals(cboStatus.Text, "Finalized", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ca khám đã chốt (Finalized) hoặc bạn không có quyền kê đơn thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (IsReadOnlyUser() || string.Equals(cboStatus.Text, "Finalized", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ca khám đã chốt (Finalized) hoặc bạn không có quyền xóa thuốc khỏi đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPrescription.CurrentRow?.DataBoundItem is PrescriptionDetailDTO item)
            {
                if (MessageBox.Show($"Xóa thuốc {item.MedicineName} khỏi đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _medBLL.DeleteDetail(item.PrescriptionID, item.MedicineID);
                    LoadPrescription();
                }
            }
        }

        private void btnFinishExam_Click(object sender, EventArgs e)
        {
            if (IsReadOnlyUser())
            {
                MessageBox.Show("Tài khoản Lễ tân chỉ có quyền xem, không được chốt ca khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedExamId <= 0)
            {
                MessageBox.Show("Vui lòng lưu hồ sơ khám trước khi chốt ca khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn chốt ca khám này (Đã khám xong)?\n\nSau khi chốt, ca khám sẽ chuyển sang trạng thái 'Finalized' và khóa chỉnh sửa dịch vụ/đơn thuốc để chuyển sang Thu ngân.",
                "Xác nhận hoàn tất ca khám",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            cboStatus.Text = "Finalized";

            var exam = new ExaminationDTO
            {
                ExaminationID = _selectedExamId,
                PatientID = Convert.ToInt32(cboPatient.SelectedValue),
                DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                ExaminationReason = txtReason.Text.Trim(),
                Diagnosis = txtDiagnosis.Text.Trim(),
                Conclusion = txtConclusion.Text.Trim(),
                FollowUpDate = dtpFollowUp.Value,
                ExaminationStatus = "Finalized"
            };

            var res = _examBLL.UpdateExamination(exam);
            if (res.IsSuccess)
            {
                _auditBLL.Log(_currentUser?.AccountID, "UPDATE", "Examination", _selectedExamId, $"Bác sĩ hoàn tất khám (Finalized) cho ca khám #{_selectedExamId}");
                MessageBox.Show("Đã hoàn tất ca khám và chuyển trạng thái sang Finalized!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Khóa form ca khám này
                btnUpdate.Enabled = false;
                btnFinishExam.Enabled = false;
                btnAddService.Enabled = false;
                btnAddMedicine.Enabled = false;
                btnDeleteService.Enabled = false;
                btnDeleteMed.Enabled = false;
                btnSave.Enabled = false;
                SetInputsReadOnly(true);

                LoadPatientHistoryAndAllergies(exam.PatientID);
            }
            else
            {
                MessageBox.Show("Lỗi khi chốt ca khám: " + res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cboStatus.Text = "Draft";
            txtReason.Clear();
            txtDiagnosis.Clear();
            txtConclusion.Clear();
            btnUpdate.Enabled = false;
            btnFinishExam.Enabled = false;
            btnAddService.Enabled = false;
            btnAddMedicine.Enabled = false;
            btnDeleteService.Enabled = false;
            btnDeleteMed.Enabled = false;

            if (IsReadOnlyUser())
            {
                btnSave.Enabled = false;
                SetInputsReadOnly(true);
            }
            else
            {
                btnSave.Enabled = true;
                SetInputsReadOnly(false);
            }

            dgvExamServices.DataSource = null;
            dgvPrescription.DataSource = null;
        }
    }
}
