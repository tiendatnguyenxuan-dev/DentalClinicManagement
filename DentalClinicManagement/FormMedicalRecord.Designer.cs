namespace DentalClinicManagement
{
    partial class FormMedicalRecord
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            grpPatientSummary = new GroupBox();
            lblRecordCodeTag = new Label();
            lblRecordCodeVal = new Label();
            lblCreatedDateTag = new Label();
            lblCreatedDateVal = new Label();
            lblStatusTag = new Label();
            lblStatusVal = new Label();
            lblPatientNameTag = new Label();
            lblPatientNameVal = new Label();
            lblGenderTag = new Label();
            lblGenderVal = new Label();
            lblDOBTag = new Label();
            lblDOBVal = new Label();
            lblPhoneTag = new Label();
            lblPhoneVal = new Label();
            lblAddressTag = new Label();
            lblAddressVal = new Label();
            lblAllergiesTag = new Label();
            lblAllergiesVal = new Label();
            lblMedicalHistoryTag = new Label();
            lblMedicalHistoryVal = new Label();
            grpExamList = new GroupBox();
            dgvExamHistory = new DataGridView();
            colExamID = new DataGridViewTextBoxColumn();
            colExamDate = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colDiagnosis = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            grpExamDetail = new GroupBox();
            lblDoctorTag = new Label();
            lblDoctorVal = new Label();
            lblExamDateTag = new Label();
            lblExamDateVal = new Label();
            lblFollowUpTag = new Label();
            lblFollowUpVal = new Label();
            lblReason = new Label();
            txtReason = new TextBox();
            lblDiagnosis = new Label();
            txtDiagnosis = new TextBox();
            lblConclusion = new Label();
            txtConclusion = new TextBox();
            tabExamInfo = new TabControl();
            tabServices = new TabPage();
            dgvServices = new DataGridView();
            colServiceName = new DataGridViewTextBoxColumn();
            colTooth = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            tabPrescription = new TabPage();
            dgvPrescription = new DataGridView();
            colMedName = new DataGridViewTextBoxColumn();
            colMedQty = new DataGridViewTextBoxColumn();
            colDosage = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            grpPatientSummary.SuspendLayout();
            grpExamList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExamHistory).BeginInit();
            grpExamDetail.SuspendLayout();
            tabExamInfo.SuspendLayout();
            tabServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            tabPrescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrescription).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SteelBlue;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HỒ SƠ BỆNH ÁN & LỊCH SỬ KHÁM";
            // 
            // grpPatientSummary
            // 
            grpPatientSummary.Controls.Add(lblRecordCodeTag);
            grpPatientSummary.Controls.Add(lblRecordCodeVal);
            grpPatientSummary.Controls.Add(lblCreatedDateTag);
            grpPatientSummary.Controls.Add(lblCreatedDateVal);
            grpPatientSummary.Controls.Add(lblStatusTag);
            grpPatientSummary.Controls.Add(lblStatusVal);
            grpPatientSummary.Controls.Add(lblPatientNameTag);
            grpPatientSummary.Controls.Add(lblPatientNameVal);
            grpPatientSummary.Controls.Add(lblGenderTag);
            grpPatientSummary.Controls.Add(lblGenderVal);
            grpPatientSummary.Controls.Add(lblDOBTag);
            grpPatientSummary.Controls.Add(lblDOBVal);
            grpPatientSummary.Controls.Add(lblPhoneTag);
            grpPatientSummary.Controls.Add(lblPhoneVal);
            grpPatientSummary.Controls.Add(lblAddressTag);
            grpPatientSummary.Controls.Add(lblAddressVal);
            grpPatientSummary.Controls.Add(lblAllergiesTag);
            grpPatientSummary.Controls.Add(lblAllergiesVal);
            grpPatientSummary.Controls.Add(lblMedicalHistoryTag);
            grpPatientSummary.Controls.Add(lblMedicalHistoryVal);
            grpPatientSummary.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpPatientSummary.Location = new Point(15, 58);
            grpPatientSummary.Name = "grpPatientSummary";
            grpPatientSummary.Size = new Size(1070, 115);
            grpPatientSummary.TabIndex = 1;
            grpPatientSummary.TabStop = false;
            grpPatientSummary.Text = "Thông tin hồ sơ bệnh nhân";
            // 
            // lblRecordCodeTag
            // 
            lblRecordCodeTag.AutoSize = true;
            lblRecordCodeTag.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecordCodeTag.ForeColor = Color.DarkSlateBlue;
            lblRecordCodeTag.Location = new Point(15, 25);
            lblRecordCodeTag.Name = "lblRecordCodeTag";
            lblRecordCodeTag.Size = new Size(78, 20);
            lblRecordCodeTag.Text = "Mã hồ sơ:";
            // 
            // lblRecordCodeVal
            // 
            lblRecordCodeVal.AutoSize = true;
            lblRecordCodeVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecordCodeVal.ForeColor = Color.Crimson;
            lblRecordCodeVal.Location = new Point(95, 25);
            lblRecordCodeVal.Name = "lblRecordCodeVal";
            lblRecordCodeVal.Size = new Size(80, 20);
            lblRecordCodeVal.Text = "--";
            // 
            // lblCreatedDateTag
            // 
            lblCreatedDateTag.AutoSize = true;
            lblCreatedDateTag.Font = new Font("Segoe UI", 9F);
            lblCreatedDateTag.Location = new Point(320, 25);
            lblCreatedDateTag.Name = "lblCreatedDateTag";
            lblCreatedDateTag.Size = new Size(72, 20);
            lblCreatedDateTag.Text = "Ngày lập:";
            // 
            // lblCreatedDateVal
            // 
            lblCreatedDateVal.AutoSize = true;
            lblCreatedDateVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreatedDateVal.Location = new Point(395, 25);
            lblCreatedDateVal.Name = "lblCreatedDateVal";
            lblCreatedDateVal.Size = new Size(95, 20);
            lblCreatedDateVal.Text = "--/--/----";
            // 
            // lblStatusTag
            // 
            lblStatusTag.AutoSize = true;
            lblStatusTag.Font = new Font("Segoe UI", 9F);
            lblStatusTag.Location = new Point(560, 25);
            lblStatusTag.Name = "lblStatusTag";
            lblStatusTag.Size = new Size(78, 20);
            lblStatusTag.Text = "Trạng thái:";
            // 
            // lblStatusVal
            // 
            lblStatusVal.AutoSize = true;
            lblStatusVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusVal.ForeColor = Color.ForestGreen;
            lblStatusVal.Location = new Point(640, 25);
            lblStatusVal.Name = "lblStatusVal";
            lblStatusVal.Size = new Size(53, 20);
            lblStatusVal.Text = "--";
            // 
            // lblPatientNameTag
            // 
            lblPatientNameTag.AutoSize = true;
            lblPatientNameTag.Font = new Font("Segoe UI", 9F);
            lblPatientNameTag.Location = new Point(15, 52);
            lblPatientNameTag.Name = "lblPatientNameTag";
            lblPatientNameTag.Size = new Size(76, 20);
            lblPatientNameTag.Text = "Bệnh nhân:";
            // 
            // lblPatientNameVal
            // 
            lblPatientNameVal.AutoSize = true;
            lblPatientNameVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPatientNameVal.Location = new Point(95, 52);
            lblPatientNameVal.Name = "lblPatientNameVal";
            lblPatientNameVal.Size = new Size(110, 20);
            lblPatientNameVal.Text = "--";
            // 
            // lblGenderTag
            // 
            lblGenderTag.AutoSize = true;
            lblGenderTag.Font = new Font("Segoe UI", 9F);
            lblGenderTag.Location = new Point(320, 52);
            lblGenderTag.Name = "lblGenderTag";
            lblGenderTag.Size = new Size(68, 20);
            lblGenderTag.Text = "Giới tính:";
            // 
            // lblGenderVal
            // 
            lblGenderVal.AutoSize = true;
            lblGenderVal.Font = new Font("Segoe UI", 9F);
            lblGenderVal.Location = new Point(395, 52);
            lblGenderVal.Name = "lblGenderVal";
            lblGenderVal.Size = new Size(41, 20);
            lblGenderVal.Text = "--";
            // 
            // lblDOBTag
            // 
            lblDOBTag.AutoSize = true;
            lblDOBTag.Font = new Font("Segoe UI", 9F);
            lblDOBTag.Location = new Point(560, 52);
            lblDOBTag.Name = "lblDOBTag";
            lblDOBTag.Size = new Size(77, 20);
            lblDOBTag.Text = "Ngày sinh:";
            // 
            // lblDOBVal
            // 
            lblDOBVal.AutoSize = true;
            lblDOBVal.Font = new Font("Segoe UI", 9F);
            lblDOBVal.Location = new Point(640, 52);
            lblDOBVal.Name = "lblDOBVal";
            lblDOBVal.Size = new Size(85, 20);
            lblDOBVal.Text = "--/--/----";
            // 
            // lblPhoneTag
            // 
            lblPhoneTag.AutoSize = true;
            lblPhoneTag.Font = new Font("Segoe UI", 9F);
            lblPhoneTag.Location = new Point(780, 52);
            lblPhoneTag.Name = "lblPhoneTag";
            lblPhoneTag.Size = new Size(40, 20);
            lblPhoneTag.Text = "SĐT:";
            // 
            // lblPhoneVal
            // 
            lblPhoneVal.AutoSize = true;
            lblPhoneVal.Font = new Font("Segoe UI", 9F);
            lblPhoneVal.Location = new Point(830, 52);
            lblPhoneVal.Name = "lblPhoneVal";
            lblPhoneVal.Size = new Size(89, 20);
            lblPhoneVal.Text = "--";
            // 
            // lblAllergiesTag
            // 
            lblAllergiesTag.AutoSize = true;
            lblAllergiesTag.Font = new Font("Segoe UI", 9F);
            lblAllergiesTag.ForeColor = Color.Crimson;
            lblAllergiesTag.Location = new Point(15, 80);
            lblAllergiesTag.Name = "lblAllergiesTag";
            lblAllergiesTag.Size = new Size(55, 20);
            lblAllergiesTag.Text = "Dị ứng:";
            // 
            // lblAllergiesVal
            // 
            lblAllergiesVal.AutoSize = true;
            lblAllergiesVal.Font = new Font("Segoe UI", 9F);
            lblAllergiesVal.ForeColor = Color.Crimson;
            lblAllergiesVal.Location = new Point(95, 80);
            lblAllergiesVal.Name = "lblAllergiesVal";
            lblAllergiesVal.Size = new Size(76, 20);
            lblAllergiesVal.Text = "Không có";
            // 
            // lblMedicalHistoryTag
            // 
            lblMedicalHistoryTag.AutoSize = true;
            lblMedicalHistoryTag.Font = new Font("Segoe UI", 9F);
            lblMedicalHistoryTag.Location = new Point(320, 80);
            lblMedicalHistoryTag.Name = "lblMedicalHistoryTag";
            lblMedicalHistoryTag.Size = new Size(95, 20);
            lblMedicalHistoryTag.Text = "Tiền sử bệnh:";
            // 
            // lblMedicalHistoryVal
            // 
            lblMedicalHistoryVal.AutoSize = true;
            lblMedicalHistoryVal.Font = new Font("Segoe UI", 9F);
            lblMedicalHistoryVal.Location = new Point(420, 80);
            lblMedicalHistoryVal.Name = "lblMedicalHistoryVal";
            lblMedicalHistoryVal.Size = new Size(76, 20);
            lblMedicalHistoryVal.Text = "Không có";
            // 
            // lblAddressTag
            // 
            lblAddressTag.AutoSize = true;
            lblAddressTag.Font = new Font("Segoe UI", 9F);
            lblAddressTag.Location = new Point(780, 80);
            lblAddressTag.Name = "lblAddressTag";
            lblAddressTag.Size = new Size(58, 20);
            lblAddressTag.Text = "Địa chỉ:";
            // 
            // lblAddressVal
            // 
            lblAddressVal.AutoSize = true;
            lblAddressVal.Font = new Font("Segoe UI", 9F);
            lblAddressVal.Location = new Point(845, 80);
            lblAddressVal.Name = "lblAddressVal";
            lblAddressVal.Size = new Size(58, 20);
            lblAddressVal.Text = "--";
            // 
            // grpExamList
            // 
            grpExamList.Controls.Add(dgvExamHistory);
            grpExamList.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpExamList.Location = new Point(15, 180);
            grpExamList.Name = "grpExamList";
            grpExamList.Size = new Size(480, 420);
            grpExamList.TabIndex = 2;
            grpExamList.TabStop = false;
            grpExamList.Text = "Lịch sử các lần khám bệnh";
            // 
            // dgvExamHistory
            // 
            dgvExamHistory.AllowUserToAddRows = false;
            dgvExamHistory.AllowUserToDeleteRows = false;
            dgvExamHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExamHistory.BackgroundColor = Color.White;
            dgvExamHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExamHistory.Columns.AddRange(new DataGridViewColumn[] { colExamID, colExamDate, colDoctor, colDiagnosis, colStatus });
            dgvExamHistory.Dock = DockStyle.Fill;
            dgvExamHistory.Location = new Point(3, 23);
            dgvExamHistory.MultiSelect = false;
            dgvExamHistory.Name = "dgvExamHistory";
            dgvExamHistory.ReadOnly = true;
            dgvExamHistory.RowHeadersVisible = false;
            dgvExamHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExamHistory.Size = new Size(474, 394);
            dgvExamHistory.TabIndex = 0;
            dgvExamHistory.CellClick += dgvExamHistory_CellClick;
            // 
            // colExamID
            // 
            colExamID.DataPropertyName = "ExaminationID";
            colExamID.FillWeight = 40F;
            colExamID.HeaderText = "Mã";
            colExamID.Name = "colExamID";
            colExamID.ReadOnly = true;
            // 
            // colExamDate
            // 
            colExamDate.DataPropertyName = "ExaminationDate";
            colExamDate.DefaultCellStyle.Format = "dd/MM/yyyy";
            colExamDate.FillWeight = 80F;
            colExamDate.HeaderText = "Ngày khám";
            colExamDate.Name = "colExamDate";
            colExamDate.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.DataPropertyName = "DoctorName";
            colDoctor.FillWeight = 90F;
            colDoctor.HeaderText = "Bác sĩ";
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colDiagnosis
            // 
            colDiagnosis.DataPropertyName = "Diagnosis";
            colDiagnosis.FillWeight = 110F;
            colDiagnosis.HeaderText = "Chẩn đoán";
            colDiagnosis.Name = "colDiagnosis";
            colDiagnosis.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "ExaminationStatus";
            colStatus.FillWeight = 60F;
            colStatus.HeaderText = "T.Thái";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // grpExamDetail
            // 
            grpExamDetail.Controls.Add(lblDoctorTag);
            grpExamDetail.Controls.Add(lblDoctorVal);
            grpExamDetail.Controls.Add(lblExamDateTag);
            grpExamDetail.Controls.Add(lblExamDateVal);
            grpExamDetail.Controls.Add(lblFollowUpTag);
            grpExamDetail.Controls.Add(lblFollowUpVal);
            grpExamDetail.Controls.Add(lblReason);
            grpExamDetail.Controls.Add(txtReason);
            grpExamDetail.Controls.Add(lblDiagnosis);
            grpExamDetail.Controls.Add(txtDiagnosis);
            grpExamDetail.Controls.Add(lblConclusion);
            grpExamDetail.Controls.Add(txtConclusion);
            grpExamDetail.Controls.Add(tabExamInfo);
            grpExamDetail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpExamDetail.Location = new Point(505, 180);
            grpExamDetail.Name = "grpExamDetail";
            grpExamDetail.Size = new Size(580, 420);
            grpExamDetail.TabIndex = 3;
            grpExamDetail.TabStop = false;
            grpExamDetail.Text = "Chi tiết ca khám được chọn";
            // 
            // lblDoctorTag
            // 
            lblDoctorTag.AutoSize = true;
            lblDoctorTag.Font = new Font("Segoe UI", 9F);
            lblDoctorTag.Location = new Point(15, 23);
            lblDoctorTag.Name = "lblDoctorTag";
            lblDoctorTag.Size = new Size(52, 20);
            lblDoctorTag.Text = "Bác sĩ:";
            // 
            // lblDoctorVal
            // 
            lblDoctorVal.AutoSize = true;
            lblDoctorVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDoctorVal.ForeColor = Color.DarkSlateBlue;
            lblDoctorVal.Location = new Point(68, 23);
            lblDoctorVal.Name = "lblDoctorVal";
            lblDoctorVal.Size = new Size(23, 20);
            lblDoctorVal.Text = "--";
            // 
            // lblExamDateTag
            // 
            lblExamDateTag.AutoSize = true;
            lblExamDateTag.Font = new Font("Segoe UI", 9F);
            lblExamDateTag.Location = new Point(15, 48);
            lblExamDateTag.Name = "lblExamDateTag";
            lblExamDateTag.Size = new Size(73, 20);
            lblExamDateTag.Text = "Thời gian:";
            // 
            // lblExamDateVal
            // 
            lblExamDateVal.AutoSize = true;
            lblExamDateVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblExamDateVal.Location = new Point(90, 48);
            lblExamDateVal.Name = "lblExamDateVal";
            lblExamDateVal.Size = new Size(23, 20);
            lblExamDateVal.Text = "--";
            // 
            // lblFollowUpTag
            // 
            lblFollowUpTag.AutoSize = true;
            lblFollowUpTag.Font = new Font("Segoe UI", 9F);
            lblFollowUpTag.Location = new Point(310, 48);
            lblFollowUpTag.Name = "lblFollowUpTag";
            lblFollowUpTag.Size = new Size(100, 20);
            lblFollowUpTag.Text = "Hẹn tái khám:";
            // 
            // lblFollowUpVal
            // 
            lblFollowUpVal.AutoSize = true;
            lblFollowUpVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFollowUpVal.ForeColor = Color.Crimson;
            lblFollowUpVal.Location = new Point(410, 48);
            lblFollowUpVal.Name = "lblFollowUpVal";
            lblFollowUpVal.Size = new Size(23, 20);
            lblFollowUpVal.Text = "--";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Font = new Font("Segoe UI", 9F);
            lblReason.Location = new Point(15, 78);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(82, 20);
            lblReason.Text = "Lý do khám:";
            // 
            // txtReason
            // 
            txtReason.BackColor = Color.WhiteSmoke;
            txtReason.Font = new Font("Segoe UI", 9F);
            txtReason.Location = new Point(105, 75);
            txtReason.Name = "txtReason";
            txtReason.ReadOnly = true;
            txtReason.Size = new Size(460, 27);
            txtReason.TabIndex = 1;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.AutoSize = true;
            lblDiagnosis.Font = new Font("Segoe UI", 9F);
            lblDiagnosis.Location = new Point(15, 110);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(84, 20);
            lblDiagnosis.Text = "Chẩn đoán:";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BackColor = Color.WhiteSmoke;
            txtDiagnosis.Font = new Font("Segoe UI", 9F);
            txtDiagnosis.Location = new Point(105, 107);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.ReadOnly = true;
            txtDiagnosis.ScrollBars = ScrollBars.Vertical;
            txtDiagnosis.Size = new Size(460, 36);
            txtDiagnosis.TabIndex = 2;
            // 
            // lblConclusion
            // 
            lblConclusion.AutoSize = true;
            lblConclusion.Font = new Font("Segoe UI", 9F);
            lblConclusion.Location = new Point(15, 151);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(67, 20);
            lblConclusion.Text = "Kết luận:";
            // 
            // txtConclusion
            // 
            txtConclusion.BackColor = Color.WhiteSmoke;
            txtConclusion.Font = new Font("Segoe UI", 9F);
            txtConclusion.Location = new Point(105, 148);
            txtConclusion.Multiline = true;
            txtConclusion.Name = "txtConclusion";
            txtConclusion.ReadOnly = true;
            txtConclusion.ScrollBars = ScrollBars.Vertical;
            txtConclusion.Size = new Size(460, 36);
            txtConclusion.TabIndex = 3;
            // 
            // tabExamInfo
            // 
            tabExamInfo.Controls.Add(tabServices);
            tabExamInfo.Controls.Add(tabPrescription);
            tabExamInfo.Font = new Font("Segoe UI", 9F);
            tabExamInfo.Location = new Point(15, 190);
            tabExamInfo.Name = "tabExamInfo";
            tabExamInfo.SelectedIndex = 0;
            tabExamInfo.Size = new Size(550, 220);
            tabExamInfo.TabIndex = 4;
            // 
            // tabServices
            // 
            tabServices.Controls.Add(dgvServices);
            tabServices.Location = new Point(4, 29);
            tabServices.Name = "tabServices";
            tabServices.Padding = new Padding(3);
            tabServices.Size = new Size(542, 197);
            tabServices.TabIndex = 0;
            tabServices.Text = "Dịch vụ đã thực hiện";
            tabServices.UseVisualStyleBackColor = true;
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.BackgroundColor = Color.White;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { colServiceName, colTooth, colQty, colPrice });
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.Location = new Point(3, 3);
            dgvServices.MultiSelect = false;
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersVisible = false;
            dgvServices.Size = new Size(536, 191);
            dgvServices.TabIndex = 0;
            // 
            // colServiceName
            // 
            colServiceName.DataPropertyName = "ServiceName";
            colServiceName.FillWeight = 130F;
            colServiceName.HeaderText = "Tên dịch vụ";
            colServiceName.Name = "colServiceName";
            colServiceName.ReadOnly = true;
            // 
            // colTooth
            // 
            colTooth.DataPropertyName = "ToothNumber";
            colTooth.FillWeight = 50F;
            colTooth.HeaderText = "Vị trí răng";
            colTooth.Name = "colTooth";
            colTooth.ReadOnly = true;
            // 
            // colQty
            // 
            colQty.DataPropertyName = "Quantity";
            colQty.FillWeight = 40F;
            colQty.HeaderText = "SL";
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "UnitPrice";
            colPrice.DefaultCellStyle.Format = "#,##0 đ";
            colPrice.FillWeight = 70F;
            colPrice.HeaderText = "Đơn giá";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // tabPrescription
            // 
            tabPrescription.Controls.Add(dgvPrescription);
            tabPrescription.Location = new Point(4, 29);
            tabPrescription.Name = "tabPrescription";
            tabPrescription.Padding = new Padding(3);
            tabPrescription.Size = new Size(542, 197);
            tabPrescription.TabIndex = 1;
            tabPrescription.Text = "Đơn thuốc đã kê";
            tabPrescription.UseVisualStyleBackColor = true;
            // 
            // dgvPrescription
            // 
            dgvPrescription.AllowUserToAddRows = false;
            dgvPrescription.AllowUserToDeleteRows = false;
            dgvPrescription.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrescription.BackgroundColor = Color.White;
            dgvPrescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrescription.Columns.AddRange(new DataGridViewColumn[] { colMedName, colMedQty, colDosage });
            dgvPrescription.Dock = DockStyle.Fill;
            dgvPrescription.Location = new Point(3, 3);
            dgvPrescription.MultiSelect = false;
            dgvPrescription.Name = "dgvPrescription";
            dgvPrescription.ReadOnly = true;
            dgvPrescription.RowHeadersVisible = false;
            dgvPrescription.Size = new Size(536, 191);
            dgvPrescription.TabIndex = 0;
            // 
            // colMedName
            // 
            colMedName.DataPropertyName = "MedicineName";
            colMedName.FillWeight = 110F;
            colMedName.HeaderText = "Tên thuốc";
            colMedName.Name = "colMedName";
            colMedName.ReadOnly = true;
            // 
            // colMedQty
            // 
            colMedQty.DataPropertyName = "Quantity";
            colMedQty.FillWeight = 40F;
            colMedQty.HeaderText = "SL";
            colMedQty.Name = "colMedQty";
            colMedQty.ReadOnly = true;
            // 
            // colDosage
            // 
            colDosage.DataPropertyName = "Dosage";
            colDosage.FillWeight = 140F;
            colDosage.HeaderText = "Liều dùng & Hướng dẫn";
            colDosage.Name = "colDosage";
            colDosage.ReadOnly = true;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.SlateGray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(965, 608);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 35);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FormMedicalRecord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 655);
            Controls.Add(btnClose);
            Controls.Add(grpExamDetail);
            Controls.Add(grpExamList);
            Controls.Add(grpPatientSummary);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormMedicalRecord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết Hồ Sơ Bệnh Án - Dental Clinic";
            Load += FormMedicalRecord_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpPatientSummary.ResumeLayout(false);
            grpPatientSummary.PerformLayout();
            grpExamList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExamHistory).EndInit();
            grpExamDetail.ResumeLayout(false);
            grpExamDetail.PerformLayout();
            tabExamInfo.ResumeLayout(false);
            tabServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            tabPrescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrescription).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private GroupBox grpPatientSummary;
        private Label lblRecordCodeTag;
        private Label lblRecordCodeVal;
        private Label lblCreatedDateTag;
        private Label lblCreatedDateVal;
        private Label lblStatusTag;
        private Label lblStatusVal;
        private Label lblPatientNameTag;
        private Label lblPatientNameVal;
        private Label lblGenderTag;
        private Label lblGenderVal;
        private Label lblDOBTag;
        private Label lblDOBVal;
        private Label lblPhoneTag;
        private Label lblPhoneVal;
        private Label lblAddressTag;
        private Label lblAddressVal;
        private Label lblAllergiesTag;
        private Label lblAllergiesVal;
        private Label lblMedicalHistoryTag;
        private Label lblMedicalHistoryVal;
        private GroupBox grpExamList;
        private DataGridView dgvExamHistory;
        private GroupBox grpExamDetail;
        private Label lblDoctorTag;
        private Label lblDoctorVal;
        private Label lblExamDateTag;
        private Label lblExamDateVal;
        private Label lblFollowUpTag;
        private Label lblFollowUpVal;
        private Label lblReason;
        private TextBox txtReason;
        private Label lblDiagnosis;
        private TextBox txtDiagnosis;
        private Label lblConclusion;
        private TextBox txtConclusion;
        private TabControl tabExamInfo;
        private TabPage tabServices;
        private DataGridView dgvServices;
        private TabPage tabPrescription;
        private DataGridView dgvPrescription;
        private Button btnClose;
        private DataGridViewTextBoxColumn colExamID;
        private DataGridViewTextBoxColumn colExamDate;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colDiagnosis;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colServiceName;
        private DataGridViewTextBoxColumn colTooth;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colMedName;
        private DataGridViewTextBoxColumn colMedQty;
        private DataGridViewTextBoxColumn colDosage;
    }
}
