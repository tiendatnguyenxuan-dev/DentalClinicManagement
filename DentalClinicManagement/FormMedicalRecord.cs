using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormMedicalRecord : Form
    {
        private readonly int _patientId;
        private readonly MedicalRecordBLL _recordBLL = new();
        private readonly PatientBLL _patientBLL = new();
        private readonly ExaminationBLL _examBLL = new();
        private readonly MedicineBLL _medBLL = new();
        private List<ExaminationDTO> _examList = new();

        public FormMedicalRecord(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void FormMedicalRecord_Load(object sender, EventArgs e)
        {
            LoadMedicalRecordInfo();
            LoadExaminationHistory();
        }

        private void LoadMedicalRecordInfo()
        {
            // 1. Lấy thông tin cơ bản của chính bệnh nhân được chọn
            var patient = _patientBLL.GetPatientById(_patientId);
            if (patient != null)
            {
                lblPatientNameVal.Text = patient.FullName;
                lblGenderVal.Text = patient.Gender == "Male" ? "Nam" : (patient.Gender == "Female" ? "Nữ" : patient.Gender ?? "");
                lblDOBVal.Text = patient.DateOfBirth.HasValue ? patient.DateOfBirth.Value.ToString("dd/MM/yyyy") : "--/--/----";
                lblPhoneVal.Text = string.IsNullOrWhiteSpace(patient.Phone) ? "--" : patient.Phone;
                lblAddressVal.Text = string.IsNullOrWhiteSpace(patient.Address) ? "--" : patient.Address;
                lblAllergiesVal.Text = string.IsNullOrWhiteSpace(patient.Allergies) ? "Không có" : patient.Allergies;
                lblMedicalHistoryVal.Text = string.IsNullOrWhiteSpace(patient.MedicalHistory) ? "Không có" : patient.MedicalHistory;
            }
            else
            {
                lblPatientNameVal.Text = "--";
                lblGenderVal.Text = "--";
                lblDOBVal.Text = "--";
                lblPhoneVal.Text = "--";
                lblAddressVal.Text = "--";
                lblAllergiesVal.Text = "Không có";
                lblMedicalHistoryVal.Text = "Không có";
            }

            // 2. Lấy thông tin hồ sơ bệnh án (nếu đã từng lưu ca khám)
            var record = _recordBLL.GetByPatientId(_patientId);
            if (record != null)
            {
                lblRecordCodeVal.Text = record.RecordCode;
                lblRecordCodeVal.ForeColor = Color.DarkSlateBlue;
                lblCreatedDateVal.Text = record.CreatedDate.ToString("dd/MM/yyyy");
                lblStatusVal.Text = record.RecordStatus;
                lblStatusVal.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblRecordCodeVal.Text = "(Chưa lập hồ sơ - Chưa có lần khám nào được lưu)";
                lblRecordCodeVal.ForeColor = Color.Crimson;
                lblCreatedDateVal.Text = "--/--/----";
                lblStatusVal.Text = "Chưa lập";
                lblStatusVal.ForeColor = Color.Gray;
            }
        }

        private void LoadExaminationHistory()
        {
            try
            {
                _examList = _recordBLL.GetExaminationsByPatientId(_patientId);
                dgvExamHistory.AutoGenerateColumns = false;
                dgvExamHistory.DataSource = null;
                dgvExamHistory.DataSource = _examList;

                if (_examList.Count > 0)
                {
                    ShowExamDetails(_examList[0]);
                }
                else
                {
                    ClearExamDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp lịch sử khám bệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvExamHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvExamHistory.Rows.Count) return;
            if (dgvExamHistory.Rows[e.RowIndex].DataBoundItem is ExaminationDTO exam)
            {
                ShowExamDetails(exam);
            }
        }

        private void ShowExamDetails(ExaminationDTO exam)
        {
            txtReason.Text = exam.ExaminationReason ?? "";
            txtDiagnosis.Text = exam.Diagnosis ?? "";
            txtConclusion.Text = exam.Conclusion ?? "";
            lblDoctorVal.Text = exam.DoctorName ?? "";
            lblExamDateVal.Text = exam.ExaminationDate.ToString("dd/MM/yyyy HH:mm");
            lblFollowUpVal.Text = exam.FollowUpDate.HasValue ? exam.FollowUpDate.Value.ToString("dd/MM/yyyy") : "Không hẹn";

            // Nạp dịch vụ điều trị của lần khám này
            dgvServices.AutoGenerateColumns = false;
            dgvServices.DataSource = null;
            dgvServices.DataSource = _examBLL.GetServicesByExamId(exam.ExaminationID);

            // Nạp đơn thuốc của lần khám này
            var pres = _medBLL.GetPrescriptionByExamId(exam.ExaminationID);
            dgvPrescription.AutoGenerateColumns = false;
            dgvPrescription.DataSource = null;
            if (pres != null)
            {
                dgvPrescription.DataSource = _medBLL.GetDetails(pres.PrescriptionID);
            }
        }

        private void ClearExamDetails()
        {
            txtReason.Clear();
            txtDiagnosis.Clear();
            txtConclusion.Clear();
            lblDoctorVal.Text = "--";
            lblExamDateVal.Text = "--";
            lblFollowUpVal.Text = "--";
            dgvServices.DataSource = null;
            dgvPrescription.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
