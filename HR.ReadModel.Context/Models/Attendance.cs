using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class Attendance
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime WorkingDayDate { get; set; }
        public TimeSpan EntranceTime { get; set; }
        public TimeSpan ExitTime { get; set; }
    }
}
