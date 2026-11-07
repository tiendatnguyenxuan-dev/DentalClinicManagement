namespace DentalClinicManagement
{
    partial class FormLogin
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
            labelTitle = new Label();
            labelUsername = new Label();
            labelPassword = new Label();
            txtNameLogin = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            lblHint = new Label();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.DarkSlateBlue;
            labelTitle.Location = new Point(230, 35);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(188, 38);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ĐĂNG NHẬP";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(80, 110);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(110, 20);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Tên đăng nhập:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(80, 160);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(73, 20);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Mật khẩu:";
            // 
            // txtNameLogin
            // 
            txtNameLogin.Location = new Point(210, 107);
            txtNameLogin.Name = "txtNameLogin";
            txtNameLogin.PlaceholderText = "Nhập tài khoản (vd: admin, bacsi, letan)";
            txtNameLogin.Size = new Size(330, 27);
            txtNameLogin.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(210, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu (mặc định: 123456)";
            txtPassword.Size = new Size(330, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.RoyalBlue;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(210, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 38);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(390, 215);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 38);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(135, 275);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(385, 19);
            lblHint.TabIndex = 7;
            lblHint.Text = "Tài khoản test: admin/123456, bacsi/123456, letan/123456";
            lblHint.Click += lblHint_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(790, 414);
            Controls.Add(lblHint);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtNameLogin);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Dental Clinic Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelUsername;
        private Label labelPassword;
        private TextBox txtNameLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblHint;
    }
}

