namespace DTO_DCM
{
    public class PatientLookupDTO
    {
        public int PatientID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Phone { get; set; }

        public string DisplayText => string.IsNullOrEmpty(Phone)
            ? FullName
            : $"{FullName} - SĐT: {Phone}";
    }
}