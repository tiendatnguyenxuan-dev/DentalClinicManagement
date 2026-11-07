using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_DCM
{
    public class WorkScheduleDTO
    {
        public int ScheduleID { get; set; }
        public int DoctorID { get; set; }
        public string? DoctorName { get; set; }
        public DateTime WorkDate { get; set; }
        public string Shift { get; set; } = string.Empty;
    }
}
