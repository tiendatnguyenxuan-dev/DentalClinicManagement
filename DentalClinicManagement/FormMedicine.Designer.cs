namespace DentalClinicManagement
{
    partial class FormMedicine
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
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            nudStock = new NumericUpDown();
            lblStock = new Label();
            nudPrice = new NumericUpDown();
            lblPrice = new Label();
            cboUnit = new ComboBox();
            lblUnit = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtMedID = new TextBox();
            lblMedID = new Label();
            dgvMedicines = new DataGridView();
            colMedID = new DataGridViewTextBoxColumn();
            colMedName = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(142, 68, 173);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(880, 50);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ DANH MỤC THUỐC & KHO";
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnReset);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnUpdate);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(nudStock);
            grpInfo.Controls.Add(lblStock);
            grpInfo.Controls.Add(nudPrice);
            grpInfo.Controls.Add(lblPrice);
            grpInfo.Controls.Add(cboUnit);
            grpInfo.Controls.Add(lblUnit);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(lblName);
            grpInfo.Controls.Add(txtMedID);
            grpInfo.Controls.Add(lblMedID);
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Location = new Point(0, 50);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(880, 160);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin thuốc";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(690, 108);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(110, 34);
            btnReset.TabIndex = 13;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Enabled = false;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(560, 108);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 34);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkOrange;
            btnUpdate.Enabled = false;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(430, 108);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 34);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(300, 108);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 34);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(660, 68);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(140, 27);
            nudStock.TabIndex = 9;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(590, 71);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(65, 20);
            lblStock.TabIndex = 8;
            lblStock.Text = "Tồn kho:";
            // 
            // nudPrice
            // 
            nudPrice.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            nudPrice.Location = new Point(380, 68);
            nudPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(180, 27);
            nudPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(310, 71);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(63, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá:";
            // 
            // cboUnit
            // 
            cboUnit.FormattingEnabled = true;
            cboUnit.Items.AddRange(new object[] { "Viên", "Vỉ", "Hộp", "Chai", "Ống", "Gói" });
            cboUnit.Location = new Point(100, 68);
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(180, 28);
            cboUnit.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(20, 71);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(55, 20);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Đơn vị:";
            // 
            // txtName
            // 
            txtName.Location = new Point(380, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 27);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(300, 31);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Tên thuốc:";
            // 
            // txtMedID
            // 
            txtMedID.Location = new Point(100, 28);
            txtMedID.Name = "txtMedID";
            txtMedID.ReadOnly = true;
            txtMedID.Size = new Size(180, 27);
            txtMedID.TabIndex = 1;
            // 
            // lblMedID
            // 
            lblMedID.AutoSize = true;
            lblMedID.Location = new Point(20, 31);
            lblMedID.Name = "lblMedID";
            lblMedID.Size = new Size(74, 20);
            lblMedID.TabIndex = 0;
            lblMedID.Text = "Mã thuốc:";
            // 
            // dgvMedicines
            // 
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicines.Columns.AddRange(new DataGridViewColumn[] { colMedID, colMedName, colUnit, colPrice, colStock });
            dgvMedicines.Dock = DockStyle.Fill;
            dgvMedicines.Location = new Point(0, 210);
            dgvMedicines.MultiSelect = false;
            dgvMedicines.Name = "dgvMedicines";
            dgvMedicines.ReadOnly = true;
            dgvMedicines.RowHeadersVisible = false;
            dgvMedicines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicines.Size = new Size(880, 390);
            dgvMedicines.TabIndex = 2;
            dgvMedicines.CellClick += dgvMedicines_CellClick;
            // 
            // colMedID
            // 
            colMedID.DataPropertyName = "MedicineID";
            colMedID.FillWeight = 40F;
            colMedID.HeaderText = "ID";
            colMedID.Name = "colMedID";
            colMedID.ReadOnly = true;
            // 
            // colMedName
            // 
            colMedName.DataPropertyName = "MedicineName";
            colMedName.FillWeight = 160F;
            colMedName.HeaderText = "Tên thuốc";
            colMedName.Name = "colMedName";
            colMedName.ReadOnly = true;
            // 
            // colUnit
            // 
            colUnit.DataPropertyName = "Unit";
            colUnit.FillWeight = 60F;
            colUnit.HeaderText = "Đơn vị";
            colUnit.Name = "colUnit";
            colUnit.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "UnitPrice";
            colPrice.FillWeight = 80F;
            colPrice.HeaderText = "Đơn giá (VNĐ)";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "StockQuantity";
            colStock.FillWeight = 60F;
            colStock.HeaderText = "Tồn kho";
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // FormMedicine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 600);
            Controls.Add(dgvMedicines);
            Controls.Add(grpInfo);
            Controls.Add(panelTop);
            Name = "FormMedicine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Kho thuốc";
            Load += FormMedicine_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblMedID;
        private TextBox txtMedID;
        private Label lblName;
        private TextBox txtName;
        private Label lblUnit;
        private ComboBox cboUnit;
        private Label lblPrice;
        private NumericUpDown nudPrice;
        private Label lblStock;
        private NumericUpDown nudStock;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnReset;
        private DataGridView dgvMedicines;
        private DataGridViewTextBoxColumn colMedID;
        private DataGridViewTextBoxColumn colMedName;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStock;
    }
}
