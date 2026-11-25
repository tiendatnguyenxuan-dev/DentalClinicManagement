namespace DTO_DCM
{
    public class DoctorLookupDTO
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? SpecialtyName { get; set; }

        public string DisplayText => string.IsNullOrEmpty(SpecialtyName)
            ? FullName
            : $"{FullName} ({SpecialtyName})";
    }
}