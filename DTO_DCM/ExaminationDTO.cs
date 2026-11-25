using System;

namespace DTO_DCM
{
    public class ExaminationDTO
    {
        public int ExaminationID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int? AppointmentID { get; set; }
        public DateTime ExaminationDate { get; set; } = DateTime.Now;
        public string? ExaminationReason { get; set; }
        public string? Diagnosis { get; set; }
        public string? Conclusion { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string ExaminationStatus { get; set; } = "Draft"; // 'Draft', 'Finalized'

        // Display properties for UI
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? DoctorName { get; set; }
    }

    public class ExaminationServiceDTO
    {
        public int ExaminationServiceID { get; set; }
        public int ExaminationID { get; set; }
        public int ServiceID { get; set; }
        public string? ToothNumber { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public string? Notes { get; set; }
        public bool IsVoided { get; set; } = false;

        // Display properties
        public string? ServiceName { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
