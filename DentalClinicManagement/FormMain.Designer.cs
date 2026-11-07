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
            btnManagePatients = new Button();
            btnAppointments = new Button();
            btnBilling = new Button();
            btnServices = new Button();
            btnReports = new Button();
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
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(950, 60);
            panelHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.Crimson;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(830, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 32);
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
            lblUserInfo.Location = new Point(480, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(335, 23);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Xin chào: ... | Quyền: ...";
            lblUserInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(15, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(331, 28);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "HỆ THỐNG PHÒNG KHÁM NHA KHOA";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(240, 242, 245);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnServices);
            panelSidebar.Controls.Add(btnBilling);
            panelSidebar.Controls.Add(btnAppointments);
            panelSidebar.Controls.Add(btnManagePatients);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 60);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 500);
            panelSidebar.TabIndex = 1;
            // 
            // btnManagePatients
            // 
            btnManagePatients.BackColor = Color.White;
            btnManagePatients.FlatAppearance.BorderSize = 0;
            btnManagePatients.FlatStyle = FlatStyle.Flat;
            btnManagePatients.Font = new Font("Segoe UI", 10F);
            btnManagePatients.Location = new Point(10, 15);
            btnManagePatients.Name = "btnManagePatients";
            btnManagePatients.Size = new Size(200, 45);
            btnManagePatients.TabIndex = 0;
            btnManagePatients.Text = " Quản lý Bệnh Nhân";
            btnManagePatients.TextAlign = ContentAlignment.MiddleLeft;
            btnManagePatients.UseVisualStyleBackColor = false;
            btnManagePatients.Click += btnManagePatients_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.BackColor = Color.White;
            btnAppointments.FlatAppearance.BorderSize = 0;
            btnAppointments.FlatStyle = FlatStyle.Flat;
            btnAppointments.Font = new Font("Segoe UI", 10F);
            btnAppointments.Location = new Point(10, 70);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(200, 45);
            btnAppointments.TabIndex = 1;
            btnAppointments.Text = " Lịch Khám / Điều Trị";
            btnAppointments.TextAlign = ContentAlignment.MiddleLeft;
            btnAppointments.UseVisualStyleBackColor = false;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // btnBilling
            // 
            btnBilling.BackColor = Color.White;
            btnBilling.FlatAppearance.BorderSize = 0;
            btnBilling.FlatStyle = FlatStyle.Flat;
            btnBilling.Font = new Font("Segoe UI", 10F);
            btnBilling.Location = new Point(10, 125);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(200, 45);
            btnBilling.TabIndex = 2;
            btnBilling.Text = " Đơn Thuốc / Hóa Đơn";
            btnBilling.TextAlign = ContentAlignment.MiddleLeft;
            btnBilling.UseVisualStyleBackColor = false;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.White;
            btnServices.FlatAppearance.BorderSize = 0;
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 10F);
            btnServices.Location = new Point(10, 180);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(200, 45);
            btnServices.TabIndex = 3;
            btnServices.Text = " Quản lý Dịch Vụ";
            btnServices.TextAlign = ContentAlignment.MiddleLeft;
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.White;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.Location = new Point(10, 235);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(200, 45);
            btnReports.TabIndex = 4;
            btnReports.Text = " Báo Cáo Doanh Thu";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(lblWelcome);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 60);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(730, 500);
            panelContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.ForeColor = Color.DimGray;
            lblWelcome.Location = new Point(40, 180);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(650, 90);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng bạn đến với Hệ thống Quản lý Nha khoa!\r\nVui lòng chọn chức năng từ menu bên trái.";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 560);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            MinimumSize = new Size(800, 500);
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
        private Button btnServices;
        private Button btnReports;
        private Panel panelContent;
        private Label lblWelcome;
    }
}