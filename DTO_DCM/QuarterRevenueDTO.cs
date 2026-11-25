using System;

namespace DTO_DCM
{
    public class QuarterRevenueDTO
    {
        public string EntityName { get; set; } = string.Empty; // Tên Bác sĩ / Bệnh nhân / Thuốc
        public decimal Q1 { get; set; }
        public decimal Q2 { get; set; }
        public decimal Q3 { get; set; }
        public decimal Q4 { get; set; }
        public decimal TC => Q1 + Q2 + Q3 + Q4; // Tổng cộng cả năm
    }
}
