using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.ApplicationService.Contracts.Shifts
{
    public class EditShiftCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CycleDurationInDays { get; set; }
        public List<ShiftPatternEditObject> ShiftPatternEditObjects { get; set; }

    }
    public class ShiftPatternEditObject
    {
        public long Id { get; set; }
        public Guid ShiftId { get; set; }
        public int DayOrder { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
