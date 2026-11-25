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
            tabMain = new TabControl();
            tabWeekly = new TabPage();
            tlpCalendar = new TableLayoutPanel();
            pnlWeekTop = new Panel();
            grpWeeklyAdd = new GroupBox();
            btnWeeklyAdd = new Button();
            cboWeeklyShift = new ComboBox();
            lblWeeklyShift = new Label();
            dtpWeeklyDate = new DateTimePicker();
            lblWeeklyDate = new Label();
            cboWeeklyEmployee = new ComboBox();
            lblWeeklyEmployee = new Label();
            pnlWeekNav = new Panel();
            lblWeekRange = new Label();
            btnNextWeek = new Button();
            btnCurrentWeek = new Button();
            btnPrevWeek = new Button();
            tabList = new TabPage();
            dgvSchedules = new DataGridView();
            colScheduleID = new DataGridViewTextBoxColumn();
            colDoctorID = new DataGridViewTextBoxColumn();
            colDoctorName = new DataGridViewTextBoxColumn();
            colWorkDate = new DataGridViewTextBoxColumn();
            colShift = new DataGridViewTextBoxColumn();
            pnlSearch = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpInfo = new GroupBox();
            cboShift = new ComboBox();
            lblShift = new Label();
            dtpWorkDate = new DateTimePicker();
            lblWorkDate = new Label();
            cboEmployees = new ComboBox();
            lblDoctor = new Label();
            txtScheduleID = new TextBox();
            lblScheduleID = new Label();
            panelTop.SuspendLayout();
            tabMain.SuspendLayout();
            tabWeekly.SuspendLayout();
            pnlWeekTop.SuspendLayout();
            grpWeeklyAdd.SuspendLayout();
            pnlWeekNav.SuspendLayout();
            tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).BeginInit();
            pnlSearch.SuspendLayout();
            pnlButtons.SuspendLayout();
            grpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.DarkSlateBlue;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1100, 52);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(328, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LỊCH LÀM VIỆC";
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabWeekly);
            tabMain.Controls.Add(tabList);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Font = new Font("Segoe UI", 9.5F);
            tabMain.Location = new Point(0, 52);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1100, 668);
            tabMain.TabIndex = 1;
            // 
            // tabWeekly
            // 
            tabWeekly.BackColor = Color.White;
            tabWeekly.Controls.Add(tlpCalendar);
            tabWeekly.Controls.Add(pnlWeekTop);
            tabWeekly.Location = new Point(4, 30);
            tabWeekly.Name = "tabWeekly";
            tabWeekly.Padding = new Padding(10);
            tabWeekly.Size = new Size(1092, 634);
            tabWeekly.TabIndex = 0;
            tabWeekly.Text = "  📅 Lịch theo tuần (Weekly View)  ";
            // 
            // tlpCalendar
            // 
            tlpCalendar.BackColor = Color.WhiteSmoke;
            tlpCalendar.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpCalendar.ColumnCount = 7;
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tlpCalendar.Dock = DockStyle.Fill;
            tlpCalendar.Location = new Point(10, 130);
            tlpCalendar.Name = "tlpCalendar";
            tlpCalendar.RowCount = 2;
            tlpCalendar.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tlpCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCalendar.Size = new Size(1072, 494);
            tlpCalendar.TabIndex = 1;
            // 
            // pnlWeekTop
            // 
            pnlWeekTop.Controls.Add(grpWeeklyAdd);
            pnlWeekTop.Controls.Add(pnlWeekNav);
            pnlWeekTop.Dock = DockStyle.Top;
            pnlWeekTop.Location = new Point(10, 10);
            pnlWeekTop.Name = "pnlWeekTop";
            pnlWeekTop.Size = new Size(1072, 120);
            pnlWeekTop.TabIndex = 0;
            // 
            // grpWeeklyAdd
            // 
            grpWeeklyAdd.Controls.Add(btnWeeklyAdd);
            grpWeeklyAdd.Controls.Add(cboWeeklyShift);
            grpWeeklyAdd.Controls.Add(lblWeeklyShift);
            grpWeeklyAdd.Controls.Add(dtpWeeklyDate);
            grpWeeklyAdd.Controls.Add(lblWeeklyDate);
            grpWeeklyAdd.Controls.Add(cboWeeklyEmployee);
            grpWeeklyAdd.Controls.Add(lblWeeklyEmployee);
            grpWeeklyAdd.Dock = DockStyle.Fill;
            grpWeeklyAdd.Font = new Font("Segoe UI", 9F);
            grpWeeklyAdd.Location = new Point(0, 45);
            grpWeeklyAdd.Name = "grpWeeklyAdd";
            grpWeeklyAdd.Size = new Size(1072, 75);
            grpWeeklyAdd.TabIndex = 1;
            grpWeeklyAdd.TabStop = false;
            grpWeeklyAdd.Text = "Thêm nhanh lịch làm việc (Chọn ngày trên lưới để tự động điền)";
            // 
            // btnWeeklyAdd
            // 
            btnWeeklyAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWeeklyAdd.BackColor = Color.RoyalBlue;
            btnWeeklyAdd.FlatStyle = FlatStyle.Flat;
            btnWeeklyAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnWeeklyAdd.ForeColor = Color.White;
            btnWeeklyAdd.Location = new Point(930, 26);
            btnWeeklyAdd.Name = "btnWeeklyAdd";
            btnWeeklyAdd.Size = new Size(130, 34);
            btnWeeklyAdd.TabIndex = 6;
            btnWeeklyAdd.Text = "➕ Thêm lịch";
            btnWeeklyAdd.UseVisualStyleBackColor = false;
            btnWeeklyAdd.Click += btnWeeklyAdd_Click;
            // 
            // cboWeeklyShift
            // 
            cboWeeklyShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboWeeklyShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWeeklyShift.FormattingEnabled = true;
            cboWeeklyShift.Items.AddRange(new object[] { "Cả ngày (FullDay: 08:00 - 20:30)", "Sáng (Morning: 08:00 - 12:00)", "Chiều (Afternoon: 13:00 - 20:30)" });
            cboWeeklyShift.Location = new Point(660, 29);
            cboWeeklyShift.Name = "cboWeeklyShift";
            cboWeeklyShift.Size = new Size(250, 28);
            cboWeeklyShift.TabIndex = 5;
            // 
            // lblWeeklyShift
            // 
            lblWeeklyShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWeeklyShift.AutoSize = true;
            lblWeeklyShift.Location = new Point(590, 33);
            lblWeeklyShift.Name = "lblWeeklyShift";
            lblWeeklyShift.Size = new Size(62, 20);
            lblWeeklyShift.TabIndex = 4;
            lblWeeklyShift.Text = "Ca làm:";
            // 
            // dtpWeeklyDate
            // 
            dtpWeeklyDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpWeeklyDate.CustomFormat = "dd/MM/yyyy";
            dtpWeeklyDate.Format = DateTimePickerFormat.Custom;
            dtpWeeklyDate.Location = new Point(440, 29);
            dtpWeeklyDate.Name = "dtpWeeklyDate";
            dtpWeeklyDate.Size = new Size(135, 27);
            dtpWeeklyDate.TabIndex = 3;
            // 
            // lblWeeklyDate
            // 
            lblWeeklyDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWeeklyDate.AutoSize = true;
            lblWeeklyDate.Location = new Point(360, 33);
            lblWeeklyDate.Name = "lblWeeklyDate";
            lblWeeklyDate.Size = new Size(76, 20);
            lblWeeklyDate.TabIndex = 2;
            lblWeeklyDate.Text = "Ngày làm:";
            // 
            // cboWeeklyEmployee
            // 
            cboWeeklyEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboWeeklyEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWeeklyEmployee.FormattingEnabled = true;
            cboWeeklyEmployee.Location = new Point(95, 29);
            cboWeeklyEmployee.Name = "cboWeeklyEmployee";
            cboWeeklyEmployee.Size = new Size(250, 28);
            cboWeeklyEmployee.TabIndex = 1;
            // 
            // lblWeeklyEmployee
            // 
            lblWeeklyEmployee.AutoSize = true;
            lblWeeklyEmployee.Location = new Point(12, 33);
            lblWeeklyEmployee.Name = "lblWeeklyEmployee";
            lblWeeklyEmployee.Size = new Size(78, 20);
            lblWeeklyEmployee.TabIndex = 0;
            lblWeeklyEmployee.Text = "Nhân viên:";
            // 
            // pnlWeekNav
            // 
            pnlWeekNav.Controls.Add(lblWeekRange);
            pnlWeekNav.Controls.Add(btnNextWeek);
            pnlWeekNav.Controls.Add(btnCurrentWeek);
            pnlWeekNav.Controls.Add(btnPrevWeek);
            pnlWeekNav.Dock = DockStyle.Top;
            pnlWeekNav.Location = new Point(0, 0);
            pnlWeekNav.Name = "pnlWeekNav";
            pnlWeekNav.Size = new Size(1072, 45);
            pnlWeekNav.TabIndex = 0;
            // 
            // lblWeekRange
            // 
            lblWeekRange.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWeekRange.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWeekRange.ForeColor = Color.DarkSlateBlue;
            lblWeekRange.Location = new Point(340, 8);
            lblWeekRange.Name = "lblWeekRange";
            lblWeekRange.Size = new Size(710, 28);
            lblWeekRange.TabIndex = 3;
            lblWeekRange.Text = "Tuần: 02/11/2026 - 08/11/2026";
            lblWeekRange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNextWeek
            // 
            btnNextWeek.BackColor = Color.WhiteSmoke;
            btnNextWeek.FlatStyle = FlatStyle.Flat;
            btnNextWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNextWeek.ForeColor = Color.DarkSlateBlue;
            btnNextWeek.Location = new Point(220, 5);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Size = new Size(110, 32);
            btnNextWeek.TabIndex = 2;
            btnNextWeek.Text = "Tuần sau ▶";
            btnNextWeek.UseVisualStyleBackColor = false;
            btnNextWeek.Click += btnNextWeek_Click;
            // 
            // btnCurrentWeek
            // 
            btnCurrentWeek.BackColor = Color.WhiteSmoke;
            btnCurrentWeek.FlatStyle = FlatStyle.Flat;
            btnCurrentWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCurrentWeek.ForeColor = Color.DarkSlateBlue;
            btnCurrentWeek.Location = new Point(115, 5);
            btnCurrentWeek.Name = "btnCurrentWeek";
            btnCurrentWeek.Size = new Size(95, 32);
            btnCurrentWeek.TabIndex = 1;
            btnCurrentWeek.Text = "Hôm nay";
            btnCurrentWeek.UseVisualStyleBackColor = false;
            btnCurrentWeek.Click += btnCurrentWeek_Click;
            // 
            // btnPrevWeek
            // 
            btnPrevWeek.BackColor = Color.WhiteSmoke;
            btnPrevWeek.FlatStyle = FlatStyle.Flat;
            btnPrevWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrevWeek.ForeColor = Color.DarkSlateBlue;
            btnPrevWeek.Location = new Point(0, 5);
            btnPrevWeek.Name = "btnPrevWeek";
            btnPrevWeek.Size = new Size(110, 32);
            btnPrevWeek.TabIndex = 0;
            btnPrevWeek.Text = "◀ Tuần trước";
            btnPrevWeek.UseVisualStyleBackColor = false;
            btnPrevWeek.Click += btnPrevWeek_Click;
            // 
            // tabList
            // 
            tabList.BackColor = Color.White;
            tabList.Controls.Add(dgvSchedules);
            tabList.Controls.Add(pnlSearch);
            tabList.Controls.Add(pnlButtons);
            tabList.Controls.Add(grpInfo);
            tabList.Location = new Point(4, 30);
            tabList.Name = "tabList";
            tabList.Padding = new Padding(10);
            tabList.Size = new Size(1092, 634);
            tabList.TabIndex = 1;
            tabList.Text = "  📋 Danh sách & Quản lý chi tiết  ";
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
            dgvSchedules.Location = new Point(10, 245);
            dgvSchedules.MultiSelect = false;
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.ReadOnly = true;
            dgvSchedules.RowHeadersVisible = false;
            dgvSchedules.RowHeadersWidth = 51;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.Size = new Size(1072, 375);
            dgvSchedules.TabIndex = 3;
            dgvSchedules.CellClick += dgvSchedules_CellClick;
            // 
            // colScheduleID
            // 
            colScheduleID.DataPropertyName = "ScheduleID";
            colScheduleID.FillWeight = 12F;
            colScheduleID.HeaderText = "Mã Lịch";
            colScheduleID.MinimumWidth = 6;
            colScheduleID.Name = "colScheduleID";
            colScheduleID.ReadOnly = true;
            // 
            // colDoctorID
            // 
            colDoctorID.DataPropertyName = "DoctorID";
            colDoctorID.FillWeight = 12F;
            colDoctorID.HeaderText = "Mã NV";
            colDoctorID.MinimumWidth = 6;
            colDoctorID.Name = "colDoctorID";
            colDoctorID.ReadOnly = true;
            // 
            // colDoctorName
            // 
            colDoctorName.DataPropertyName = "DoctorName";
            colDoctorName.FillWeight = 38F;
            colDoctorName.HeaderText = "Nhân Viên";
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
            colShift.FillWeight = 18F;
            colShift.HeaderText = "Ca Làm Việc";
            colShift.MinimumWidth = 6;
            colShift.Name = "colShift";
            colShift.ReadOnly = true;
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.Controls.Add(btnRefresh);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(10, 195);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1072, 40);
            pnlSearch.TabIndex = 2;
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
            txtSearch.PlaceholderText = "Nhập tên nhân viên, mã NV hoặc ca làm việc...";
            txtSearch.Size = new Size(350, 29);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(5, 10);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(76, 21);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(10, 145);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(650, 45);
            pnlButtons.TabIndex = 1;
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
            btnClear.Text = "Làm mới";
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
            btnDelete.Text = "Xóa lịch";
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
            btnUpdate.Text = "Cập nhật";
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
            btnAdd.Text = "Thêm lịch";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.Controls.Add(cboShift);
            grpInfo.Controls.Add(lblShift);
            grpInfo.Controls.Add(dtpWorkDate);
            grpInfo.Controls.Add(lblWorkDate);
            grpInfo.Controls.Add(cboEmployees);
            grpInfo.Controls.Add(lblDoctor);
            grpInfo.Controls.Add(txtScheduleID);
            grpInfo.Controls.Add(lblScheduleID);
            grpInfo.Font = new Font("Segoe UI", 9.5F);
            grpInfo.Location = new Point(10, 10);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(1072, 125);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin phân ca làm việc";
            // 
            // cboShift
            // 
            cboShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShift.FormattingEnabled = true;
            cboShift.Items.AddRange(new object[] { "Cả ngày (FullDay: 08:00 - 20:30)", "Sáng (Morning: 08:00 - 12:00)", "Chiều (Afternoon: 13:00 - 20:30)" });
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
            // cboEmployees
            // 
            cboEmployees.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployees.FormattingEnabled = true;
            cboEmployees.Location = new Point(130, 70);
            cboEmployees.Name = "cboEmployees";
            cboEmployees.Size = new Size(330, 29);
            cboEmployees.TabIndex = 3;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(20, 75);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(83, 21);
            lblDoctor.TabIndex = 2;
            lblDoctor.Text = "Nhân viên:";
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
            // FormWorkSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 720);
            Controls.Add(tabMain);
            Controls.Add(panelTop);
            MinimumSize = new Size(1000, 650);
            Name = "FormWorkSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Lịch Làm Việc - Dental Clinic";
            Load += FormWorkSchedule_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabMain.ResumeLayout(false);
            tabWeekly.ResumeLayout(false);
            pnlWeekTop.ResumeLayout(false);
            grpWeeklyAdd.ResumeLayout(false);
            grpWeeklyAdd.PerformLayout();
            pnlWeekNav.ResumeLayout(false);
            tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlButtons.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private TabControl tabMain;
        private TabPage tabWeekly;
        private TableLayoutPanel tlpCalendar;
        private Panel pnlWeekTop;
        private Panel pnlWeekNav;
        private Label lblWeekRange;
        private Button btnNextWeek;
        private Button btnCurrentWeek;
        private Button btnPrevWeek;
        private GroupBox grpWeeklyAdd;
        private Label lblWeeklyEmployee;
        private ComboBox cboWeeklyEmployee;
        private Label lblWeeklyDate;
        private DateTimePicker dtpWeeklyDate;
        private Label lblWeeklyShift;
        private ComboBox cboWeeklyShift;
        private Button btnWeeklyAdd;
        private TabPage tabList;
        private GroupBox grpInfo;
        private Label lblScheduleID;
        private TextBox txtScheduleID;
        private Label lblDoctor;
        private ComboBox cboEmployees;
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
