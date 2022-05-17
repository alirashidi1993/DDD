using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftPatterns = new HashSet<ShiftPattern>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CycleDurationInDays { get; set; }

        public virtual ICollection<ShiftPattern> ShiftPatterns { get; set; }
    }
}
