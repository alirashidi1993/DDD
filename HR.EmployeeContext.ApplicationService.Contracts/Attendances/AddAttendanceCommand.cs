using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contracts.Attendances
{
    public class AddAttendanceCommand : Command
    {
        public Guid EmployeeId { get; set; }
        public DateTime WorkingDayDate { get; set; }
        public string EntranceTime { get; set; }
        public string ExitTime { get; set; }
    }
}
