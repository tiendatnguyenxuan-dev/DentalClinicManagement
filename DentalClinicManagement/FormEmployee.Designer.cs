namespace DentalClinicManagement
{
    partial class FormEmployee
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
            btnReset = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            txtLicense = new TextBox();
            lblLicense = new Label();
            cboSpecialty = new ComboBox();
            lblSpecialty = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            cboPosition = new ComboBox();
            lblPosition = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtEmpID = new TextBox();
            lblEmpID = new Label();
            dgvEmployees = new DataGridView();
            colEmpID = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colPos = new DataGridViewTextBoxColumn();
            colSpec = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 73, 94);
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
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN SỰ & CHUYÊN KHOA BÁC SĨ";
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnReset);
            grpInfo.Controls.Add(btnUpdate);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(cboStatus);
            grpInfo.Controls.Add(lblStatus);
            grpInfo.Controls.Add(txtLicense);
            grpInfo.Controls.Add(lblLicense);
            grpInfo.Controls.Add(cboSpecialty);
            grpInfo.Controls.Add(lblSpecialty);
            grpInfo.Controls.Add(txtEmail);
            grpInfo.Controls.Add(lblEmail);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.Controls.Add(lblPhone);
            grpInfo.Controls.Add(cboPosition);
            grpInfo.Controls.Add(lblPosition);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(lblName);
            grpInfo.Controls.Add(txtEmpID);
            grpInfo.Controls.Add(lblEmpID);
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Location = new Point(0, 50);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(1000, 160);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin nhân viên";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(870, 110);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(110, 34);
            btnReset.TabIndex = 18;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkOrange;
            btnUpdate.Enabled = false;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(745, 110);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 34);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(620, 110);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 34);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "+ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Active", "Resigned" });
            cboStatus.Location = new Point(440, 114);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(150, 28);
            cboStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(350, 117);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(100, 114);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(220, 27);
            txtLicense.TabIndex = 13;
            // 
            // lblLicense
            // 
            lblLicense.AutoSize = true;
            lblLicense.Location = new Point(15, 117);
            lblLicense.Name = "lblLicense";
            lblLicense.Size = new Size(79, 20);
            lblLicense.TabIndex = 12;
            lblLicense.Text = "CCHN/Ghi:";
            // 
            // cboSpecialty
            // 
            cboSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSpecialty.FormattingEnabled = true;
            cboSpecialty.Location = new Point(780, 71);
            cboSpecialty.Name = "cboSpecialty";
            cboSpecialty.Size = new Size(200, 28);
            cboSpecialty.TabIndex = 11;
            // 
            // lblSpecialty
            // 
            lblSpecialty.AutoSize = true;
            lblSpecialty.Location = new Point(685, 74);
            lblSpecialty.Name = "lblSpecialty";
            lblSpecialty.Size = new Size(95, 20);
            lblSpecialty.TabIndex = 10;
            lblSpecialty.Text = "Chuyên khoa:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(440, 71);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(225, 27);
            txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(350, 74);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(100, 71);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 27);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(15, 74);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(52, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số ĐT:";
            // 
            // cboPosition
            // 
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "Doctor", "Admin", "Receptionist", "Cashier", "Nurse" });
            cboPosition.Location = new Point(780, 28);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(200, 28);
            cboPosition.TabIndex = 5;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(685, 31);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(57, 20);
            lblPosition.TabIndex = 4;
            lblPosition.Text = "Vai trò:";
            // 
            // txtName
            // 
            txtName.Location = new Point(280, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(385, 27);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(200, 31);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Họ và tên:";
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(100, 28);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.ReadOnly = true;
            txtEmpID.Size = new Size(80, 27);
            txtEmpID.TabIndex = 1;
            // 
            // lblEmpID
            // 
            lblEmpID.AutoSize = true;
            lblEmpID.Location = new Point(15, 31);
            lblEmpID.Name = "lblEmpID";
            lblEmpID.Size = new Size(57, 20);
            lblEmpID.TabIndex = 0;
            lblEmpID.Text = "Mã NV:";
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { colEmpID, colFullName, colPos, colSpec, colPhone, colEmail, colStatus });
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.Location = new Point(0, 210);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1000, 410);
            dgvEmployees.TabIndex = 2;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // colEmpID
            // 
            colEmpID.DataPropertyName = "EmployeeID";
            colEmpID.FillWeight = 40F;
            colEmpID.HeaderText = "ID";
            colEmpID.Name = "colEmpID";
            colEmpID.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 140F;
            colFullName.HeaderText = "Họ và tên";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colPos
            // 
            colPos.DataPropertyName = "Position";
            colPos.FillWeight = 80F;
            colPos.HeaderText = "Vị trí";
            colPos.Name = "colPos";
            colPos.ReadOnly = true;
            // 
            // colSpec
            // 
            colSpec.DataPropertyName = "SpecialtyName";
            colSpec.FillWeight = 100F;
            colSpec.HeaderText = "Chuyên khoa";
            colSpec.Name = "colSpec";
            colSpec.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Phone";
            colPhone.FillWeight = 90F;
            colPhone.HeaderText = "Điện thoại";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 110F;
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "EmploymentStatus";
            colStatus.FillWeight = 60F;
            colStatus.HeaderText = "T.Thái";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 620);
            Controls.Add(dgvEmployees);
            Controls.Add(grpInfo);
            Controls.Add(panelTop);
            Name = "FormEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Nhân sự & Chuyên khoa";
            Load += FormEmployee_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblEmpID;
        private TextBox txtEmpID;
        private Label lblName;
        private TextBox txtName;
        private Label lblPosition;
        private ComboBox cboPosition;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSpecialty;
        private ComboBox cboSpecialty;
        private Label lblLicense;
        private TextBox txtLicense;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnReset;
        private DataGridView dgvEmployees;
        private DataGridViewTextBoxColumn colEmpID;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colPos;
        private DataGridViewTextBoxColumn colSpec;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colStatus;
    }
}
