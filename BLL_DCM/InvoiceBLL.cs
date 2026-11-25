using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class InvoiceBLL
    {
        private readonly InvoiceDAL _dal = new();

        public List<InvoiceDTO> GetAll() => _dal.GetAll();

        public OperationResult<int> CreateInvoiceFromExam(int examId, int employeeId, decimal discount)
        {
            if (examId <= 0) return OperationResult<int>.Failure("Chưa chọn ca khám hợp lệ!");
            try
            {
                int invoiceId = _dal.CreateInvoiceFromExam(examId, employeeId, discount);
                return OperationResult<int>.Success(invoiceId, "Lập hóa đơn viện phí thành công!");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.Failure("Lỗi: " + ex.Message);
            }
        }

        public OperationResult AddPayment(PaymentDTO payment)
        {
            if (payment.Amount <= 0) return OperationResult.Failure("Số tiền thanh toán phải lớn hơn 0!");
            try
            {
                bool ok = _dal.AddPayment(payment);
                return ok ? OperationResult.Success("Xác nhận thanh toán thành công!") : OperationResult.Failure("Thanh toán thất bại!");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure("Lỗi: " + ex.Message);
            }
        }

        public List<PaymentDTO> GetPaymentsByInvoice(int invoiceId) => _dal.GetPaymentsByInvoice(invoiceId);

        public List<InvoiceServiceDetailDTO> GetServicesByInvoice(int invoiceId)
        {
            if (invoiceId <= 0) return new List<InvoiceServiceDetailDTO>();
            return _dal.GetServicesByInvoice(invoiceId);
        }

        public List<PrescriptionDetailDTO> GetPrescriptionsByInvoice(int invoiceId)
        {
            if (invoiceId <= 0) return new List<PrescriptionDetailDTO>();
            return _dal.GetPrescriptionsByInvoice(invoiceId);
        }
    }
}
