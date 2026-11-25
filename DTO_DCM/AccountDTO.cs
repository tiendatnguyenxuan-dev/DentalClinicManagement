namespace DTO_DCM
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public int EmployeeID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Admin", "Doctor", "Receptionist", etc.
        public string AccountStatus { get; set; } = "Active";

        public AccountDTO()
        {
        }

        public AccountDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
