namespace GUI_DCM
{
    partial class FormPatientLookup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvPatients = new DataGridView();
            btnSelect = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 20);
            lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(90, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập Mã, Họ tên hoặc Số điện thoại...";
            txtSearch.Size = new Size(380, 27);
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(12, 50);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(458, 280);
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.RoyalBlue;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.ForeColor = Color.White;
            btnSelect.Location = new Point(264, 340);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(100, 32);
            btnSelect.Text = "Chọn";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(370, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 32);
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (s, e) => this.Close();
            // 
            // FormPatientLookup
            // 
            ClientSize = new Size(482, 385);
            Controls.Add(btnCancel);
            Controls.Add(btnSelect);
            Controls.Add(dgvPatients);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPatientLookup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tra cứu & Chọn Bệnh Nhân";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvPatients;
        private Button btnSelect;
        private Button btnCancel;
    }
}