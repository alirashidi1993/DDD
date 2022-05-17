using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class EmployeeShiftAssignment
    {
        public long Id { get; set; }
        public Guid ShiftId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public bool Archived { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
