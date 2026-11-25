using System;

namespace DTO_DCM
{
    public class RevenueReportDTO
    {
        public string TimeLabel { get; set; } = string.Empty;
        public decimal TotalServiceRevenue { get; set; }
        public decimal TotalMedicineRevenue { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetRevenue => (TotalServiceRevenue + TotalMedicineRevenue) - TotalDiscount;
        public int InvoiceCount { get; set; }
    }
}
