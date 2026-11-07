namespace DentalClinicManagement
{
    partial class FormPatient
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
            grpInfo = new GroupBox();
            txtMedicalHistory = new TextBox();
            lblMedicalHistory = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            dtpDOB = new DateTimePicker();
            lblDOB = new Label();
            cboGender = new ComboBox();
            lblGender = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtPatientId = new TextBox();
            lblPatientId = new Label();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            pnlSearch = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvPatients = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colDOB = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colHistory = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpInfo.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.DarkSlateBlue;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 50);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(265, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ BỆNH NHÂN";
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(txtMedicalHistory);
            grpInfo.Controls.Add(lblMedicalHistory);
            grpInfo.Controls.Add(txtAddress);
            grpInfo.Controls.Add(lblAddress);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.Controls.Add(lblPhone);
            grpInfo.Controls.Add(dtpDOB);
            grpInfo.Controls.Add(lblDOB);
            grpInfo.Controls.Add(cboGender);
            grpInfo.Controls.Add(lblGender);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(txtPatientId);
            grpInfo.Controls.Add(lblPatientId);
            grpInfo.Font = new Font("Segoe UI", 9.5F);
            grpInfo.Location = new Point(15, 60);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(970, 190);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin chi tiết bệnh nhân";
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.Location = new Point(620, 110);
            txtMedicalHistory.Multiline = true;
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.PlaceholderText = "Tiền sử bệnh lý, dị ứng thuốc,...";
            txtMedicalHistory.ScrollBars = ScrollBars.Vertical;
            txtMedicalHistory.Size = new Size(330, 65);
            txtMedicalHistory.TabIndex = 13;
            // 
            // lblMedicalHistory
            // 
            lblMedicalHistory.AutoSize = true;
            lblMedicalHistory.Location = new Point(515, 115);
            lblMedicalHistory.Name = "lblMedicalHistory";
            lblMedicalHistory.Size = new Size(100, 21);
            lblMedicalHistory.TabIndex = 12;
            lblMedicalHistory.Text = "Tiền sử bệnh:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(620, 70);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Số nhà, tên đường, quận/huyện";
            txtAddress.Size = new Size(330, 29);
            txtAddress.TabIndex = 11;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(515, 75);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 21);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(620, 30);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "10 chữ số (vd: 0901234567)";
            txtPhone.Size = new Size(330, 29);
            txtPhone.TabIndex = 9;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(515, 35);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(104, 21);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Số điện thoại:";
            // 
            // dtpDOB
            // 
            dtpDOB.CustomFormat = "dd/MM/yyyy";
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.Location = new Point(130, 150);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(340, 29);
            dtpDOB.TabIndex = 7;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(20, 155);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(83, 21);
            lblDOB.TabIndex = 6;
            lblDOB.Text = "Ngày sinh:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(130, 110);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(340, 29);
            cboGender.TabIndex = 5;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(20, 115);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(73, 21);
            lblGender.TabIndex = 4;
            lblGender.Text = "Giới tính:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(130, 70);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Nhập họ và tên đầy đủ";
            txtFullName.Size = new Size(340, 29);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(20, 75);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(79, 21);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtPatientId
            // 
            txtPatientId.BackColor = Color.WhiteSmoke;
            txtPatientId.Location = new Point(130, 30);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.ReadOnly = true;
            txtPatientId.Size = new Size(340, 29);
            txtPatientId.TabIndex = 1;
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Location = new Point(20, 35);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(60, 21);
            lblPatientId.TabIndex = 0;
            lblPatientId.Text = "Mã BN:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 255);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(970, 45);
            pnlButtons.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DimGray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(480, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 35);
            btnClear.TabIndex = 3;
            btnClear.Text = " Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(320, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 35);
            btnDelete.TabIndex = 2;
            btnDelete.Text = " Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(160, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 35);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = " Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.RoyalBlue;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = " Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(btnRefresh);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(15, 305);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(970, 40);
            pnlSearch.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(560, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Tải lại tất cả";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkSlateBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(450, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(90, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên, số điện thoại hoặc mã bệnh nhân...";
            txtSearch.Size = new Size(350, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(5, 10);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colGender, colDOB, colPhone, colAddress, colHistory });
            dgvPatients.Location = new Point(15, 355);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(970, 240);
            dgvPatients.TabIndex = 4;
            dgvPatients.CellClick += dgvPatients_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "PatientId";
            colId.FillWeight = 50F;
            colId.HeaderText = "Mã BN";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "FullName";
            colName.FillWeight = 110F;
            colName.HeaderText = "Họ và Tên";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colGender
            // 
            colGender.DataPropertyName = "Gender";
            colGender.FillWeight = 45F;
            colGender.HeaderText = "Giới tính";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            // 
            // colDOB
            // 
            colDOB.DataPropertyName = "DateOfBirth";
            colDOB.FillWeight = 65F;
            colDOB.HeaderText = "Ngày sinh";
            colDOB.MinimumWidth = 6;
            colDOB.Name = "colDOB";
            colDOB.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "PhoneNumber";
            colPhone.FillWeight = 75F;
            colPhone.HeaderText = "Số điện thoại";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "Address";
            colAddress.FillWeight = 110F;
            colAddress.HeaderText = "Địa chỉ";
            colAddress.MinimumWidth = 6;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colHistory
            // 
            colHistory.DataPropertyName = "MedicalHistory";
            colHistory.FillWeight = 120F;
            colHistory.HeaderText = "Tiền sử bệnh";
            colHistory.MinimumWidth = 6;
            colHistory.Name = "colHistory";
            colHistory.ReadOnly = true;
            // 
            // FormPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 610);
            Controls.Add(dgvPatients);
            Controls.Add(pnlSearch);
            Controls.Add(pnlButtons);
            Controls.Add(grpInfo);
            Controls.Add(panelTop);
            MinimumSize = new Size(900, 600);
            Name = "FormPatient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Bệnh Nhân - Dental Clinic";
            Load += FormPatient_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblPatientId;
        private TextBox txtPatientId;
        private TextBox txtFullName;
        private Label lblFullName;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblDOB;
        private DateTimePicker dtpDOB;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtAddress;
        private Label lblAddress;
        private TextBox txtMedicalHistory;
        private Label lblMedicalHistory;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvPatients;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colDOB;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colHistory;
    }
}

