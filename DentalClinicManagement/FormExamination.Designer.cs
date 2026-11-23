namespace DentalClinicManagement
{
    partial class FormExamination
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
            panelTop = new Panel();
            lblTitle = new Label();
            grpExam = new GroupBox();
            btnReset = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            dtpFollowUp = new DateTimePicker();
            lblFollowUp = new Label();
            txtConclusion = new TextBox();
            lblConclusion = new Label();
            txtDiagnosis = new TextBox();
            lblDiagnosis = new Label();
            txtReason = new TextBox();
            lblReason = new Label();
            cboDoctor = new ComboBox();
            lblDoctor = new Label();
            cboPatient = new ComboBox();
            lblPatient = new Label();
            txtExamID = new TextBox();
            lblExamID = new Label();
            splitContainer = new SplitContainer();
            dgvExaminations = new DataGridView();
            colExamID = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colDoctorName = new DataGridViewTextBoxColumn();
            colExamDate = new DataGridViewTextBoxColumn();
            colDiagnosis = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            tabDetails = new TabControl();
            tabServices = new TabPage();
            grpServices = new GroupBox();
            btnDeleteService = new Button();
            btnAddService = new Button();
            txtServiceNotes = new TextBox();
            lblNotes = new Label();
            nudQuantity = new NumericUpDown();
            lblQty = new Label();
            txtToothNumber = new TextBox();
            lblTooth = new Label();
            cboService = new ComboBox();
            lblService = new Label();
            dgvExamServices = new DataGridView();
            colES_ID = new DataGridViewTextBoxColumn();
            colES_Name = new DataGridViewTextBoxColumn();
            colES_Tooth = new DataGridViewTextBoxColumn();
            colES_Qty = new DataGridViewTextBoxColumn();
            colES_Price = new DataGridViewTextBoxColumn();
            tabPrescription = new TabPage();
            grpPrescription = new GroupBox();
            btnDeleteMed = new Button();
            btnAddMedicine = new Button();
            txtDosage = new TextBox();
            lblDosage = new Label();
            nudMedQty = new NumericUpDown();
            lblMedQty = new Label();
            cboMedicine = new ComboBox();
            lblMed = new Label();
            dgvPrescription = new DataGridView();
            colP_ID = new DataGridViewTextBoxColumn();
            colP_Name = new DataGridViewTextBoxColumn();
            colP_Unit = new DataGridViewTextBoxColumn();
            colP_Qty = new DataGridViewTextBoxColumn();
            colP_Dosage = new DataGridViewTextBoxColumn();
            colP_Price = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExaminations).BeginInit();
            tabDetails.SuspendLayout();
            tabServices.SuspendLayout();
            grpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvExamServices).BeginInit();
            tabPrescription.SuspendLayout();
            grpPrescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMedQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrescription).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(41, 128, 185);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1250, 50);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(450, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HỒ SƠ KHÁM BỆNH, ĐIỀU TRỊ & KÊ ĐƠN";
            // 
            // grpExam
            // 
            grpExam.Controls.Add(btnReset);
            grpExam.Controls.Add(btnUpdate);
            grpExam.Controls.Add(btnSave);
            grpExam.Controls.Add(cboStatus);
            grpExam.Controls.Add(lblStatus);
            grpExam.Controls.Add(dtpFollowUp);
            grpExam.Controls.Add(lblFollowUp);
            grpExam.Controls.Add(txtConclusion);
            grpExam.Controls.Add(lblConclusion);
            grpExam.Controls.Add(txtDiagnosis);
            grpExam.Controls.Add(lblDiagnosis);
            grpExam.Controls.Add(txtReason);
            grpExam.Controls.Add(lblReason);
            grpExam.Controls.Add(cboDoctor);
            grpExam.Controls.Add(lblDoctor);
            grpExam.Controls.Add(cboPatient);
            grpExam.Controls.Add(lblPatient);
            grpExam.Controls.Add(txtExamID);
            grpExam.Controls.Add(lblExamID);
            grpExam.Dock = DockStyle.Top;
            grpExam.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            grpExam.Location = new Point(0, 50);
            grpExam.Name = "grpExam";
            grpExam.Size = new Size(1250, 195);
            grpExam.TabIndex = 1;
            grpExam.TabStop = false;
            grpExam.Text = "Thông tin phiếu khám";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.LightSlateGray;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(1080, 145);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(130, 36);
            btnReset.TabIndex = 18;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkOrange;
            btnUpdate.Enabled = false;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(940, 145);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 36);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.ForestGreen;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(800, 145);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 36);
            btnSave.TabIndex = 16;
            btnSave.Text = "Lưu hồ sơ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Draft", "Finalized" });
            cboStatus.Location = new Point(480, 148);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(200, 28);
            cboStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(390, 152);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Trạng thái:";
            // 
            // dtpFollowUp
            // 
            dtpFollowUp.CustomFormat = "dd/MM/yyyy";
            dtpFollowUp.Format = DateTimePickerFormat.Custom;
            dtpFollowUp.Location = new Point(115, 148);
            dtpFollowUp.Name = "dtpFollowUp";
            dtpFollowUp.Size = new Size(220, 27);
            dtpFollowUp.TabIndex = 13;
            // 
            // lblFollowUp
            // 
            lblFollowUp.AutoSize = true;
            lblFollowUp.Location = new Point(15, 152);
            lblFollowUp.Name = "lblFollowUp";
            lblFollowUp.Size = new Size(95, 20);
            lblFollowUp.TabIndex = 12;
            lblFollowUp.Text = "Hẹn tái khám:";
            // 
            // txtConclusion
            // 
            txtConclusion.Location = new Point(780, 68);
            txtConclusion.Multiline = true;
            txtConclusion.Name = "txtConclusion";
            txtConclusion.ScrollBars = ScrollBars.Vertical;
            txtConclusion.Size = new Size(430, 65);
            txtConclusion.TabIndex = 11;
            // 
            // lblConclusion
            // 
            lblConclusion.AutoSize = true;
            lblConclusion.Location = new Point(700, 71);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(68, 20);
            lblConclusion.TabIndex = 10;
            lblConclusion.Text = "Kết luận:";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.Location = new Point(115, 68);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.ScrollBars = ScrollBars.Vertical;
            txtDiagnosis.Size = new Size(565, 65);
            txtDiagnosis.TabIndex = 9;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.AutoSize = true;
            lblDiagnosis.Location = new Point(15, 71);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(90, 20);
            lblDiagnosis.TabIndex = 8;
            lblDiagnosis.Text = "Chẩn đoán:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(780, 27);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(430, 27);
            txtReason.TabIndex = 7;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(700, 30);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(73, 20);
            lblReason.TabIndex = 6;
            lblReason.Text = "Lý do khám:";
            // 
            // cboDoctor
            // 
            cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoctor.FormattingEnabled = true;
            cboDoctor.Location = new Point(480, 27);
            cboDoctor.Name = "cboDoctor";
            cboDoctor.Size = new Size(200, 28);
            cboDoctor.TabIndex = 5;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(390, 30);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(54, 20);
            lblDoctor.TabIndex = 4;
            lblDoctor.Text = "Bác sĩ:";
            // 
            // cboPatient
            // 
            cboPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPatient.FormattingEnabled = true;
            cboPatient.Location = new Point(170, 27);
            cboPatient.Name = "cboPatient";
            cboPatient.Size = new Size(180, 28);
            cboPatient.TabIndex = 3;
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(90, 30);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(82, 20);
            lblPatient.TabIndex = 2;
            lblPatient.Text = "Bệnh nhân:";
            // 
            // txtExamID
            // 
            txtExamID.Location = new Point(45, 27);
            txtExamID.Name = "txtExamID";
            txtExamID.ReadOnly = true;
            txtExamID.Size = new Size(40, 27);
            txtExamID.TabIndex = 1;
            // 
            // lblExamID
            // 
            lblExamID.AutoSize = true;
            lblExamID.Location = new Point(15, 30);
            lblExamID.Name = "lblExamID";
            lblExamID.Size = new Size(27, 20);
            lblExamID.TabIndex = 0;
            lblExamID.Text = "ID:";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 245);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvExaminations);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(tabDetails);
            splitContainer.Size = new Size(1250, 435);
            splitContainer.SplitterDistance = 560;
            splitContainer.TabIndex = 2;
            // 
            // dgvExaminations
            // 
            dgvExaminations.AllowUserToAddRows = false;
            dgvExaminations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExaminations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExaminations.Columns.AddRange(new DataGridViewColumn[] { colExamID, colPatientName, colDoctorName, colExamDate, colDiagnosis, colStatus });
            dgvExaminations.Dock = DockStyle.Fill;
            dgvExaminations.Location = new Point(0, 0);
            dgvExaminations.MultiSelect = false;
            dgvExaminations.Name = "dgvExaminations";
            dgvExaminations.ReadOnly = true;
            dgvExaminations.RowHeadersVisible = false;
            dgvExaminations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExaminations.Size = new Size(560, 435);
            dgvExaminations.TabIndex = 0;
            dgvExaminations.CellClick += dgvExaminations_CellClick;
            // 
            // colExamID
            // 
            colExamID.DataPropertyName = "ExaminationID";
            colExamID.FillWeight = 40F;
            colExamID.HeaderText = "ID";
            colExamID.Name = "colExamID";
            colExamID.ReadOnly = true;
            // 
            // colPatientName
            // 
            colPatientName.DataPropertyName = "PatientName";
            colPatientName.FillWeight = 100F;
            colPatientName.HeaderText = "Bệnh nhân";
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            // 
            // colDoctorName
            // 
            colDoctorName.DataPropertyName = "DoctorName";
            colDoctorName.FillWeight = 100F;
            colDoctorName.HeaderText = "Bác sĩ";
            colDoctorName.Name = "colDoctorName";
            colDoctorName.ReadOnly = true;
            // 
            // colExamDate
            // 
            colExamDate.DataPropertyName = "ExaminationDate";
            colExamDate.FillWeight = 85F;
            colExamDate.HeaderText = "Ngày khám";
            colExamDate.Name = "colExamDate";
            colExamDate.ReadOnly = true;
            // 
            // colDiagnosis
            // 
            colDiagnosis.DataPropertyName = "Diagnosis";
            colDiagnosis.FillWeight = 120F;
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
            // tabDetails
            // 
            tabDetails.Controls.Add(tabServices);
            tabDetails.Controls.Add(tabPrescription);
            tabDetails.Dock = DockStyle.Fill;
            tabDetails.Location = new Point(0, 0);
            tabDetails.Name = "tabDetails";
            tabDetails.SelectedIndex = 0;
            tabDetails.Size = new Size(686, 435);
            tabDetails.TabIndex = 0;
            // 
            // tabServices
            // 
            tabServices.Controls.Add(grpServices);
            tabServices.Location = new Point(4, 29);
            tabServices.Name = "tabServices";
            tabServices.Padding = new Padding(3);
            tabServices.Size = new Size(678, 402);
            tabServices.TabIndex = 0;
            tabServices.Text = "Chỉ định Dịch vụ";
            tabServices.UseVisualStyleBackColor = true;
            // 
            // grpServices
            // 
            grpServices.Controls.Add(btnDeleteService);
            grpServices.Controls.Add(btnAddService);
            grpServices.Controls.Add(txtServiceNotes);
            grpServices.Controls.Add(lblNotes);
            grpServices.Controls.Add(nudQuantity);
            grpServices.Controls.Add(lblQty);
            grpServices.Controls.Add(txtToothNumber);
            grpServices.Controls.Add(lblTooth);
            grpServices.Controls.Add(cboService);
            grpServices.Controls.Add(lblService);
            grpServices.Controls.Add(dgvExamServices);
            grpServices.Dock = DockStyle.Fill;
            grpServices.Location = new Point(3, 3);
            grpServices.Name = "grpServices";
            grpServices.Size = new Size(672, 396);
            grpServices.TabIndex = 0;
            grpServices.TabStop = false;
            grpServices.Text = "Dịch vụ nha khoa thực hiện";
            // 
            // btnDeleteService
            // 
            btnDeleteService.BackColor = Color.Crimson;
            btnDeleteService.ForeColor = Color.White;
            btnDeleteService.Location = new Point(560, 68);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(95, 30);
            btnDeleteService.TabIndex = 10;
            btnDeleteService.Text = "Xóa";
            btnDeleteService.UseVisualStyleBackColor = false;
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // btnAddService
            // 
            btnAddService.BackColor = Color.SteelBlue;
            btnAddService.Enabled = false;
            btnAddService.ForeColor = Color.White;
            btnAddService.Location = new Point(560, 27);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(95, 32);
            btnAddService.TabIndex = 9;
            btnAddService.Text = "+ Thêm DV";
            btnAddService.UseVisualStyleBackColor = false;
            btnAddService.Click += btnAddService_Click;
            // 
            // txtServiceNotes
            // 
            txtServiceNotes.Location = new Point(230, 69);
            txtServiceNotes.Name = "txtServiceNotes";
            txtServiceNotes.Size = new Size(310, 27);
            txtServiceNotes.TabIndex = 8;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(165, 72);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(61, 20);
            lblNotes.TabIndex = 7;
            lblNotes.Text = "Ghi chú:";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(70, 69);
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(80, 27);
            nudQuantity.TabIndex = 6;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(10, 72);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(54, 20);
            lblQty.TabIndex = 5;
            lblQty.Text = "SL:";
            // 
            // txtToothNumber
            // 
            txtToothNumber.Location = new Point(460, 30);
            txtToothNumber.Name = "txtToothNumber";
            txtToothNumber.Size = new Size(80, 27);
            txtToothNumber.TabIndex = 4;
            // 
            // lblTooth
            // 
            lblTooth.AutoSize = true;
            lblTooth.Location = new Point(410, 33);
            lblTooth.Name = "lblTooth";
            lblTooth.Size = new Size(44, 20);
            lblTooth.TabIndex = 3;
            lblTooth.Text = "Răng:";
            // 
            // cboService
            // 
            cboService.DropDownStyle = ComboBoxStyle.DropDownList;
            cboService.FormattingEnabled = true;
            cboService.Location = new Point(70, 30);
            cboService.Name = "cboService";
            cboService.Size = new Size(320, 28);
            cboService.TabIndex = 2;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(10, 33);
            lblService.Name = "lblService";
            lblService.Size = new Size(61, 20);
            lblService.TabIndex = 1;
            lblService.Text = "Dịch vụ:";
            // 
            // dgvExamServices
            // 
            dgvExamServices.AllowUserToAddRows = false;
            dgvExamServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvExamServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExamServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExamServices.Columns.AddRange(new DataGridViewColumn[] { colES_ID, colES_Name, colES_Tooth, colES_Qty, colES_Price });
            dgvExamServices.Location = new Point(10, 110);
            dgvExamServices.MultiSelect = false;
            dgvExamServices.Name = "dgvExamServices";
            dgvExamServices.ReadOnly = true;
            dgvExamServices.RowHeadersVisible = false;
            dgvExamServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExamServices.Size = new Size(650, 275);
            dgvExamServices.TabIndex = 0;
            // 
            // colES_ID
            // 
            colES_ID.DataPropertyName = "ExaminationServiceID";
            colES_ID.FillWeight = 40F;
            colES_ID.HeaderText = "ID";
            colES_ID.Name = "colES_ID";
            colES_ID.ReadOnly = true;
            // 
            // colES_Name
            // 
            colES_Name.DataPropertyName = "ServiceName";
            colES_Name.FillWeight = 130F;
            colES_Name.HeaderText = "Dịch vụ";
            colES_Name.Name = "colES_Name";
            colES_Name.ReadOnly = true;
            // 
            // colES_Tooth
            // 
            colES_Tooth.DataPropertyName = "ToothNumber";
            colES_Tooth.FillWeight = 50F;
            colES_Tooth.HeaderText = "Răng";
            colES_Tooth.Name = "colES_Tooth";
            colES_Tooth.ReadOnly = true;
            // 
            // colES_Qty
            // 
            colES_Qty.DataPropertyName = "Quantity";
            colES_Qty.FillWeight = 40F;
            colES_Qty.HeaderText = "SL";
            colES_Qty.Name = "colES_Qty";
            colES_Qty.ReadOnly = true;
            // 
            // colES_Price
            // 
            colES_Price.DataPropertyName = "UnitPrice";
            colES_Price.FillWeight = 80F;
            colES_Price.HeaderText = "Đơn giá";
            colES_Price.Name = "colES_Price";
            colES_Price.ReadOnly = true;
            // 
            // tabPrescription
            // 
            tabPrescription.Controls.Add(grpPrescription);
            tabPrescription.Location = new Point(4, 29);
            tabPrescription.Name = "tabPrescription";
            tabPrescription.Padding = new Padding(3);
            tabPrescription.Size = new Size(678, 402);
            tabPrescription.TabIndex = 1;
            tabPrescription.Text = "Kê Đơn Thuốc";
            tabPrescription.UseVisualStyleBackColor = true;
            // 
            // grpPrescription
            // 
            grpPrescription.Controls.Add(btnDeleteMed);
            grpPrescription.Controls.Add(btnAddMedicine);
            grpPrescription.Controls.Add(txtDosage);
            grpPrescription.Controls.Add(lblDosage);
            grpPrescription.Controls.Add(nudMedQty);
            grpPrescription.Controls.Add(lblMedQty);
            grpPrescription.Controls.Add(cboMedicine);
            grpPrescription.Controls.Add(lblMed);
            grpPrescription.Controls.Add(dgvPrescription);
            grpPrescription.Dock = DockStyle.Fill;
            grpPrescription.Location = new Point(3, 3);
            grpPrescription.Name = "grpPrescription";
            grpPrescription.Size = new Size(672, 396);
            grpPrescription.TabIndex = 0;
            grpPrescription.TabStop = false;
            grpPrescription.Text = "Đơn thuốc cho ca khám này";
            // 
            // btnDeleteMed
            // 
            btnDeleteMed.BackColor = Color.Crimson;
            btnDeleteMed.ForeColor = Color.White;
            btnDeleteMed.Location = new Point(560, 68);
            btnDeleteMed.Name = "btnDeleteMed";
            btnDeleteMed.Size = new Size(95, 30);
            btnDeleteMed.TabIndex = 8;
            btnDeleteMed.Text = "Xóa";
            btnDeleteMed.UseVisualStyleBackColor = false;
            btnDeleteMed.Click += btnDeleteMed_Click;
            // 
            // btnAddMedicine
            // 
            btnAddMedicine.BackColor = Color.ForestGreen;
            btnAddMedicine.Enabled = false;
            btnAddMedicine.ForeColor = Color.White;
            btnAddMedicine.Location = new Point(560, 27);
            btnAddMedicine.Name = "btnAddMedicine";
            btnAddMedicine.Size = new Size(95, 32);
            btnAddMedicine.TabIndex = 7;
            btnAddMedicine.Text = "+ Thêm thuốc";
            btnAddMedicine.UseVisualStyleBackColor = false;
            btnAddMedicine.Click += btnAddMedicine_Click;
            // 
            // txtDosage
            // 
            txtDosage.Location = new Point(100, 69);
            txtDosage.Name = "txtDosage";
            txtDosage.PlaceholderText = "Ví dụ: Ngày uống 2 lần, mỗi lần 1 viên sau ăn";
            txtDosage.Size = new Size(440, 27);
            txtDosage.TabIndex = 6;
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Location = new Point(10, 72);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(76, 20);
            lblDosage.TabIndex = 5;
            lblDosage.Text = "Liều dùng:";
            // 
            // nudMedQty
            // 
            nudMedQty.Location = new Point(460, 30);
            nudMedQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMedQty.Name = "nudMedQty";
            nudMedQty.Size = new Size(80, 27);
            nudMedQty.TabIndex = 4;
            nudMedQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMedQty
            // 
            lblMedQty.AutoSize = true;
            lblMedQty.Location = new Point(410, 33);
            lblMedQty.Name = "lblMedQty";
            lblMedQty.Size = new Size(31, 20);
            lblMedQty.TabIndex = 3;
            lblMedQty.Text = "SL:";
            // 
            // cboMedicine
            // 
            cboMedicine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedicine.FormattingEnabled = true;
            cboMedicine.Location = new Point(100, 30);
            cboMedicine.Name = "cboMedicine";
            cboMedicine.Size = new Size(290, 28);
            cboMedicine.TabIndex = 2;
            // 
            // lblMed
            // 
            lblMed.AutoSize = true;
            lblMed.Location = new Point(10, 33);
            lblMed.Name = "lblMed";
            lblMed.Size = new Size(86, 20);
            lblMed.TabIndex = 1;
            lblMed.Text = "Chọn thuốc:";
            // 
            // dgvPrescription
            // 
            dgvPrescription.AllowUserToAddRows = false;
            dgvPrescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPrescription.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrescription.Columns.AddRange(new DataGridViewColumn[] { colP_ID, colP_Name, colP_Unit, colP_Qty, colP_Dosage, colP_Price });
            dgvPrescription.Location = new Point(10, 110);
            dgvPrescription.MultiSelect = false;
            dgvPrescription.Name = "dgvPrescription";
            dgvPrescription.ReadOnly = true;
            dgvPrescription.RowHeadersVisible = false;
            dgvPrescription.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrescription.Size = new Size(650, 275);
            dgvPrescription.TabIndex = 0;
            // 
            // colP_ID
            // 
            colP_ID.DataPropertyName = "MedicineID";
            colP_ID.FillWeight = 40F;
            colP_ID.HeaderText = "ID";
            colP_ID.Name = "colP_ID";
            colP_ID.ReadOnly = true;
            // 
            // colP_Name
            // 
            colP_Name.DataPropertyName = "MedicineName";
            colP_Name.FillWeight = 120F;
            colP_Name.HeaderText = "Tên thuốc";
            colP_Name.Name = "colP_Name";
            colP_Name.ReadOnly = true;
            // 
            // colP_Unit
            // 
            colP_Unit.DataPropertyName = "Unit";
            colP_Unit.FillWeight = 50F;
            colP_Unit.HeaderText = "Đơn vị";
            colP_Unit.Name = "colP_Unit";
            colP_Unit.ReadOnly = true;
            // 
            // colP_Qty
            // 
            colP_Qty.DataPropertyName = "Quantity";
            colP_Qty.FillWeight = 40F;
            colP_Qty.HeaderText = "SL";
            colP_Qty.Name = "colP_Qty";
            colP_Qty.ReadOnly = true;
            // 
            // colP_Dosage
            // 
            colP_Dosage.DataPropertyName = "Dosage";
            colP_Dosage.FillWeight = 140F;
            colP_Dosage.HeaderText = "Liều dùng";
            colP_Dosage.Name = "colP_Dosage";
            colP_Dosage.ReadOnly = true;
            // 
            // colP_Price
            // 
            colP_Price.DataPropertyName = "UnitPrice";
            colP_Price.FillWeight = 70F;
            colP_Price.HeaderText = "Đơn giá";
            colP_Price.Name = "colP_Price";
            colP_Price.ReadOnly = true;
            // 
            // FormExamination
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 680);
            Controls.Add(splitContainer);
            Controls.Add(grpExam);
            Controls.Add(panelTop);
            Name = "FormExamination";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khám Bệnh & Điều Trị";
            Load += FormExamination_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpExam.ResumeLayout(false);
            grpExam.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExaminations).EndInit();
            tabDetails.ResumeLayout(false);
            tabServices.ResumeLayout(false);
            grpServices.ResumeLayout(false);
            grpServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvExamServices).EndInit();
            tabPrescription.ResumeLayout(false);
            grpPrescription.ResumeLayout(false);
            grpPrescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMedQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrescription).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpExam;
        private Label lblExamID;
        private TextBox txtExamID;
        private Label lblPatient;
        private ComboBox cboPatient;
        private Label lblDoctor;
        private ComboBox cboDoctor;
        private Label lblReason;
        private TextBox txtReason;
        private Label lblDiagnosis;
        private TextBox txtDiagnosis;
        private Label lblConclusion;
        private TextBox txtConclusion;
        private Label lblFollowUp;
        private DateTimePicker dtpFollowUp;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnReset;
        private SplitContainer splitContainer;
        private DataGridView dgvExaminations;
        private TabControl tabDetails;
        private TabPage tabServices;
        private TabPage tabPrescription;
        private GroupBox grpServices;
        private DataGridView dgvExamServices;
        private Label lblService;
        private ComboBox cboService;
        private Label lblTooth;
        private TextBox txtToothNumber;
        private Label lblQty;
        private NumericUpDown nudQuantity;
        private Label lblNotes;
        private TextBox txtServiceNotes;
        private Button btnAddService;
        private Button btnDeleteService;
        private GroupBox grpPrescription;
        private DataGridView dgvPrescription;
        private Label lblMed;
        private ComboBox cboMedicine;
        private Label lblMedQty;
        private NumericUpDown nudMedQty;
        private Label lblDosage;
        private TextBox txtDosage;
        private Button btnAddMedicine;
        private Button btnDeleteMed;
        private DataGridViewTextBoxColumn colExamID;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colDoctorName;
        private DataGridViewTextBoxColumn colExamDate;
        private DataGridViewTextBoxColumn colDiagnosis;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colES_ID;
        private DataGridViewTextBoxColumn colES_Name;
        private DataGridViewTextBoxColumn colES_Tooth;
        private DataGridViewTextBoxColumn colES_Qty;
        private DataGridViewTextBoxColumn colES_Price;
        private DataGridViewTextBoxColumn colP_ID;
        private DataGridViewTextBoxColumn colP_Name;
        private DataGridViewTextBoxColumn colP_Unit;
        private DataGridViewTextBoxColumn colP_Qty;
        private DataGridViewTextBoxColumn colP_Dosage;
        private DataGridViewTextBoxColumn colP_Price;
    }
}
