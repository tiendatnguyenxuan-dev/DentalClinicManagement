using System;

namespace DTO_DCM
{
    public class MedicineDTO
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string? Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class PrescriptionDTO
    {
        public int PrescriptionID { get; set; }
        public int ExaminationID { get; set; }
        public DateTime PrescriptionDate { get; set; } = DateTime.Today;
        public string? Instructions { get; set; }
        public string PrescriptionStatus { get; set; } = "Draft"; // 'Draft', 'Issued', 'Cancelled'
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
    }

    public class PrescriptionDetailDTO
    {
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
        public int? InvoiceID { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Dosage { get; set; }
        public bool IsVoided { get; set; }

        // Display properties
        public string? MedicineName { get; set; }
        public string? Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
