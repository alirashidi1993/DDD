using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class AssignShiftCommand:Command
    {
        public Guid EmployeeId { get; set; }
        public Guid ShiftId { get; set; }
        public DateTime AssignmentDate { get; set; }
    }
}
