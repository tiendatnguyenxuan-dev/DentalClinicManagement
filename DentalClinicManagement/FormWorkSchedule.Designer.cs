namespace DentalClinicManagement
{
    partial class FormWorkSchedule
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
            DataGridViewCellStyle dgvCellStyleDate = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            grpInfo = new GroupBox();
            cboShift = new ComboBox();
            lblShift = new Label();
            dtpWorkDate = new DateTimePicker();
            lblWorkDate = new Label();
            cboDoctor = new ComboBox();
            lblDoctor = new Label();
            txtScheduleID = new TextBox();
            lblScheduleID = new Label();
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
            dgvSchedules = new DataGridView();
            colScheduleID = new DataGridViewTextBoxColumn();
            colDoctorID = new DataGridViewTextBoxColumn();
            colDoctorName = new DataGridViewTextBoxColumn();
            colWorkDate = new DataGridViewTextBoxColumn();
            colShift = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpInfo.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.DarkSlateBlue;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(950, 50);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(393, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LỊCH LÀM VIỆC BÁC SĨ";
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.Controls.Add(cboShift);
            grpInfo.Controls.Add(lblShift);
            grpInfo.Controls.Add(dtpWorkDate);
            grpInfo.Controls.Add(lblWorkDate);
            grpInfo.Controls.Add(cboDoctor);
            grpInfo.Controls.Add(lblDoctor);
            grpInfo.Controls.Add(txtScheduleID);
            grpInfo.Controls.Add(lblScheduleID);
            grpInfo.Font = new Font("Segoe UI", 9.5F);
            grpInfo.Location = new Point(15, 60);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(920, 125);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin phân ca làm việc";
            // 
            // cboShift
            // 
            cboShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShift.FormattingEnabled = true;
            cboShift.Items.AddRange(new object[] { "Sáng (Morning: 08:00 - 12:00)", "Chiều (Afternoon: 13:00 - 17:00)", "Tối (Evening: 17:30 - 20:30)" });
            cboShift.Location = new Point(600, 70);
            cboShift.Name = "cboShift";
            cboShift.Size = new Size(300, 29);
            cboShift.TabIndex = 7;
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.Location = new Point(495, 75);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(92, 21);
            lblShift.TabIndex = 6;
            lblShift.Text = "Ca làm việc:";
            // 
            // dtpWorkDate
            // 
            dtpWorkDate.CustomFormat = "dd/MM/yyyy";
            dtpWorkDate.Format = DateTimePickerFormat.Custom;
            dtpWorkDate.Location = new Point(600, 30);
            dtpWorkDate.Name = "dtpWorkDate";
            dtpWorkDate.Size = new Size(300, 29);
            dtpWorkDate.TabIndex = 5;
            // 
            // lblWorkDate
            // 
            lblWorkDate.AutoSize = true;
            lblWorkDate.Location = new Point(495, 35);
            lblWorkDate.Name = "lblWorkDate";
            lblWorkDate.Size = new Size(80, 21);
            lblWorkDate.TabIndex = 4;
            lblWorkDate.Text = "Ngày làm:";
            // 
            // cboDoctor
            // 
            cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoctor.FormattingEnabled = true;
            cboDoctor.Location = new Point(130, 70);
            cboDoctor.Name = "cboDoctor";
            cboDoctor.Size = new Size(330, 29);
            cboDoctor.TabIndex = 3;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(20, 75);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(58, 21);
            lblDoctor.TabIndex = 2;
            lblDoctor.Text = "Bác sĩ:";
            // 
            // txtScheduleID
            // 
            txtScheduleID.BackColor = Color.WhiteSmoke;
            txtScheduleID.Location = new Point(130, 30);
            txtScheduleID.Name = "txtScheduleID";
            txtScheduleID.ReadOnly = true;
            txtScheduleID.Size = new Size(330, 29);
            txtScheduleID.TabIndex = 1;
            // 
            // lblScheduleID
            // 
            lblScheduleID.AutoSize = true;
            lblScheduleID.Location = new Point(20, 35);
            lblScheduleID.Name = "lblScheduleID";
            lblScheduleID.Size = new Size(67, 21);
            lblScheduleID.TabIndex = 0;
            lblScheduleID.Text = "Mã Lịch:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 195);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(920, 45);
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
            btnDelete.Text = " Xóa lịch";
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
            btnAdd.Text = " Thêm lịch";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.Controls.Add(btnRefresh);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(15, 245);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(920, 40);
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
            txtSearch.PlaceholderText = "Nhập tên bác sĩ, mã BS hoặc ca làm việc...";
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
            // dgvSchedules
            // 
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AllowUserToDeleteRows = false;
            dgvSchedules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.BackgroundColor = Color.White;
            dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedules.Columns.AddRange(new DataGridViewColumn[] { colScheduleID, colDoctorID, colDoctorName, colWorkDate, colShift });
            dgvSchedules.Location = new Point(15, 295);
            dgvSchedules.MultiSelect = false;
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.ReadOnly = true;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.RowHeadersWidth = 51;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.Size = new Size(920, 285);
            dgvSchedules.TabIndex = 4;
            dgvSchedules.CellClick += dgvSchedules_CellClick;
            // 
            // colScheduleID
            // 
            colScheduleID.DataPropertyName = "ScheduleID";
            colScheduleID.FillWeight = 15F;
            colScheduleID.HeaderText = "Mã Lịch";
            colScheduleID.MinimumWidth = 6;
            colScheduleID.Name = "colScheduleID";
            colScheduleID.ReadOnly = true;
            // 
            // colDoctorID
            // 
            colDoctorID.DataPropertyName = "DoctorID";
            colDoctorID.FillWeight = 15F;
            colDoctorID.HeaderText = "Mã BS";
            colDoctorID.MinimumWidth = 6;
            colDoctorID.Name = "colDoctorID";
            colDoctorID.ReadOnly = true;
            // 
            // colDoctorName
            // 
            colDoctorName.DataPropertyName = "DoctorName";
            colDoctorName.FillWeight = 35F;
            colDoctorName.HeaderText = "Bác Sĩ";
            colDoctorName.MinimumWidth = 6;
            colDoctorName.Name = "colDoctorName";
            colDoctorName.ReadOnly = true;
            // 
            // colWorkDate
            // 
            colWorkDate.DataPropertyName = "WorkDate";
            dgvCellStyleDate.Format = "dd/MM/yyyy";
            colWorkDate.DefaultCellStyle = dgvCellStyleDate;
            colWorkDate.FillWeight = 20F;
            colWorkDate.HeaderText = "Ngày Làm Việc";
            colWorkDate.MinimumWidth = 6;
            colWorkDate.Name = "colWorkDate";
            colWorkDate.ReadOnly = true;
            // 
            // colShift
            // 
            colShift.DataPropertyName = "Shift";
            colShift.FillWeight = 15F;
            colShift.HeaderText = "Ca Làm Việc";
            colShift.MinimumWidth = 6;
            colShift.Name = "colShift";
            colShift.ReadOnly = true;
            // 
            // FormWorkSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 595);
            Controls.Add(dgvSchedules);
            Controls.Add(pnlSearch);
            Controls.Add(pnlButtons);
            Controls.Add(grpInfo);
            Controls.Add(panelTop);
            MinimumSize = new Size(850, 550);
            Name = "FormWorkSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Lịch Làm Việc Bác Sĩ - Dental Clinic";
            Load += FormWorkSchedule_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblScheduleID;
        private TextBox txtScheduleID;
        private Label lblDoctor;
        private ComboBox cboDoctor;
        private Label lblWorkDate;
        private DateTimePicker dtpWorkDate;
        private Label lblShift;
        private ComboBox cboShift;
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
        private DataGridView dgvSchedules;
        private DataGridViewTextBoxColumn colScheduleID;
        private DataGridViewTextBoxColumn colDoctorID;
        private DataGridViewTextBoxColumn colDoctorName;
        private DataGridViewTextBoxColumn colWorkDate;
        private DataGridViewTextBoxColumn colShift;
    }
}
