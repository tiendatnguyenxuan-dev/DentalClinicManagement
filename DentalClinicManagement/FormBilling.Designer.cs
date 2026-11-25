namespace DentalClinicManagement
{
    partial class FormBilling
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
            grpCreate = new GroupBox();
            btnCreateInvoice = new Button();
            nudDiscount = new NumericUpDown();
            lblDiscount = new Label();
            cboExam = new ComboBox();
            lblExam = new Label();
            splitContainer = new SplitContainer();
            dgvInvoices = new DataGridView();
            colInvID = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            grpPay = new GroupBox();
            tabBillingDetails = new TabControl();
            tabServices = new TabPage();
            dgvInvoiceServices = new DataGridView();
            colIS_ServiceName = new DataGridViewTextBoxColumn();
            colIS_Quantity = new DataGridViewTextBoxColumn();
            colIS_UnitPrice = new DataGridViewTextBoxColumn();
            colIS_TotalPrice = new DataGridViewTextBoxColumn();
            tabPrescriptions = new TabPage();
            dgvInvoicePrescriptions = new DataGridView();
            colIP_MedicineName = new DataGridViewTextBoxColumn();
            colIP_Unit = new DataGridViewTextBoxColumn();
            colIP_Quantity = new DataGridViewTextBoxColumn();
            colIP_UnitPrice = new DataGridViewTextBoxColumn();
            colIP_TotalPrice = new DataGridViewTextBoxColumn();
            tabPayments = new TabPage();
            dgvPayments = new DataGridView();
            colPayID = new DataGridViewTextBoxColumn();
            colPayMethod = new DataGridViewTextBoxColumn();
            colPayAmount = new DataGridViewTextBoxColumn();
            colPayDate = new DataGridViewTextBoxColumn();
            btnPrintPdf = new Button();
            btnExportExcel = new Button();
            btnPay = new Button();
            cboPayMethod = new ComboBox();
            lblMethod = new Label();
            nudPayAmount = new NumericUpDown();
            lblAmount = new Label();
            lblPayStatus = new Label();
            txtFinalTotal = new TextBox();
            lblFinalTotal = new Label();
            txtDiscountShow = new TextBox();
            lblDiscountShow = new Label();
            txtMedicineAmount = new TextBox();
            lblMed = new Label();
            txtServiceAmount = new TextBox();
            lblServ = new Label();
            txtInvPatient = new TextBox();
            lblInvPatient = new Label();
            txtInvID = new TextBox();
            lblInvID = new Label();
            panelTop.SuspendLayout();
            grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            grpPay.SuspendLayout();
            tabBillingDetails.SuspendLayout();
            tabServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceServices).BeginInit();
            tabPrescriptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoicePrescriptions).BeginInit();
            tabPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPayAmount).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(39, 174, 96);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1150, 50);
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
            lblTitle.Text = "HÓA ĐƠN VIỆN PHÍ & THU NGÂN";
            // 
            // grpCreate
            // 
            grpCreate.Controls.Add(btnCreateInvoice);
            grpCreate.Controls.Add(nudDiscount);
            grpCreate.Controls.Add(lblDiscount);
            grpCreate.Controls.Add(cboExam);
            grpCreate.Controls.Add(lblExam);
            grpCreate.Dock = DockStyle.Top;
            grpCreate.Location = new Point(0, 50);
            grpCreate.Name = "grpCreate";
            grpCreate.Size = new Size(1150, 80);
            grpCreate.TabIndex = 1;
            grpCreate.TabStop = false;
            grpCreate.Text = "Xuất hóa đơn từ ca khám bệnh";
            // 
            // btnCreateInvoice
            // 
            btnCreateInvoice.BackColor = Color.FromArgb(39, 174, 96);
            btnCreateInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreateInvoice.ForeColor = Color.White;
            btnCreateInvoice.Location = new Point(780, 26);
            btnCreateInvoice.Name = "btnCreateInvoice";
            btnCreateInvoice.Size = new Size(180, 36);
            btnCreateInvoice.TabIndex = 4;
            btnCreateInvoice.Text = "+ Tạo / Xuất Hóa Đơn";
            btnCreateInvoice.UseVisualStyleBackColor = false;
            btnCreateInvoice.Click += btnCreateInvoice_Click;
            // 
            // nudDiscount
            // 
            nudDiscount.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDiscount.Location = new Point(560, 31);
            nudDiscount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudDiscount.Name = "nudDiscount";
            nudDiscount.Size = new Size(180, 27);
            nudDiscount.TabIndex = 3;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(480, 34);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(72, 20);
            lblDiscount.TabIndex = 2;
            lblDiscount.Text = "Giảm giá:";
            // 
            // cboExam
            // 
            cboExam.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExam.FormattingEnabled = true;
            cboExam.Location = new Point(140, 30);
            cboExam.Name = "cboExam";
            cboExam.Size = new Size(310, 28);
            cboExam.TabIndex = 1;
            // 
            // lblExam
            // 
            lblExam.AutoSize = true;
            lblExam.Location = new Point(20, 34);
            lblExam.Name = "lblExam";
            lblExam.Size = new Size(114, 20);
            lblExam.TabIndex = 0;
            lblExam.Text = "Chọn ca khám:";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 130);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgvInvoices);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(grpPay);
            splitContainer.Size = new Size(1150, 520);
            splitContainer.SplitterDistance = 640;
            splitContainer.TabIndex = 2;
            // 
            // dgvInvoices
            // 
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Columns.AddRange(new DataGridViewColumn[] { colInvID, colPatient, colDoctor, colTotal, colStatus, colDate });
            dgvInvoices.Dock = DockStyle.Fill;
            dgvInvoices.Location = new Point(0, 0);
            dgvInvoices.MultiSelect = false;
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new Size(640, 520);
            dgvInvoices.TabIndex = 0;
            dgvInvoices.CellClick += dgvInvoices_CellClick;
            // 
            // colInvID
            // 
            colInvID.DataPropertyName = "InvoiceID";
            colInvID.FillWeight = 40F;
            colInvID.HeaderText = "ID";
            colInvID.Name = "colInvID";
            colInvID.ReadOnly = true;
            // 
            // colPatient
            // 
            colPatient.DataPropertyName = "PatientName";
            colPatient.FillWeight = 110F;
            colPatient.HeaderText = "Bệnh nhân";
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.DataPropertyName = "DoctorName";
            colDoctor.FillWeight = 100F;
            colDoctor.HeaderText = "Bác sĩ";
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "FinalTotal";
            colTotal.FillWeight = 80F;
            colTotal.HeaderText = "Tổng tiền";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "PaymentStatus";
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "T.Thái";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.DataPropertyName = "InvoiceDate";
            colDate.FillWeight = 90F;
            colDate.HeaderText = "Ngày lập";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // grpPay
            // 
            grpPay.Controls.Add(btnPrintPdf);
            grpPay.Controls.Add(btnExportExcel);
            grpPay.Controls.Add(tabBillingDetails);
            grpPay.Controls.Add(btnPay);
            grpPay.Controls.Add(cboPayMethod);
            grpPay.Controls.Add(lblMethod);
            grpPay.Controls.Add(nudPayAmount);
            grpPay.Controls.Add(lblAmount);
            grpPay.Controls.Add(lblPayStatus);
            grpPay.Controls.Add(txtFinalTotal);
            grpPay.Controls.Add(lblFinalTotal);
            grpPay.Controls.Add(txtDiscountShow);
            grpPay.Controls.Add(lblDiscountShow);
            grpPay.Controls.Add(txtMedicineAmount);
            grpPay.Controls.Add(lblMed);
            grpPay.Controls.Add(txtServiceAmount);
            grpPay.Controls.Add(lblServ);
            grpPay.Controls.Add(txtInvPatient);
            grpPay.Controls.Add(lblInvPatient);
            grpPay.Controls.Add(txtInvID);
            grpPay.Controls.Add(lblInvID);
            grpPay.Dock = DockStyle.Fill;
            grpPay.Location = new Point(0, 0);
            grpPay.Name = "grpPay";
            grpPay.Size = new Size(506, 520);
            grpPay.TabIndex = 0;
            grpPay.TabStop = false;
            grpPay.Text = "Chi tiết & Thanh toán hóa đơn";
            // 
            // tabBillingDetails
            // 
            tabBillingDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabBillingDetails.Controls.Add(tabServices);
            tabBillingDetails.Controls.Add(tabPrescriptions);
            tabBillingDetails.Controls.Add(tabPayments);
            tabBillingDetails.Location = new Point(15, 325);
            tabBillingDetails.Name = "tabBillingDetails";
            tabBillingDetails.SelectedIndex = 0;
            tabBillingDetails.Size = new Size(475, 180);
            tabBillingDetails.TabIndex = 18;
            // 
            // tabServices
            // 
            tabServices.Controls.Add(dgvInvoiceServices);
            tabServices.Location = new Point(4, 29);
            tabServices.Name = "tabServices";
            tabServices.Padding = new Padding(3);
            tabServices.Size = new Size(467, 147);
            tabServices.TabIndex = 0;
            tabServices.Text = "Dịch vụ";
            tabServices.UseVisualStyleBackColor = true;
            // 
            // dgvInvoiceServices
            // 
            dgvInvoiceServices.AllowUserToAddRows = false;
            dgvInvoiceServices.AllowUserToDeleteRows = false;
            dgvInvoiceServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceServices.BackgroundColor = Color.White;
            dgvInvoiceServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceServices.Columns.AddRange(new DataGridViewColumn[] { colIS_ServiceName, colIS_Quantity, colIS_UnitPrice, colIS_TotalPrice });
            dgvInvoiceServices.Dock = DockStyle.Fill;
            dgvInvoiceServices.Location = new Point(3, 3);
            dgvInvoiceServices.MultiSelect = false;
            dgvInvoiceServices.Name = "dgvInvoiceServices";
            dgvInvoiceServices.ReadOnly = true;
            dgvInvoiceServices.RowHeadersVisible = false;
            dgvInvoiceServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoiceServices.Size = new Size(461, 141);
            dgvInvoiceServices.TabIndex = 0;
            // 
            // colIS_ServiceName
            // 
            colIS_ServiceName.DataPropertyName = "ServiceName";
            colIS_ServiceName.FillWeight = 130F;
            colIS_ServiceName.HeaderText = "Tên dịch vụ";
            colIS_ServiceName.Name = "colIS_ServiceName";
            colIS_ServiceName.ReadOnly = true;
            // 
            // colIS_Quantity
            // 
            colIS_Quantity.DataPropertyName = "Quantity";
            colIS_Quantity.FillWeight = 40F;
            colIS_Quantity.HeaderText = "SL";
            colIS_Quantity.Name = "colIS_Quantity";
            colIS_Quantity.ReadOnly = true;
            // 
            // colIS_UnitPrice
            // 
            colIS_UnitPrice.DataPropertyName = "UnitPrice";
            colIS_UnitPrice.DefaultCellStyle.Format = "#,##0 đ";
            colIS_UnitPrice.FillWeight = 70F;
            colIS_UnitPrice.HeaderText = "Đơn giá";
            colIS_UnitPrice.Name = "colIS_UnitPrice";
            colIS_UnitPrice.ReadOnly = true;
            // 
            // colIS_TotalPrice
            // 
            colIS_TotalPrice.DataPropertyName = "TotalPrice";
            colIS_TotalPrice.DefaultCellStyle.Format = "#,##0 đ";
            colIS_TotalPrice.FillWeight = 80F;
            colIS_TotalPrice.HeaderText = "Thành tiền";
            colIS_TotalPrice.Name = "colIS_TotalPrice";
            colIS_TotalPrice.ReadOnly = true;
            // 
            // tabPrescriptions
            // 
            tabPrescriptions.Controls.Add(dgvInvoicePrescriptions);
            tabPrescriptions.Location = new Point(4, 29);
            tabPrescriptions.Name = "tabPrescriptions";
            tabPrescriptions.Padding = new Padding(3);
            tabPrescriptions.Size = new Size(467, 147);
            tabPrescriptions.TabIndex = 1;
            tabPrescriptions.Text = "Đơn thuốc";
            tabPrescriptions.UseVisualStyleBackColor = true;
            // 
            // dgvInvoicePrescriptions
            // 
            dgvInvoicePrescriptions.AllowUserToAddRows = false;
            dgvInvoicePrescriptions.AllowUserToDeleteRows = false;
            dgvInvoicePrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoicePrescriptions.BackgroundColor = Color.White;
            dgvInvoicePrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoicePrescriptions.Columns.AddRange(new DataGridViewColumn[] { colIP_MedicineName, colIP_Unit, colIP_Quantity, colIP_UnitPrice, colIP_TotalPrice });
            dgvInvoicePrescriptions.Dock = DockStyle.Fill;
            dgvInvoicePrescriptions.Location = new Point(3, 3);
            dgvInvoicePrescriptions.MultiSelect = false;
            dgvInvoicePrescriptions.Name = "dgvInvoicePrescriptions";
            dgvInvoicePrescriptions.ReadOnly = true;
            dgvInvoicePrescriptions.RowHeadersVisible = false;
            dgvInvoicePrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoicePrescriptions.Size = new Size(461, 141);
            dgvInvoicePrescriptions.TabIndex = 0;
            // 
            // colIP_MedicineName
            // 
            colIP_MedicineName.DataPropertyName = "MedicineName";
            colIP_MedicineName.FillWeight = 110F;
            colIP_MedicineName.HeaderText = "Tên thuốc";
            colIP_MedicineName.Name = "colIP_MedicineName";
            colIP_MedicineName.ReadOnly = true;
            // 
            // colIP_Unit
            // 
            colIP_Unit.DataPropertyName = "Unit";
            colIP_Unit.FillWeight = 50F;
            colIP_Unit.HeaderText = "ĐVT";
            colIP_Unit.Name = "colIP_Unit";
            colIP_Unit.ReadOnly = true;
            // 
            // colIP_Quantity
            // 
            colIP_Quantity.DataPropertyName = "Quantity";
            colIP_Quantity.FillWeight = 40F;
            colIP_Quantity.HeaderText = "SL";
            colIP_Quantity.Name = "colIP_Quantity";
            colIP_Quantity.ReadOnly = true;
            // 
            // colIP_UnitPrice
            // 
            colIP_UnitPrice.DataPropertyName = "UnitPrice";
            colIP_UnitPrice.DefaultCellStyle.Format = "#,##0 đ";
            colIP_UnitPrice.FillWeight = 70F;
            colIP_UnitPrice.HeaderText = "Đơn giá";
            colIP_UnitPrice.Name = "colIP_UnitPrice";
            colIP_UnitPrice.ReadOnly = true;
            // 
            // colIP_TotalPrice
            // 
            colIP_TotalPrice.DataPropertyName = "TotalPrice";
            colIP_TotalPrice.DefaultCellStyle.Format = "#,##0 đ";
            colIP_TotalPrice.FillWeight = 80F;
            colIP_TotalPrice.HeaderText = "Thành tiền";
            colIP_TotalPrice.Name = "colIP_TotalPrice";
            colIP_TotalPrice.ReadOnly = true;
            // 
            // tabPayments
            // 
            tabPayments.Controls.Add(dgvPayments);
            tabPayments.Location = new Point(4, 29);
            tabPayments.Name = "tabPayments";
            tabPayments.Padding = new Padding(3);
            tabPayments.Size = new Size(467, 147);
            tabPayments.TabIndex = 2;
            tabPayments.Text = "Lịch sử thanh toán";
            tabPayments.UseVisualStyleBackColor = true;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Columns.AddRange(new DataGridViewColumn[] { colPayID, colPayMethod, colPayAmount, colPayDate });
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.Location = new Point(3, 3);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(461, 141);
            dgvPayments.TabIndex = 18;
            // 
            // colPayID
            // 
            colPayID.DataPropertyName = "PaymentID";
            colPayID.FillWeight = 40F;
            colPayID.HeaderText = "ID";
            colPayID.Name = "colPayID";
            colPayID.ReadOnly = true;
            // 
            // colPayMethod
            // 
            colPayMethod.DataPropertyName = "PaymentMethod";
            colPayMethod.FillWeight = 80F;
            colPayMethod.HeaderText = "Hình thức";
            colPayMethod.Name = "colPayMethod";
            colPayMethod.ReadOnly = true;
            // 
            // colPayAmount
            // 
            colPayAmount.DataPropertyName = "Amount";
            colPayAmount.FillWeight = 90F;
            colPayAmount.HeaderText = "Số tiền";
            colPayAmount.Name = "colPayAmount";
            colPayAmount.ReadOnly = true;
            // 
            // colPayDate
            // 
            colPayDate.DataPropertyName = "PaymentDate";
            colPayDate.FillWeight = 110F;
            colPayDate.HeaderText = "Ngày trả";
            colPayDate.Name = "colPayDate";
            colPayDate.ReadOnly = true;
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.ForestGreen;
            btnPay.Enabled = false;
            btnPay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(120, 275);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(130, 38);
            btnPay.TabIndex = 17;
            btnPay.Text = "XÁC NHẬN THU";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
            // 
            // btnPrintPdf
            // 
            btnPrintPdf.BackColor = Color.FromArgb(192, 57, 43);
            btnPrintPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrintPdf.ForeColor = Color.White;
            btnPrintPdf.Location = new Point(255, 275);
            btnPrintPdf.Name = "btnPrintPdf";
            btnPrintPdf.Size = new Size(115, 38);
            btnPrintPdf.TabIndex = 19;
            btnPrintPdf.Text = " In HĐ (PDF)";
            btnPrintPdf.UseVisualStyleBackColor = false;
            btnPrintPdf.Click += btnPrintPdf_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.FromArgb(39, 174, 96);
            btnExportExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(375, 275);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(115, 38);
            btnExportExcel.TabIndex = 20;
            btnExportExcel.Text = " Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // cboPayMethod
            // 
            cboPayMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPayMethod.FormattingEnabled = true;
            cboPayMethod.Items.AddRange(new object[] { "Cash", "BankTransfer", "Card", "EWallet" });
            cboPayMethod.Location = new Point(120, 235);
            cboPayMethod.Name = "cboPayMethod";
            cboPayMethod.Size = new Size(160, 28);
            cboPayMethod.TabIndex = 16;
            cboPayMethod.SelectedIndex = 0;
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(15, 238);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(76, 20);
            lblMethod.TabIndex = 15;
            lblMethod.Text = "Hình thức:";
            // 
            // nudPayAmount
            // 
            nudPayAmount.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPayAmount.Location = new Point(120, 198);
            nudPayAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPayAmount.Name = "nudPayAmount";
            nudPayAmount.Size = new Size(190, 27);
            nudPayAmount.TabIndex = 14;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAmount.Location = new Point(15, 200);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(88, 20);
            lblAmount.TabIndex = 13;
            lblAmount.Text = "Số tiền thu:";
            // 
            // lblPayStatus
            // 
            lblPayStatus.AutoSize = true;
            lblPayStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPayStatus.ForeColor = Color.DarkOrange;
            lblPayStatus.Location = new Point(325, 200);
            lblPayStatus.Name = "lblPayStatus";
            lblPayStatus.Size = new Size(139, 23);
            lblPayStatus.TabIndex = 12;
            lblPayStatus.Text = "Trạng thái: [---]";
            // 
            // txtFinalTotal
            // 
            txtFinalTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtFinalTotal.ForeColor = Color.Crimson;
            txtFinalTotal.Location = new Point(120, 155);
            txtFinalTotal.Name = "txtFinalTotal";
            txtFinalTotal.ReadOnly = true;
            txtFinalTotal.Size = new Size(190, 29);
            txtFinalTotal.TabIndex = 11;
            // 
            // lblFinalTotal
            // 
            lblFinalTotal.AutoSize = true;
            lblFinalTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFinalTotal.Location = new Point(15, 158);
            lblFinalTotal.Name = "lblFinalTotal";
            lblFinalTotal.Size = new Size(99, 20);
            lblFinalTotal.TabIndex = 10;
            lblFinalTotal.Text = "PHẢI THU:";
            // 
            // txtDiscountShow
            // 
            txtDiscountShow.Location = new Point(380, 115);
            txtDiscountShow.Name = "txtDiscountShow";
            txtDiscountShow.ReadOnly = true;
            txtDiscountShow.Size = new Size(110, 27);
            txtDiscountShow.TabIndex = 9;
            // 
            // lblDiscountShow
            // 
            lblDiscountShow.AutoSize = true;
            lblDiscountShow.Location = new Point(310, 118);
            lblDiscountShow.Name = "lblDiscountShow";
            lblDiscountShow.Size = new Size(72, 20);
            lblDiscountShow.TabIndex = 8;
            lblDiscountShow.Text = "Giảm giá:";
            // 
            // txtMedicineAmount
            // 
            txtMedicineAmount.Location = new Point(120, 115);
            txtMedicineAmount.Name = "txtMedicineAmount";
            txtMedicineAmount.ReadOnly = true;
            txtMedicineAmount.Size = new Size(175, 27);
            txtMedicineAmount.TabIndex = 7;
            // 
            // lblMed
            // 
            lblMed.AutoSize = true;
            lblMed.Location = new Point(15, 118);
            lblMed.Name = "lblMed";
            lblMed.Size = new Size(82, 20);
            lblMed.TabIndex = 6;
            lblMed.Text = "Tiền thuốc:";
            // 
            // txtServiceAmount
            // 
            txtServiceAmount.Location = new Point(120, 75);
            txtServiceAmount.Name = "txtServiceAmount";
            txtServiceAmount.ReadOnly = true;
            txtServiceAmount.Size = new Size(175, 27);
            txtServiceAmount.TabIndex = 5;
            // 
            // lblServ
            // 
            lblServ.AutoSize = true;
            lblServ.Location = new Point(15, 78);
            lblServ.Name = "lblServ";
            lblServ.Size = new Size(91, 20);
            lblServ.TabIndex = 4;
            lblServ.Text = "Tiền dịch vụ:";
            // 
            // txtInvPatient
            // 
            txtInvPatient.Location = new Point(230, 32);
            txtInvPatient.Name = "txtInvPatient";
            txtInvPatient.ReadOnly = true;
            txtInvPatient.Size = new Size(260, 27);
            txtInvPatient.TabIndex = 3;
            // 
            // lblInvPatient
            // 
            lblInvPatient.AutoSize = true;
            lblInvPatient.Location = new Point(150, 35);
            lblInvPatient.Name = "lblInvPatient";
            lblInvPatient.Size = new Size(82, 20);
            lblInvPatient.TabIndex = 2;
            lblInvPatient.Text = "Bệnh nhân:";
            // 
            // txtInvID
            // 
            txtInvID.Location = new Point(60, 32);
            txtInvID.Name = "txtInvID";
            txtInvID.ReadOnly = true;
            txtInvID.Size = new Size(65, 27);
            txtInvID.TabIndex = 1;
            // 
            // lblInvID
            // 
            lblInvID.AutoSize = true;
            lblInvID.Location = new Point(15, 35);
            lblInvID.Name = "lblInvID";
            lblInvID.Size = new Size(42, 20);
            lblInvID.TabIndex = 0;
            lblInvID.Text = "Số HĐ:";
            // 
            // FormBilling
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 650);
            Controls.Add(splitContainer);
            Controls.Add(grpCreate);
            Controls.Add(panelTop);
            Name = "FormBilling";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Hóa Đơn & Thu Ngân";
            Load += FormBilling_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            grpCreate.ResumeLayout(false);
            grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscount).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            grpPay.ResumeLayout(false);
            grpPay.PerformLayout();
            tabBillingDetails.ResumeLayout(false);
            tabServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceServices).EndInit();
            tabPrescriptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoicePrescriptions).EndInit();
            tabPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPayAmount).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private GroupBox grpCreate;
        private Label lblExam;
        private ComboBox cboExam;
        private Label lblDiscount;
        private NumericUpDown nudDiscount;
        private Button btnCreateInvoice;
        private SplitContainer splitContainer;
        private DataGridView dgvInvoices;
        private GroupBox grpPay;
        private Label lblInvID;
        private TextBox txtInvID;
        private Label lblInvPatient;
        private TextBox txtInvPatient;
        private Label lblServ;
        private TextBox txtServiceAmount;
        private Label lblMed;
        private TextBox txtMedicineAmount;
        private Label lblDiscountShow;
        private TextBox txtDiscountShow;
        private Label lblFinalTotal;
        private TextBox txtFinalTotal;
        private Label lblPayStatus;
        private Label lblAmount;
        private NumericUpDown nudPayAmount;
        private Label lblMethod;
        private ComboBox cboPayMethod;
        private Button btnPay;
        private Button btnPrintPdf;
        private Button btnExportExcel;
        private TabControl tabBillingDetails;
        private TabPage tabServices;
        private DataGridView dgvInvoiceServices;
        private DataGridViewTextBoxColumn colIS_ServiceName;
        private DataGridViewTextBoxColumn colIS_Quantity;
        private DataGridViewTextBoxColumn colIS_UnitPrice;
        private DataGridViewTextBoxColumn colIS_TotalPrice;
        private TabPage tabPrescriptions;
        private DataGridView dgvInvoicePrescriptions;
        private DataGridViewTextBoxColumn colIP_MedicineName;
        private DataGridViewTextBoxColumn colIP_Unit;
        private DataGridViewTextBoxColumn colIP_Quantity;
        private DataGridViewTextBoxColumn colIP_UnitPrice;
        private DataGridViewTextBoxColumn colIP_TotalPrice;
        private TabPage tabPayments;
        private DataGridView dgvPayments;
        private DataGridViewTextBoxColumn colInvID;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colPayID;
        private DataGridViewTextBoxColumn colPayMethod;
        private DataGridViewTextBoxColumn colPayAmount;
        private DataGridViewTextBoxColumn colPayDate;
    }
}
