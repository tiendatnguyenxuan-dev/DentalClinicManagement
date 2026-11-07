namespace GUI_DCM
{
    partial class FormAppointment
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
            DataGridViewCellStyle gridStyleHeader = new DataGridViewCellStyle();
            panelTopFilter = new Panel();
            lblTitle = new Label();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            lblStatusFilter = new Label();
            cbFilterStatus = new ComboBox();
            lblDoctorFilter = new Label();
            cbFilterDoctor = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnResetFilter = new Button();
            panelActionBar = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnUpdateStatus = new Button();
            btnDelete = new Button();
            dgvAppointments = new DataGridView();
            panelTopFilter.SuspendLayout();
            panelActionBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // panelTopFilter
            // 
            panelTopFilter.BackColor = Color.FromArgb(245, 247, 250);
            panelTopFilter.Controls.Add(btnResetFilter);
            panelTopFilter.Controls.Add(btnSearch);
            panelTopFilter.Controls.Add(txtSearch);
            panelTopFilter.Controls.Add(lblSearch);
            panelTopFilter.Controls.Add(cbFilterDoctor);
            panelTopFilter.Controls.Add(lblDoctorFilter);
            panelTopFilter.Controls.Add(cbFilterStatus);
            panelTopFilter.Controls.Add(lblStatusFilter);
            panelTopFilter.Controls.Add(dtpToDate);
            panelTopFilter.Controls.Add(lblToDate);
            panelTopFilter.Controls.Add(dtpFromDate);
            panelTopFilter.Controls.Add(lblFromDate);
            panelTopFilter.Controls.Add(lblTitle);
            panelTopFilter.Dock = DockStyle.Top;
            panelTopFilter.Location = new Point(0, 0);
            panelTopFilter.Name = "panelTopFilter";
            panelTopFilter.Size = new Size(1000, 115);
            panelTopFilter.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(328, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LỊCH HẸN KHÁCH HÀNG";
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(15, 55);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(65, 20);
            lblFromDate.TabIndex = 1;
            lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(82, 52);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.ShowCheckBox = true;
            dtpFromDate.Size = new Size(130, 27);
            dtpFromDate.TabIndex = 2;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(222, 55);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(75, 20);
            lblToDate.TabIndex = 3;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(300, 52);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.ShowCheckBox = true;
            dtpToDate.Size = new Size(130, 27);
            dtpToDate.TabIndex = 4;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Location = new Point(445, 55);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(78, 20);
            lblStatusFilter.TabIndex = 5;
            lblStatusFilter.Text = "Trạng thái:";
            // 
            // cbFilterStatus
            // 
            cbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterStatus.FormattingEnabled = true;
            cbFilterStatus.Location = new Point(526, 52);
            cbFilterStatus.Name = "cbFilterStatus";
            cbFilterStatus.Size = new Size(135, 28);
            cbFilterStatus.TabIndex = 6;
            // 
            // lblDoctorFilter
            // 
            lblDoctorFilter.AutoSize = true;
            lblDoctorFilter.Location = new Point(675, 55);
            lblDoctorFilter.Name = "lblDoctorFilter";
            lblDoctorFilter.Size = new Size(54, 20);
            lblDoctorFilter.TabIndex = 7;
            lblDoctorFilter.Text = "Bác sĩ:";
            // 
            // cbFilterDoctor
            // 
            cbFilterDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterDoctor.FormattingEnabled = true;
            cbFilterDoctor.Location = new Point(732, 52);
            cbFilterDoctor.Name = "cbFilterDoctor";
            cbFilterDoctor.Size = new Size(185, 28);
            cbFilterDoctor.TabIndex = 8;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 88);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 20);
            lblSearch.TabIndex = 9;
            lblSearch.Text = "Bệnh nhân:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(90, 85);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên hoặc số điện thoại bệnh nhân...";
            txtSearch.Size = new Size(340, 27);
            txtSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SlateBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(445, 83);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 30);
            btnSearch.TabIndex = 11;
            btnSearch.Text = " Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.BackColor = Color.White;
            btnResetFilter.FlatStyle = FlatStyle.Flat;
            btnResetFilter.Location = new Point(565, 83);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(95, 30);
            btnResetFilter.TabIndex = 12;
            btnResetFilter.Text = "Làm mới";
            btnResetFilter.UseVisualStyleBackColor = false;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // panelActionBar
            // 
            panelActionBar.BackColor = Color.White;
            panelActionBar.Controls.Add(btnDelete);
            panelActionBar.Controls.Add(btnUpdateStatus);
            panelActionBar.Controls.Add(btnEdit);
            panelActionBar.Controls.Add(btnAdd);
            panelActionBar.Dock = DockStyle.Top;
            panelActionBar.Location = new Point(0, 115);
            panelActionBar.Name = "panelActionBar";
            panelActionBar.Size = new Size(1000, 50);
            panelActionBar.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.RoyalBlue;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(15, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "+ Thêm lịch hẹn";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SlateBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(155, 8);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 34);
            btnEdit.TabIndex = 1;
            btnEdit.Text = " Sửa thông tin";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.Teal;
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.Location = new Point(295, 8);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(160, 34);
            btnUpdateStatus.TabIndex = 2;
            btnUpdateStatus.Text = " Đổi trạng thái...";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(885, 8);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = " Xóa hẹn";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            gridStyleHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridStyleHeader.BackColor = Color.SlateBlue;
            gridStyleHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridStyleHeader.ForeColor = Color.White;
            gridStyleHeader.SelectionBackColor = SystemColors.Highlight;
            gridStyleHeader.SelectionForeColor = SystemColors.HighlightText;
            gridStyleHeader.WrapMode = DataGridViewTriState.True;
            dgvAppointments.ColumnHeadersDefaultCellStyle = gridStyleHeader;
            dgvAppointments.ColumnHeadersHeight = 35;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.EnableHeadersVisualStyles = false;
            dgvAppointments.Location = new Point(0, 165);
            dgvAppointments.MultiSelect = false;
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersWidth = 35;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(1000, 435);
            dgvAppointments.TabIndex = 2;
            dgvAppointments.CellDoubleClick += dgvAppointments_CellDoubleClick;
            // 
            // FormAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvAppointments);
            Controls.Add(panelActionBar);
            Controls.Add(panelTopFilter);
            Name = "FormAppointment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Lịch hẹn - Dental Clinic Management";
            panelTopFilter.ResumeLayout(false);
            panelTopFilter.PerformLayout();
            panelActionBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopFilter;
        private Label lblTitle;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Label lblStatusFilter;
        private ComboBox cbFilterStatus;
        private Label lblDoctorFilter;
        private ComboBox cbFilterDoctor;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnResetFilter;
        private Panel panelActionBar;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnUpdateStatus;
        private Button btnDelete;
        private DataGridView dgvAppointments;
    }
}