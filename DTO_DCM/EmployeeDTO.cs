using System;

namespace DTO_DCM
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = "Doctor"; // 'Admin','Doctor','Receptionist','Cashier','Nurse'
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
        public int? SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }
        public string? PracticeLicenseNumber { get; set; }
        public string EmploymentStatus { get; set; } = "Active"; // 'Active','Resigned'
    }

    public class SpecialtyDTO
    {
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
