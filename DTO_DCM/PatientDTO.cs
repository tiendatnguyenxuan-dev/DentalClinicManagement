using System;

namespace DTO_DCM
{
    public class PatientDTO
    {
        public string PatientId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = "Nam";
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-20);
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;

        public PatientDTO() { }

        public PatientDTO(string patientId, string fullName, string gender, DateTime dob, string phone, string address, string medicalHistory)
        {
            PatientId = patientId;
            FullName = fullName;
            Gender = gender;
            DateOfBirth = dob;
            PhoneNumber = phone;
            Address = address;
            MedicalHistory = medicalHistory;
        }
    }
}

