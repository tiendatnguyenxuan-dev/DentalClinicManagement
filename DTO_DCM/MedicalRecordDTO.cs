using System;

namespace DTO_DCM
{
    public class MedicalRecordDTO
    {
        public int MedicalRecordID { get; set; }
        public int PatientID { get; set; }
        public string RecordCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public string RecordStatus { get; set; } = "Active";
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // Extra info for display
        public string? PatientName { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? MedicalHistory { get; set; }
        public string? Allergies { get; set; }
    }
}
