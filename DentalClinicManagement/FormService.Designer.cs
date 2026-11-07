namespace DentalClinicManagement
{
    partial class FormService
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            grpInfo = new GroupBox();
            cboUnit = new ComboBox();
            lblUnit = new Label();
            nudUnitPrice = new NumericUpDown();
            lblUnitPrice = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtServiceName = new TextBox();
            lblServiceName = new Label();
            txtServiceID = new TextBox();
            lblServiceID = new Label();
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
            dgvServices = new DataGridView();
            colServiceID = new DataGridViewTextBoxColumn();
            colServiceName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
            pnlButtons.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
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
            lblTitle.Size = new Size(343, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ DỊCH VỤ NHA KHOA";
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.Controls.Add(cboUnit);
            grpInfo.Controls.Add(lblUnit);
            grpInfo.Controls.Add(nudUnitPrice);
            grpInfo.Controls.Add(lblUnitPrice);
            grpInfo.Controls.Add(cboCategory);
            grpInfo.Controls.Add(lblCategory);
            grpInfo.Controls.Add(txtServiceName);
            grpInfo.Controls.Add(lblServiceName);
            grpInfo.Controls.Add(txtServiceID);
            grpInfo.Controls.Add(lblServiceID);
            grpInfo.Font = new Font("Segoe UI", 9.5F);
            grpInfo.Location = new Point(15, 60);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(920, 160);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin dịch vụ";
            // 
            // cboUnit
            // 
            cboUnit.FormattingEnabled = true;
            cboUnit.Items.AddRange(new object[] { "Răng", "Hàm", "Lần", "Gói", "Trụ", "Liệu trình" });
            cboUnit.Location = new Point(600, 70);
            cboUnit.MaxLength = 30;
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(300, 29);
            cboUnit.TabIndex = 9;
            cboUnit.SelectedIndexChanged += cboUnit_SelectedIndexChanged;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(495, 75);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(90, 21);
            lblUnit.TabIndex = 8;
            lblUnit.Text = "Đơn vị tính:";
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            nudUnitPrice.Location = new Point(600, 30);
            nudUnitPrice.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(300, 29);
            nudUnitPrice.TabIndex = 7;
            nudUnitPrice.TextAlign = HorizontalAlignment.Right;
            nudUnitPrice.ThousandsSeparator = true;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(495, 35);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(91, 21);
            lblUnitPrice.TabIndex = 6;
            lblUnitPrice.Text = "Đơn giá (đ):";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Items.AddRange(new object[] { "Nha khoa tổng quát", "Chỉnh nha - Niềng răng", "Phục hình răng sứ", "Cấy ghép Implant", "Thẩm mỹ răng", "Nha chu - Tiểu phẫu" });
            cboCategory.Location = new Point(130, 110);
            cboCategory.MaxLength = 50;
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(330, 29);
            cboCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 115);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 21);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(130, 70);
            txtServiceName.MaxLength = 150;
            txtServiceName.Name = "txtServiceName";
            txtServiceName.PlaceholderText = "Nhập tên dịch vụ (vd: Trám răng, Nhổ răng,...)";
            txtServiceName.Size = new Size(330, 29);
            txtServiceName.TabIndex = 3;
            // 
            // lblServiceName
            // 
            lblServiceName.AutoSize = true;
            lblServiceName.Location = new Point(20, 75);
            lblServiceName.Name = "lblServiceName";
            lblServiceName.Size = new Size(90, 21);
            lblServiceName.TabIndex = 2;
            lblServiceName.Text = "Tên dịch vụ:";
            // 
            // txtServiceID
            // 
            txtServiceID.BackColor = Color.WhiteSmoke;
            txtServiceID.Location = new Point(130, 30);
            txtServiceID.Name = "txtServiceID";
            txtServiceID.ReadOnly = true;
            txtServiceID.Size = new Size(330, 29);
            txtServiceID.TabIndex = 1;
            // 
            // lblServiceID
            // 
            lblServiceID.AutoSize = true;
            lblServiceID.Location = new Point(20, 35);
            lblServiceID.Name = "lblServiceID";
            lblServiceID.Size = new Size(60, 21);
            lblServiceID.TabIndex = 0;
            lblServiceID.Text = "Mã DV:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 230);
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
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.Controls.Add(btnRefresh);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(15, 280);
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
            txtSearch.PlaceholderText = "Nhập tên dịch vụ hoặc danh mục cần tìm...";
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
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.BackgroundColor = Color.White;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { colServiceID, colServiceName, colCategory, colUnitPrice, colUnit });
            dgvServices.Location = new Point(15, 330);
            dgvServices.MultiSelect = false;
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersVisible = false;
            dgvServices.RowHeadersWidth = 51;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(920, 255);
            dgvServices.TabIndex = 4;
            dgvServices.CellClick += dgvServices_CellClick;
            // 
            // colServiceID
            // 
            colServiceID.DataPropertyName = "ServiceID";
            colServiceID.FillWeight = 15F;
            colServiceID.HeaderText = "Mã DV";
            colServiceID.MinimumWidth = 6;
            colServiceID.Name = "colServiceID";
            colServiceID.ReadOnly = true;
            // 
            // colServiceName
            // 
            colServiceName.DataPropertyName = "ServiceName";
            colServiceName.FillWeight = 40F;
            colServiceName.HeaderText = "Tên Dịch Vụ";
            colServiceName.MinimumWidth = 6;
            colServiceName.Name = "colServiceName";
            colServiceName.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "ServiceCategory";
            colCategory.FillWeight = 25F;
            colCategory.HeaderText = "Danh Mục";
            colCategory.MinimumWidth = 6;
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            colUnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0 đ";
            colUnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            colUnitPrice.FillWeight = 22F;
            colUnitPrice.HeaderText = "Đơn Giá";
            colUnitPrice.MinimumWidth = 6;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            // 
            // colUnit
            // 
            colUnit.DataPropertyName = "Unit";
            colUnit.FillWeight = 18F;
            colUnit.HeaderText = "Đơn Vị Tính";
            colUnit.MinimumWidth = 6;
            colUnit.Name = "colUnit";
            colUnit.ReadOnly = true;
            // 
            // FormService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 600);
            Controls.Add(dgvServices);
            Controls.Add(pnlSearch);
            Controls.Add(pnlButtons);
            Controls.Add(grpInfo);
            Controls.Add(panelTop);
            MinimumSize = new Size(850, 550);
            Name = "FormService";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Dịch Vụ - Dental Clinic";
            Load += FormService_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
            pnlButtons.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblServiceID;
        private TextBox txtServiceID;
        private Label lblServiceName;
        private TextBox txtServiceName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblUnitPrice;
        private NumericUpDown nudUnitPrice;
        private Label lblUnit;
        private ComboBox cboUnit;
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
        private DataGridView dgvServices;
        private DataGridViewTextBoxColumn colServiceID;
        private DataGridViewTextBoxColumn colServiceName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colUnit;
    }
}
