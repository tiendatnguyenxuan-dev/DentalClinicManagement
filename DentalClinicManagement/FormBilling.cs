using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormBilling : Form
    {
        private readonly InvoiceBLL _invoiceBLL = new();
        private readonly ExaminationBLL _examBLL = new();
        private readonly AccountDTO? _currentUser;
        private int _selectedInvoiceId = 0;

        public FormBilling(AccountDTO? currentUser = null)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void FormBilling_Load(object sender, EventArgs e)
        {
            LoadExamDropdown();
            LoadInvoiceList();
        }

        private void LoadExamDropdown()
        {
            try
            {
                var exams = _examBLL.GetAllExaminations();
                cboExam.DataSource = exams;
                cboExam.DisplayMember = "PatientName";
                cboExam.ValueMember = "ExaminationID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục ca khám: " + ex.Message);
            }
        }

        private void LoadInvoiceList()
        {
            try
            {
                dgvInvoices.AutoGenerateColumns = false;
                dgvInvoices.DataSource = null;
                dgvInvoices.DataSource = _invoiceBLL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message);
            }
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (cboExam.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một ca khám để xuất hóa đơn!", "Thông báo");
                return;
            }

            int examId = Convert.ToInt32(cboExam.SelectedValue);
            int empId = 1; // Default cashier or doctor admin
            decimal discount = nudDiscount.Value;

            var res = _invoiceBLL.CreateInvoiceFromExam(examId, empId, discount);
            if (res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoiceList();
            }
            else
            {
                MessageBox.Show(res.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvInvoices.Rows.Count) return;
            if (dgvInvoices.Rows[e.RowIndex].DataBoundItem is InvoiceDTO inv)
            {
                _selectedInvoiceId = inv.InvoiceID;
                txtInvID.Text = inv.InvoiceID.ToString();
                txtInvPatient.Text = inv.PatientName ?? "";
                txtServiceAmount.Text = inv.TotalAmountService.ToString("N0") + " đ";
                txtMedicineAmount.Text = inv.TotalAmountMedicine.ToString("N0") + " đ";
                txtDiscountShow.Text = inv.DiscountAmount.ToString("N0") + " đ";
                txtFinalTotal.Text = inv.FinalTotal.ToString("N0") + " đ";
                lblPayStatus.Text = $"Trạng thái: [{inv.PaymentStatus}]";

                nudPayAmount.Value = Math.Max(0, inv.FinalTotal);
                btnPay.Enabled = (inv.PaymentStatus != "Paid");

                LoadPayments();
            }
        }

        private void LoadPayments()
        {
            if (_selectedInvoiceId <= 0) return;
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = null;
            dgvPayments.DataSource = _invoiceBLL.GetPaymentsByInvoice(_selectedInvoiceId);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_selectedInvoiceId <= 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần thanh toán!");
                return;
            }

            var payment = new PaymentDTO
            {
                InvoiceID = _selectedInvoiceId,
                Amount = nudPayAmount.Value,
                PaymentMethod = cboPayMethod.Text,
                PaymentDate = DateTime.Now
            };

            var res = _invoiceBLL.AddPayment(payment);
            if (res.IsSuccess)
            {
                MessageBox.Show("Đã thu tiền và cập nhật trạng thái thanh toán!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoiceList();
                LoadPayments();
                lblPayStatus.Text = "Trạng thái: [Paid]";
                btnPay.Enabled = false;
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintPdf_Click(object sender, EventArgs e)
        {
            if (_selectedInvoiceId <= 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in / xuất PDF!", "Thông báo");
                return;
            }

            ExportHelper.PrintInvoiceToPdf(
                txtInvID.Text,
                txtInvPatient.Text,
                (dgvInvoices.CurrentRow?.DataBoundItem as InvoiceDTO)?.DoctorName ?? "BS Nha Khoa",
                txtServiceAmount.Text,
                txtMedicineAmount.Text,
                txtDiscountShow.Text,
                txtFinalTotal.Text
            );
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportToExcel(dgvInvoices, $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd}.csv");
        }
    }
}
