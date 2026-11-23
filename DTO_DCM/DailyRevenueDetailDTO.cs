using System;

namespace DTO_DCM
{
    public class DailyRevenueDetailDTO
    {
        public int InvoiceID { get; set; }
        public int ExaminationID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceTime => InvoiceDate.ToString("HH:mm");
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? Diagnosis { get; set; }
        public decimal TotalAmountService { get; set; }
        public decimal TotalAmountMedicine { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalTotal => (TotalAmountService + TotalAmountMedicine) - DiscountAmount;
        public string PaymentStatus { get; set; } = "Unpaid";
    }
}
