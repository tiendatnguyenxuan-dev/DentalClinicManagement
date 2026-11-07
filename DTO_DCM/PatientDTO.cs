using System;

namespace DTO_DCM
{
    public class PatientDTO
    {
        public int PatientID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? MedicalHistory { get; set; }
        public string? Allergies { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
