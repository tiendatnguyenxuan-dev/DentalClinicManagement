using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormAuditLog : Form
    {
        private readonly AuditLogBLL _auditBLL = new();

        public FormAuditLog()
        {
            InitializeComponent();
        }

        private void FormAuditLog_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void LoadLogs()
        {
            try
            {
                var logs = _auditBLL.GetAllLogs();
                dgvAudit.AutoGenerateColumns = false;
                dgvAudit.DataSource = null;
                dgvAudit.DataSource = logs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhật ký hệ thống: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }
    }
}
