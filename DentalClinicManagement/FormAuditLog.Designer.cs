namespace DentalClinicManagement
{
    partial class FormAuditLog
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
            panelActions = new Panel();
            btnRefresh = new Button();
            dgvAudit = new DataGridView();
            colLogID = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            colEntity = new DataGridViewTextBoxColumn();
            colEntityID = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAudit).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(192, 57, 43);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 50);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NHẬT KÝ HOẠT ĐỘNG HỆ THỐNG (AUDIT LOG)";
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnRefresh);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(0, 50);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(1000, 45);
            panelActions.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.SteelBlue;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(15, 8);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 30);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvAudit
            // 
            dgvAudit.AllowUserToAddRows = false;
            dgvAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAudit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAudit.Columns.AddRange(new DataGridViewColumn[] { colLogID, colUsername, colAction, colEntity, colEntityID, colDesc, colTime });
            dgvAudit.Dock = DockStyle.Fill;
            dgvAudit.Location = new Point(0, 95);
            dgvAudit.MultiSelect = false;
            dgvAudit.Name = "dgvAudit";
            dgvAudit.ReadOnly = true;
            dgvAudit.RowHeadersVisible = false;
            dgvAudit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAudit.Size = new Size(1000, 505);
            dgvAudit.TabIndex = 2;
            // 
            // colLogID
            // 
            colLogID.DataPropertyName = "LogID";
            colLogID.FillWeight = 40F;
            colLogID.HeaderText = "ID";
            colLogID.Name = "colLogID";
            colLogID.ReadOnly = true;
            // 
            // colUsername
            // 
            colUsername.DataPropertyName = "Username";
            colUsername.FillWeight = 80F;
            colUsername.HeaderText = "Tài khoản";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colAction
            // 
            colAction.DataPropertyName = "ActionType";
            colAction.FillWeight = 60F;
            colAction.HeaderText = "Hành động";
            colAction.Name = "colAction";
            colAction.ReadOnly = true;
            // 
            // colEntity
            // 
            colEntity.DataPropertyName = "EntityName";
            colEntity.FillWeight = 70F;
            colEntity.HeaderText = "Bảng dữ liệu";
            colEntity.Name = "colEntity";
            colEntity.ReadOnly = true;
            // 
            // colEntityID
            // 
            colEntityID.DataPropertyName = "EntityID";
            colEntityID.FillWeight = 50F;
            colEntityID.HeaderText = "ID dữ liệu";
            colEntityID.Name = "colEntityID";
            colEntityID.ReadOnly = true;
            // 
            // colDesc
            // 
            colDesc.DataPropertyName = "Description";
            colDesc.FillWeight = 160F;
            colDesc.HeaderText = "Chi tiết thao tác";
            colDesc.Name = "colDesc";
            colDesc.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.DataPropertyName = "CreatedAt";
            colTime.FillWeight = 90F;
            colTime.HeaderText = "Thời gian";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // FormAuditLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvAudit);
            Controls.Add(panelActions);
            Controls.Add(panelTop);
            Name = "FormAuditLog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhật ký hệ thống";
            Load += FormAuditLog_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAudit).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Panel panelActions;
        private Button btnRefresh;
        private DataGridView dgvAudit;
        private DataGridViewTextBoxColumn colLogID;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colEntity;
        private DataGridViewTextBoxColumn colEntityID;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colTime;
    }
}
