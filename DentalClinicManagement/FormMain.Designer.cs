namespace DentalClinicManagement
{
    partial class FormMain
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
            btnLogout = new Button();
            lblUserInfo = new Label();
            lblHeaderTitle = new Label();
            panelSidebar = new Panel();
            btnReports = new Button();
            btnBilling = new Button();
            btnAppointments = new Button();
            btnManagePatients = new Button();
            panelContent = new Panel();
            lblWelcome = new Label();
            panelHeader.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SlateBlue;
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Controls.Add(lblUserInfo);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(831, 45);
            panelHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.Crimson;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(726, 11);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(88, 24);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserInfo.Font = new Font("Segoe UI", 9.5F);
            lblUserInfo.ForeColor = Color.White;
            lblUserInfo.Location = new Point(420, 15);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(293, 17);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Xin chào: ... | Quyền: ...";
            lblUserInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(13, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(295, 21);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "HỆ THỐNG PHÒNG KHÁM NHA KHOA";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(240, 242, 245);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnBilling);
            panelSidebar.Controls.Add(btnAppointments);
            panelSidebar.Controls.Add(btnManagePatients);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 45);
            panelSidebar.Margin = new Padding(3, 2, 3, 2);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(192, 375);
            panelSidebar.TabIndex = 1;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.White;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.Location = new Point(9, 135);
            btnReports.Margin = new Padding(3, 2, 3, 2);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(175, 34);
            btnReports.TabIndex = 3;
            btnReports.Text = " Báo Cáo Doanh Thu";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnBilling
            // 
            btnBilling.BackColor = Color.White;
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Segoe UI", 10F);
            btnBilling.Location = new Point(9, 94);
            btnBilling.Margin = new Padding(3, 2, 3, 2);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(175, 34);
            btnBilling.TabIndex = 2;
            btnBilling.Text = " Đơn Thuốc / Hóa Đơn";
            btnBilling.TextAlign = ContentAlignment.MiddleLeft;
            btnBilling.UseVisualStyleBackColor = false;
            // 
            // btnAppointments
            // 
            btnAppointments.BackColor = Color.White;
            btnAppointments.FlatAppearance.BorderSize = 0;
            btnAppointments.FlatStyle = FlatStyle.Flat;
            btnAppointments.Font = new Font("Segoe UI", 10F);
            btnAppointments.Location = new Point(9, 52);
            btnAppointments.Margin = new Padding(3, 2, 3, 2);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(175, 34);
            btnAppointments.TabIndex = 1;
            btnAppointments.Text = " Lịch Khám / Điều Trị";
            btnAppointments.TextAlign = ContentAlignment.MiddleLeft;
            btnAppointments.UseVisualStyleBackColor = false;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // btnManagePatients
            // 
            btnManagePatients.BackColor = Color.White;
            btnManagePatients.FlatAppearance.BorderSize = 0;
            btnManagePatients.FlatStyle = FlatStyle.Flat;
            btnManagePatients.Font = new Font("Segoe UI", 10F);
            btnManagePatients.Location = new Point(9, 11);
            btnManagePatients.Margin = new Padding(3, 2, 3, 2);
            btnManagePatients.Name = "btnManagePatients";
            btnManagePatients.Size = new Size(175, 34);
            btnManagePatients.TabIndex = 0;
            btnManagePatients.Text = " Quản lý Bệnh Nhân";
            btnManagePatients.TextAlign = ContentAlignment.MiddleLeft;
            btnManagePatients.UseVisualStyleBackColor = false;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(lblWelcome);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(192, 45);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(639, 375);
            panelContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.Font = new Font("Segoe UI", 14F);
            lblWelcome.ForeColor = Color.DimGray;
            lblWelcome.Location = new Point(35, 135);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(569, 68);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng bạn đến với Hệ thống Quản lý Nha khoa!\r\nVui lòng chọn chức năng từ menu bên trái.";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 420);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(702, 385);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dental Clinic Management System";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSidebar.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Label lblUserInfo;
        private Button btnLogout;
        private Panel panelSidebar;
        private Button btnManagePatients;
        private Button btnAppointments;
        private Button btnBilling;
        private Button btnReports;
        private Panel panelContent;
        private Label lblWelcome;
    }
}

