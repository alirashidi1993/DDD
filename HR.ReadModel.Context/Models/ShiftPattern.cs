using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class ShiftPattern
    {
        public long Id { get; set; }
        public int DayOrder { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid ShifId { get; set; }

        public virtual Shift Shif { get; set; }
    }
}
