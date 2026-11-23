namespace DentalClinicManagement
{
    partial class FormReports
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
            panelSummary = new Panel();
            pnlCard4 = new Panel();
            lblTotalAppointmentsValue = new Label();
            lblCard4 = new Label();
            pnlCard3 = new Panel();
            lblTotalPatientsValue = new Label();
            lblCard3 = new Label();
            pnlCard2 = new Panel();
            lblTotalExamsValue = new Label();
            lblCard2 = new Label();
            pnlCard1 = new Panel();
            lblTotalRevenueValue = new Label();
            lblCard1 = new Label();
            tabReport = new TabControl();
            tabByDate = new TabPage();
            dgvRevenue = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colInvoices = new DataGridViewTextBoxColumn();
            colServiceRev = new DataGridViewTextBoxColumn();
            colMedRev = new DataGridViewTextBoxColumn();
            colDiscount = new DataGridViewTextBoxColumn();
            colNetRev = new DataGridViewTextBoxColumn();
            grpFilter = new GroupBox();
            lblPeriodTotal = new Label();
            btnFilter = new Button();
            dtpToDate = new DateTimePicker();
            lblTo = new Label();
            dtpFromDate = new DateTimePicker();
            lblFrom = new Label();
            tabByQuarter = new TabPage();
            dgvQuarter = new DataGridView();
            colQ_Entity = new DataGridViewTextBoxColumn();
            colQ1 = new DataGridViewTextBoxColumn();
            colQ2 = new DataGridViewTextBoxColumn();
            colQ3 = new DataGridViewTextBoxColumn();
            colQ4 = new DataGridViewTextBoxColumn();
            colTC = new DataGridViewTextBoxColumn();
            grpQuarterFilter = new GroupBox();
            btnViewQuarter = new Button();
            cboQuarterType = new ComboBox();
            lblType = new Label();
            nudYear = new NumericUpDown();
            lblYear = new Label();
            panelTop.SuspendLayout();
            panelSummary.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard1.SuspendLayout();
            tabReport.SuspendLayout();
            tabByDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            grpFilter.SuspendLayout();
            tabByQuarter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuarter).BeginInit();
            grpQuarterFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(44, 62, 80);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1100, 50);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(490, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁO CÁO THỐNG KÊ DOANH THU & QUÝ NĂM";
            // 
            // panelSummary
            // 
            panelSummary.Controls.Add(pnlCard4);
            panelSummary.Controls.Add(pnlCard3);
            panelSummary.Controls.Add(pnlCard2);
            panelSummary.Controls.Add(pnlCard1);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(0, 50);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(1100, 95);
            panelSummary.TabIndex = 1;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.FromArgb(230, 126, 34);
            pnlCard4.Controls.Add(lblTotalAppointmentsValue);
            pnlCard4.Controls.Add(lblCard4);
            pnlCard4.Location = new Point(830, 12);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(250, 75);
            pnlCard4.TabIndex = 3;
            // 
            // lblTotalAppointmentsValue
            // 
            lblTotalAppointmentsValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalAppointmentsValue.ForeColor = Color.White;
            lblTotalAppointmentsValue.Location = new Point(10, 35);
            lblTotalAppointmentsValue.Name = "lblTotalAppointmentsValue";
            lblTotalAppointmentsValue.Size = new Size(230, 30);
            lblTotalAppointmentsValue.TabIndex = 1;
            lblTotalAppointmentsValue.Text = "0";
            // 
            // lblCard4
            // 
            lblCard4.AutoSize = true;
            lblCard4.ForeColor = Color.WhiteSmoke;
            lblCard4.Location = new Point(10, 10);
            lblCard4.Name = "lblCard4";
            lblCard4.Size = new Size(130, 20);
            lblCard4.TabIndex = 0;
            lblCard4.Text = "Tổng số cuộc hẹn:";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.FromArgb(142, 68, 173);
            pnlCard3.Controls.Add(lblTotalPatientsValue);
            pnlCard3.Controls.Add(lblCard3);
            pnlCard3.Location = new Point(560, 12);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(250, 75);
            pnlCard3.TabIndex = 2;
            // 
            // lblTotalPatientsValue
            // 
            lblTotalPatientsValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalPatientsValue.ForeColor = Color.White;
            lblTotalPatientsValue.Location = new Point(10, 35);
            lblTotalPatientsValue.Name = "lblTotalPatientsValue";
            lblTotalPatientsValue.Size = new Size(230, 30);
            lblTotalPatientsValue.TabIndex = 1;
            lblTotalPatientsValue.Text = "0";
            // 
            // lblCard3
            // 
            lblCard3.AutoSize = true;
            lblCard3.ForeColor = Color.WhiteSmoke;
            lblCard3.Location = new Point(10, 10);
            lblCard3.Name = "lblCard3";
            lblCard3.Size = new Size(144, 20);
            lblCard3.TabIndex = 0;
            lblCard3.Text = "Bệnh nhân hiện có:";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.FromArgb(41, 128, 185);
            pnlCard2.Controls.Add(lblTotalExamsValue);
            pnlCard2.Controls.Add(lblCard2);
            pnlCard2.Location = new Point(290, 12);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(250, 75);
            pnlCard2.TabIndex = 1;
            // 
            // lblTotalExamsValue
            // 
            lblTotalExamsValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalExamsValue.ForeColor = Color.White;
            lblTotalExamsValue.Location = new Point(10, 35);
            lblTotalExamsValue.Name = "lblTotalExamsValue";
            lblTotalExamsValue.Size = new Size(230, 30);
            lblTotalExamsValue.TabIndex = 1;
            lblTotalExamsValue.Text = "0";
            // 
            // lblCard2
            // 
            lblCard2.AutoSize = true;
            lblCard2.ForeColor = Color.WhiteSmoke;
            lblCard2.Location = new Point(10, 10);
            lblCard2.Name = "lblCard2";
            lblCard2.Size = new Size(134, 20);
            lblCard2.TabIndex = 0;
            lblCard2.Text = "Tổng số ca khám:";
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.FromArgb(39, 174, 96);
            pnlCard1.Controls.Add(lblTotalRevenueValue);
            pnlCard1.Controls.Add(lblCard1);
            pnlCard1.Location = new Point(15, 12);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(255, 75);
            pnlCard1.TabIndex = 0;
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalRevenueValue.ForeColor = Color.White;
            lblTotalRevenueValue.Location = new Point(10, 35);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new Size(235, 30);
            lblTotalRevenueValue.TabIndex = 1;
            lblTotalRevenueValue.Text = "0 VNĐ";
            // 
            // lblCard1
            // 
            lblCard1.AutoSize = true;
            lblCard1.ForeColor = Color.WhiteSmoke;
            lblCard1.Location = new Point(10, 10);
            lblCard1.Name = "lblCard1";
            lblCard1.Size = new Size(149, 20);
            lblCard1.TabIndex = 0;
            lblCard1.Text = "Tổng thực thu (All):";
            // 
            // tabReport
            // 
            tabReport.Controls.Add(tabByDate);
            tabReport.Controls.Add(tabByQuarter);
            tabReport.Dock = DockStyle.Fill;
            tabReport.Location = new Point(0, 145);
            tabReport.Name = "tabReport";
            tabReport.SelectedIndex = 0;
            tabReport.Size = new Size(1100, 505);
            tabReport.TabIndex = 2;
            // 
            // tabByDate
            // 
            tabByDate.Controls.Add(dgvRevenue);
            tabByDate.Controls.Add(grpFilter);
            tabByDate.Location = new Point(4, 29);
            tabByDate.Name = "tabByDate";
            tabByDate.Padding = new Padding(3);
            tabByDate.Size = new Size(1092, 472);
            tabByDate.TabIndex = 0;
            tabByDate.Text = "1. Báo cáo Doanh thu theo Ngày";
            tabByDate.UseVisualStyleBackColor = true;
            // 
            // dgvRevenue
            // 
            dgvRevenue.AllowUserToAddRows = false;
            dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.Columns.AddRange(new DataGridViewColumn[] { colDate, colInvoices, colServiceRev, colMedRev, colDiscount, colNetRev });
            dgvRevenue.Dock = DockStyle.Fill;
            dgvRevenue.Location = new Point(3, 73);
            dgvRevenue.MultiSelect = false;
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.ReadOnly = true;
            dgvRevenue.RowHeadersVisible = false;
            dgvRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenue.Size = new Size(1086, 396);
            dgvRevenue.TabIndex = 4;
            // 
            // colDate
            // 
            colDate.DataPropertyName = "TimeLabel";
            colDate.FillWeight = 80F;
            colDate.HeaderText = "Ngày";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colInvoices
            // 
            colInvoices.DataPropertyName = "InvoiceCount";
            colInvoices.FillWeight = 60F;
            colInvoices.HeaderText = "Số HĐ";
            colInvoices.Name = "colInvoices";
            colInvoices.ReadOnly = true;
            // 
            // colServiceRev
            // 
            colServiceRev.DataPropertyName = "TotalServiceRevenue";
            colServiceRev.FillWeight = 100F;
            colServiceRev.HeaderText = "Tiền Dịch vụ (VNĐ)";
            colServiceRev.Name = "colServiceRev";
            colServiceRev.ReadOnly = true;
            // 
            // colMedRev
            // 
            colMedRev.DataPropertyName = "TotalMedicineRevenue";
            colMedRev.FillWeight = 100F;
            colMedRev.HeaderText = "Tiền Thuốc (VNĐ)";
            colMedRev.Name = "colMedRev";
            colMedRev.ReadOnly = true;
            // 
            // colDiscount
            // 
            colDiscount.DataPropertyName = "TotalDiscount";
            colDiscount.FillWeight = 80F;
            colDiscount.HeaderText = "Giảm giá (VNĐ)";
            colDiscount.Name = "colDiscount";
            colDiscount.ReadOnly = true;
            // 
            // colNetRev
            // 
            colNetRev.DataPropertyName = "NetRevenue";
            colNetRev.FillWeight = 110F;
            colNetRev.HeaderText = "Doanh thu thuần (VNĐ)";
            colNetRev.Name = "colNetRev";
            colNetRev.ReadOnly = true;
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(lblPeriodTotal);
            grpFilter.Controls.Add(btnFilter);
            grpFilter.Controls.Add(dtpToDate);
            grpFilter.Controls.Add(lblTo);
            grpFilter.Controls.Add(dtpFromDate);
            grpFilter.Controls.Add(lblFrom);
            grpFilter.Dock = DockStyle.Top;
            grpFilter.Location = new Point(3, 3);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(1086, 70);
            grpFilter.TabIndex = 3;
            grpFilter.TabStop = false;
            grpFilter.Text = "Xem doanh thu từ ngày đến ngày";
            // 
            // lblPeriodTotal
            // 
            lblPeriodTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPeriodTotal.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPeriodTotal.ForeColor = Color.Crimson;
            lblPeriodTotal.Location = new Point(656, 28);
            lblPeriodTotal.Name = "lblPeriodTotal";
            lblPeriodTotal.Size = new Size(410, 25);
            lblPeriodTotal.TabIndex = 5;
            lblPeriodTotal.Text = "Tổng thực thu trong kỳ: 0 VNĐ";
            lblPeriodTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.SteelBlue;
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(480, 25);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(110, 32);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Xem báo cáo";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpToDate
            // 
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(310, 27);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(140, 27);
            dtpToDate.TabIndex = 3;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(235, 31);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(75, 20);
            lblTo.TabIndex = 2;
            lblTo.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(85, 27);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(130, 27);
            dtpFromDate.TabIndex = 1;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(15, 31);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(65, 20);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "Từ ngày:";
            // 
            // tabByQuarter
            // 
            tabByQuarter.Controls.Add(dgvQuarter);
            tabByQuarter.Controls.Add(grpQuarterFilter);
            tabByQuarter.Location = new Point(4, 29);
            tabByQuarter.Name = "tabByQuarter";
            tabByQuarter.Padding = new Padding(3);
            tabByQuarter.Size = new Size(1092, 472);
            tabByQuarter.TabIndex = 1;
            tabByQuarter.Text = "2. Thống kê Ma trận Quý & Năm (PDF Yêu cầu mục 10)";
            tabByQuarter.UseVisualStyleBackColor = true;
            // 
            // dgvQuarter
            // 
            dgvQuarter.AllowUserToAddRows = false;
            dgvQuarter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuarter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuarter.Columns.AddRange(new DataGridViewColumn[] { colQ_Entity, colQ1, colQ2, colQ3, colQ4, colTC });
            dgvQuarter.Dock = DockStyle.Fill;
            dgvQuarter.Location = new Point(3, 73);
            dgvQuarter.MultiSelect = false;
            dgvQuarter.Name = "dgvQuarter";
            dgvQuarter.ReadOnly = true;
            dgvQuarter.RowHeadersVisible = false;
            dgvQuarter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuarter.Size = new Size(1086, 396);
            dgvQuarter.TabIndex = 1;
            // 
            // colQ_Entity
            // 
            colQ_Entity.DataPropertyName = "EntityName";
            colQ_Entity.FillWeight = 160F;
            colQ_Entity.HeaderText = "Đối tượng";
            colQ_Entity.Name = "colQ_Entity";
            colQ_Entity.ReadOnly = true;
            // 
            // colQ1
            // 
            colQ1.DataPropertyName = "Q1";
            colQ1.FillWeight = 80F;
            colQ1.HeaderText = "Quý 1 (Q1)";
            colQ1.Name = "colQ1";
            colQ1.ReadOnly = true;
            // 
            // colQ2
            // 
            colQ2.DataPropertyName = "Q2";
            colQ2.FillWeight = 80F;
            colQ2.HeaderText = "Quý 2 (Q2)";
            colQ2.Name = "colQ2";
            colQ2.ReadOnly = true;
            // 
            // colQ3
            // 
            colQ3.DataPropertyName = "Q3";
            colQ3.FillWeight = 80F;
            colQ3.HeaderText = "Quý 3 (Q3)";
            colQ3.Name = "colQ3";
            colQ3.ReadOnly = true;
            // 
            // colQ4
            // 
            colQ4.DataPropertyName = "Q4";
            colQ4.FillWeight = 80F;
            colQ4.HeaderText = "Quý 4 (Q4)";
            colQ4.Name = "colQ4";
            colQ4.ReadOnly = true;
            // 
            // colTC
            // 
            colTC.DataPropertyName = "TC";
            colTC.FillWeight = 100F;
            colTC.HeaderText = "Tổng Cộng (TC)";
            colTC.Name = "colTC";
            colTC.ReadOnly = true;
            // 
            // grpQuarterFilter
            // 
            grpQuarterFilter.Controls.Add(btnViewQuarter);
            grpQuarterFilter.Controls.Add(cboQuarterType);
            grpQuarterFilter.Controls.Add(lblType);
            grpQuarterFilter.Controls.Add(nudYear);
            grpQuarterFilter.Controls.Add(lblYear);
            grpQuarterFilter.Dock = DockStyle.Top;
            grpQuarterFilter.Location = new Point(3, 3);
            grpQuarterFilter.Name = "grpQuarterFilter";
            grpQuarterFilter.Size = new Size(1086, 70);
            grpQuarterFilter.TabIndex = 0;
            grpQuarterFilter.TabStop = false;
            grpQuarterFilter.Text = "Chọn tiêu chí thống kê theo Quý";
            // 
            // btnViewQuarter
            // 
            btnViewQuarter.BackColor = Color.ForestGreen;
            btnViewQuarter.ForeColor = Color.White;
            btnViewQuarter.Location = new Point(590, 25);
            btnViewQuarter.Name = "btnViewQuarter";
            btnViewQuarter.Size = new Size(130, 32);
            btnViewQuarter.TabIndex = 4;
            btnViewQuarter.Text = "Xem Thống Kê";
            btnViewQuarter.UseVisualStyleBackColor = false;
            btnViewQuarter.Click += btnViewQuarter_Click;
            // 
            // cboQuarterType
            // 
            cboQuarterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuarterType.FormattingEnabled = true;
            cboQuarterType.Items.AddRange(new object[] { "1. Theo Nhân viên / Bác sĩ (NV 1, NV 2...)", "2. Theo Khách hàng / Bệnh nhân (KH 1, KH 2...)", "3. Theo Sản phẩm / Thuốc (SP 1, SP 2...)" });
            cboQuarterType.Location = new Point(270, 27);
            cboQuarterType.Name = "cboQuarterType";
            cboQuarterType.Size = new Size(300, 28);
            cboQuarterType.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(190, 31);
            lblType.Name = "lblType";
            lblType.Size = new Size(68, 20);
            lblType.TabIndex = 2;
            lblType.Text = "Tiêu chí:";
            // 
            // nudYear
            // 
            nudYear.Location = new Point(70, 28);
            nudYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(100, 27);
            nudYear.TabIndex = 1;
            nudYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(15, 31);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(44, 20);
            lblYear.TabIndex = 0;
            lblYear.Text = "Năm:";
            // 
            // FormReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(tabReport);
            Controls.Add(panelSummary);
            Controls.Add(panelTop);
            Name = "FormReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo Cáo & Thống Kê Doanh Thu";
            Load += FormReports_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSummary.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            tabReport.ResumeLayout(false);
            tabByDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            tabByQuarter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQuarter).EndInit();
            grpQuarterFilter.ResumeLayout(false);
            grpQuarterFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Panel panelSummary;
        private Panel pnlCard1;
        private Label lblCard1;
        private Label lblTotalRevenueValue;
        private Panel pnlCard2;
        private Label lblTotalExamsValue;
        private Label lblCard2;
        private Panel pnlCard3;
        private Label lblTotalPatientsValue;
        private Label lblCard3;
        private Panel pnlCard4;
        private Label lblTotalAppointmentsValue;
        private Label lblCard4;
        private TabControl tabReport;
        private TabPage tabByDate;
        private TabPage tabByQuarter;
        private GroupBox grpFilter;
        private Label lblFrom;
        private DateTimePicker dtpFromDate;
        private Label lblTo;
        private DateTimePicker dtpToDate;
        private Button btnFilter;
        private Label lblPeriodTotal;
        private DataGridView dgvRevenue;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colInvoices;
        private DataGridViewTextBoxColumn colServiceRev;
        private DataGridViewTextBoxColumn colMedRev;
        private DataGridViewTextBoxColumn colDiscount;
        private DataGridViewTextBoxColumn colNetRev;
        private GroupBox grpQuarterFilter;
        private Label lblYear;
        private NumericUpDown nudYear;
        private Label lblType;
        private ComboBox cboQuarterType;
        private Button btnViewQuarter;
        private DataGridView dgvQuarter;
        private DataGridViewTextBoxColumn colQ_Entity;
        private DataGridViewTextBoxColumn colQ1;
        private DataGridViewTextBoxColumn colQ2;
        private DataGridViewTextBoxColumn colQ3;
        private DataGridViewTextBoxColumn colQ4;
        private DataGridViewTextBoxColumn colTC;
    }
}
