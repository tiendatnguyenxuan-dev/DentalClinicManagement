using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DCM
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string? ServiceCategory { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Unit { get; set; }
    }
}
