namespace DentalClinicManagement
{
    partial class FormDailyRevenueDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlHeader = new System.Windows.Forms.Panel();
            lblSubtitle = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            pnlBottom = new System.Windows.Forms.Panel();
            lblSummary = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnExportExcel = new System.Windows.Forms.Button();
            dgvDetails = new System.Windows.Forms.DataGridView();
            colInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colExamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colServiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMedicineAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFinalTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1150, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            lblSubtitle.Location = new System.Drawing.Point(18, 36);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(262, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Danh sách hóa đơn & ca khám...";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(425, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CHI TIẾT DOANH THU NGÀY: 00/00/0000";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            pnlBottom.Controls.Add(lblSummary);
            pnlBottom.Controls.Add(btnClose);
            pnlBottom.Controls.Add(btnExportExcel);
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Location = new System.Drawing.Point(0, 560);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(1200, 65);
            pnlBottom.TabIndex = 1;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblSummary.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            lblSummary.Location = new System.Drawing.Point(12, 8);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new System.Drawing.Size(940, 48);
            lblSummary.TabIndex = 2;
            lblSummary.Text = "Tổng số: 0 hóa đơn | Tổng thực thu: 0 VNĐ";
            lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1085, 16);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(95, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnExportExcel.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnExportExcel.ForeColor = System.Drawing.Color.White;
            btnExportExcel.Location = new System.Drawing.Point(965, 16);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new System.Drawing.Size(110, 34);
            btnExportExcel.TabIndex = 0;
            btnExportExcel.Text = "Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = System.Drawing.Color.White;
            dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colInvoiceID, colExamID, colTime, colPatient, colDoctor, colDiagnosis, colServiceAmount, colMedicineAmount, colDiscountAmount, colFinalTotal, colPaymentStatus });
            dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDetails.Location = new System.Drawing.Point(0, 65);
            dgvDetails.MultiSelect = false;
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new System.Drawing.Size(1150, 460);
            dgvDetails.TabIndex = 2;
            // 
            // colInvoiceID
            // 
            colInvoiceID.DataPropertyName = "InvoiceID";
            colInvoiceID.FillWeight = 55F;
            colInvoiceID.HeaderText = "Mã HĐ";
            colInvoiceID.MinimumWidth = 6;
            colInvoiceID.Name = "colInvoiceID";
            colInvoiceID.ReadOnly = true;
            // 
            // colExamID
            // 
            colExamID.DataPropertyName = "ExaminationID";
            colExamID.FillWeight = 55F;
            colExamID.HeaderText = "Mã Khám";
            colExamID.MinimumWidth = 6;
            colExamID.Name = "colExamID";
            colExamID.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.DataPropertyName = "InvoiceTime";
            colTime.FillWeight = 50F;
            colTime.HeaderText = "Giờ";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colPatient
            // 
            colPatient.DataPropertyName = "PatientName";
            colPatient.FillWeight = 110F;
            colPatient.HeaderText = "Bệnh Nhân";
            colPatient.MinimumWidth = 6;
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.DataPropertyName = "DoctorName";
            colDoctor.FillWeight = 100F;
            colDoctor.HeaderText = "Bác Sĩ";
            colDoctor.MinimumWidth = 6;
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colDiagnosis
            // 
            colDiagnosis.DataPropertyName = "Diagnosis";
            colDiagnosis.FillWeight = 120F;
            colDiagnosis.HeaderText = "Chẩn Đoán";
            colDiagnosis.MinimumWidth = 6;
            colDiagnosis.Name = "colDiagnosis";
            colDiagnosis.ReadOnly = true;
            // 
            // colServiceAmount
            // 
            colServiceAmount.DataPropertyName = "TotalAmountService";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            colServiceAmount.DefaultCellStyle = dataGridViewCellStyle1;
            colServiceAmount.FillWeight = 85F;
            colServiceAmount.HeaderText = "Tiền DV (VNĐ)";
            colServiceAmount.MinimumWidth = 6;
            colServiceAmount.Name = "colServiceAmount";
            colServiceAmount.ReadOnly = true;
            // 
            // colMedicineAmount
            // 
            colMedicineAmount.DataPropertyName = "TotalAmountMedicine";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            colMedicineAmount.DefaultCellStyle = dataGridViewCellStyle2;
            colMedicineAmount.FillWeight = 80F;
            colMedicineAmount.HeaderText = "Tiền Thuốc";
            colMedicineAmount.MinimumWidth = 6;
            colMedicineAmount.Name = "colMedicineAmount";
            colMedicineAmount.ReadOnly = true;
            // 
            // colDiscountAmount
            // 
            colDiscountAmount.DataPropertyName = "DiscountAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            colDiscountAmount.DefaultCellStyle = dataGridViewCellStyle3;
            colDiscountAmount.FillWeight = 70F;
            colDiscountAmount.HeaderText = "Giảm Giá";
            colDiscountAmount.MinimumWidth = 6;
            colDiscountAmount.Name = "colDiscountAmount";
            colDiscountAmount.ReadOnly = true;
            // 
            // colFinalTotal
            // 
            colFinalTotal.DataPropertyName = "FinalTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle4.Format = "N0";
            colFinalTotal.DefaultCellStyle = dataGridViewCellStyle4;
            colFinalTotal.FillWeight = 95F;
            colFinalTotal.HeaderText = "Thực Thu (VNĐ)";
            colFinalTotal.MinimumWidth = 6;
            colFinalTotal.Name = "colFinalTotal";
            colFinalTotal.ReadOnly = true;
            // 
            // colPaymentStatus
            // 
            colPaymentStatus.DataPropertyName = "PaymentStatus";
            colPaymentStatus.FillWeight = 75F;
            colPaymentStatus.HeaderText = "T.Thái";
            colPaymentStatus.MinimumWidth = 6;
            colPaymentStatus.Name = "colPaymentStatus";
            colPaymentStatus.ReadOnly = true;
            // 
            // FormDailyRevenueDetail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 625);
            Controls.Add(dgvDetails);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "FormDailyRevenueDetail";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Chi tiết Doanh thu theo Ngày";
            Load += FormDailyRevenueDetail_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicineAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentStatus;
    }
}
