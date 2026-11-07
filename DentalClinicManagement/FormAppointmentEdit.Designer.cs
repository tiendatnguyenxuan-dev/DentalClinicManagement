namespace GUI_DCM
{
    partial class FormAppointmentEdit
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
            panelHeader = new Panel();
            lblTitle = new Label();
            lblPatient = new Label();
            txtPatientDisplay = new TextBox();
            btnSelectPatient = new Button();
            lblDoctor = new Label();
            cbDoctor = new ComboBox();
            lblDateTime = new Label();
            dtpDateTime = new DateTimePicker();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SlateBlue;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(520, 55);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(224, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN LỊCH HẸN";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPatient.Location = new Point(30, 70);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(171, 21);
            lblPatient.TabIndex = 1;
            lblPatient.Text = "Bệnh nhân (bắt buộc):";
            // 
            // txtPatientDisplay
            // 
            txtPatientDisplay.BackColor = Color.WhiteSmoke;
            txtPatientDisplay.Location = new Point(30, 95);
            txtPatientDisplay.Name = "txtPatientDisplay";
            txtPatientDisplay.ReadOnly = true;
            txtPatientDisplay.Size = new Size(340, 27);
            txtPatientDisplay.TabIndex = 2;
            txtPatientDisplay.Text = "--- Bấm [Chọn bệnh nhân] để tìm ---";
            // 
            // btnSelectPatient
            // 
            btnSelectPatient.BackColor = Color.SlateBlue;
            btnSelectPatient.FlatStyle = FlatStyle.Flat;
            btnSelectPatient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectPatient.ForeColor = Color.White;
            btnSelectPatient.Location = new Point(380, 94);
            btnSelectPatient.Name = "btnSelectPatient";
            btnSelectPatient.Size = new Size(110, 29);
            btnSelectPatient.TabIndex = 3;
            btnSelectPatient.Text = "🔍 Chọn BN";
            btnSelectPatient.UseVisualStyleBackColor = false;
            btnSelectPatient.Click += btnSelectPatient_Click;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDoctor.Location = new Point(30, 140);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(135, 21);
            lblDoctor.TabIndex = 4;
            lblDoctor.Text = "Bác sĩ phụ trách:";
            // 
            // cbDoctor
            // 
            cbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDoctor.FormattingEnabled = true;
            cbDoctor.Location = new Point(30, 165);
            cbDoctor.Name = "cbDoctor";
            cbDoctor.Size = new Size(460, 28);
            cbDoctor.TabIndex = 5;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDateTime.Location = new Point(30, 210);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(160, 21);
            lblDateTime.TabIndex = 6;
            lblDateTime.Text = "Thời gian khám hẹn:";
            // 
            // dtpDateTime
            // 
            dtpDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDateTime.Format = DateTimePickerFormat.Custom;
            dtpDateTime.Location = new Point(30, 235);
            dtpDateTime.Name = "dtpDateTime";
            dtpDateTime.Size = new Size(220, 27);
            dtpDateTime.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatus.Location = new Point(270, 210);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 21);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Trạng thái:";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(270, 235);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(220, 28);
            cbStatus.TabIndex = 9;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(30, 280);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(125, 20);
            lblNotes.TabIndex = 10;
            lblNotes.Text = "Ghi chú / Lý do khám:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(30, 305);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(460, 80);
            txtNotes.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(260, 405);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 38);
            btnSave.TabIndex = 12;
            btnSave.Text = "Lưu thông tin";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(390, 405);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 38);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormAppointmentEdit
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(520, 465);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(cbStatus);
            Controls.Add(lblStatus);
            Controls.Add(dtpDateTime);
            Controls.Add(lblDateTime);
            Controls.Add(cbDoctor);
            Controls.Add(lblDoctor);
            Controls.Add(btnSelectPatient);
            Controls.Add(txtPatientDisplay);
            Controls.Add(lblPatient);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAppointmentEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin Lịch Hẹn";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblPatient;
        private TextBox txtPatientDisplay;
        private Button btnSelectPatient;
        private Label lblDoctor;
        private ComboBox cbDoctor;
        private Label lblDateTime;
        private DateTimePicker dtpDateTime;
        private Label lblStatus;
        private ComboBox cbStatus;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
    }
}