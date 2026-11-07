using System;

namespace DTO_DCM
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public string AppointmentStatus { get; set; } = "Pending";
        public string? Notes { get; set; }

        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? DoctorName { get; set; }
        public string? SpecialtyName { get; set; }

        public AppointmentDTO() { }

        public AppointmentDTO(int appointmentID, int patientID, int doctorID, DateTime appointmentDateTime, string appointmentStatus, string? notes)
        {
            AppointmentID = appointmentID;
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDateTime = appointmentDateTime;
            AppointmentStatus = appointmentStatus;
            Notes = notes;
        }
    }
}