using System;

namespace DTO_DCM
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public int ExaminationID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmountMedicine { get; set; }
        public decimal TotalAmountService { get; set; }
        public decimal DiscountAmount { get; set; }
        public string PaymentStatus { get; set; } = "Unpaid"; // 'Unpaid', 'PartiallyPaid', 'Paid'
        public string InvoiceStatus { get; set; } = "Issued"; // 'Issued', 'Cancelled'
        public string? CancelReason { get; set; }

        public decimal FinalTotal => (TotalAmountMedicine + TotalAmountService) - DiscountAmount;

        // Display
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? CashierName { get; set; }
    }

    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "Cash"; // 'Cash', 'BankTransfer', 'Card', 'EWallet'
        public string PaymentStatus { get; set; } = "Completed"; // 'Completed', 'Reversed'
        public int? ReversedBy { get; set; }
    }
}
