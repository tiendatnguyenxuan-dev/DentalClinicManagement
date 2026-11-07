namespace DTO_DCM
{
    public class AccountDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Admin", "Doctor", "Receptionist"

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

