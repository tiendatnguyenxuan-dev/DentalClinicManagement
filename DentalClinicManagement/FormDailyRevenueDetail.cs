using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormDailyRevenueDetail : Form
    {
        private readonly DateTime _targetDate;
        private readonly ReportBLL _reportBLL = new();
        private List<DailyRevenueDetailDTO> _dataList = new();

        public FormDailyRevenueDetail(DateTime targetDate)
        {
            InitializeComponent();
            _targetDate = targetDate;
        }

        private void FormDailyRevenueDetail_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"CHI TIẾT DOANH THU NGÀY: {_targetDate:dd/MM/yyyy}";
            lblSubtitle.Text = $"Danh sách chi tiết các ca khám và hóa đơn phát hành trong ngày {_targetDate:dd/MM/yyyy}";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _dataList = _reportBLL.GetDailyRevenueDetails(_targetDate);
                dgvDetails.AutoGenerateColumns = false;
                dgvDetails.DataSource = null;
                dgvDetails.DataSource = _dataList;

                decimal totalRev = 0;
                decimal totalService = 0;
                decimal totalMedicine = 0;
                foreach (var item in _dataList)
                {
                    totalRev += item.FinalTotal;
                    totalService += item.TotalAmountService;
                    totalMedicine += item.TotalAmountMedicine;
                }

                lblSummary.Text = $"Tổng số: {_dataList.Count} hóa đơn/ca khám | Tiền DV: {totalService:N0} VNĐ | Tiền thuốc: {totalMedicine:N0} VNĐ | Thực thu: {totalRev:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportHelper.ExportToExcel(dgvDetails, $"DoanhThu_ChiTiet_{_targetDate:yyyyMMdd}.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
