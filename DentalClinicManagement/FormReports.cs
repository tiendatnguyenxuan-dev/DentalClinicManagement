using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormReports : Form
    {
        private readonly ReportBLL _reportBLL = new();

        public FormReports()
        {
            InitializeComponent();
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;
            nudYear.Value = DateTime.Today.Year;
            cboQuarterType.SelectedIndex = 0;

            LoadSummaryCards();
            LoadRevenueData();
            LoadQuarterMatrix();
        }

        private void LoadSummaryCards()
        {
            try
            {
                var summary = _reportBLL.GetDashboardSummary();
                lblTotalRevenueValue.Text = summary.TotalRevenue.ToString("N0") + " VNĐ";
                lblTotalExamsValue.Text = summary.TotalExams.ToString("N0") + " ca";
                lblTotalPatientsValue.Text = summary.TotalPatients.ToString("N0") + " người";
                lblTotalAppointmentsValue.Text = summary.TotalAppointments.ToString("N0") + " lịch";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tổng hợp: " + ex.Message);
            }
        }

        private void LoadRevenueData()
        {
            try
            {
                var list = _reportBLL.GetRevenueByDate(dtpFromDate.Value, dtpToDate.Value);
                dgvRevenue.AutoGenerateColumns = false;
                dgvRevenue.DataSource = null;
                dgvRevenue.DataSource = list;

                decimal sum = 0;
                foreach (var item in list) sum += item.NetRevenue;
                lblPeriodTotal.Text = $"Tổng thực thu trong kỳ: {sum:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu doanh thu: " + ex.Message);
            }
        }

        private void LoadQuarterMatrix()
        {
            try
            {
                int year = (int)nudYear.Value;
                int type = cboQuarterType.SelectedIndex; // 0: Bác sĩ/NV, 1: Bệnh nhân, 2: Thuốc

                List<QuarterRevenueDTO> list = type switch
                {
                    1 => _reportBLL.GetRevenueByPatientAndQuarter(year),
                    2 => _reportBLL.GetRevenueByMedicineAndQuarter(year),
                    _ => _reportBLL.GetRevenueByDoctorAndQuarter(year)
                };

                colQ_Entity.HeaderText = type switch
                {
                    1 => "Khách hàng / Bệnh nhân",
                    2 => "Tên thuốc / Sản phẩm",
                    _ => "Nhân viên / Bác sĩ"
                };

                dgvQuarter.AutoGenerateColumns = false;
                dgvQuarter.DataSource = null;
                dgvQuarter.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng ma trận quý: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadRevenueData();
        }

        private void btnViewQuarter_Click(object sender, EventArgs e)
        {
            LoadQuarterMatrix();
        }

        private void dgvRevenue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRevenue.Rows.Count) return;

            if (dgvRevenue.Rows[e.RowIndex].DataBoundItem is RevenueReportDTO item)
            {
                if (DateTime.TryParseExact(item.TimeLabel, "dd/MM/yyyy", 
                    System.Globalization.CultureInfo.InvariantCulture, 
                    System.Globalization.DateTimeStyles.None, out DateTime targetDate))
                {
                    using var frm = new FormDailyRevenueDetail(targetDate);
                    frm.ShowDialog(this);
                }
            }
        }
    }
}
