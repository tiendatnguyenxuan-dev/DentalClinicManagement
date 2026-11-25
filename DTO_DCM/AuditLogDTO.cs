using System;

namespace DTO_DCM
{
    public class AuditLogDTO
    {
        public long LogID { get; set; }
        public int? AccountID { get; set; }
        public string? Username { get; set; }
        public string ActionType { get; set; } = "INSERT"; // 'INSERT','UPDATE','DELETE','RESTORE','CANCEL','REVERSE'
        public string EntityName { get; set; } = string.Empty;
        public int EntityID { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
