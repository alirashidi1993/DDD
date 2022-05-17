using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.ApplicationService.Contracts.Shifts
{
    public class CreateShiftCommand : Command
    {
        public string Name { get; set; }
        public int CycleDurationInDays { get; set; }
        public List<ShiftPatternCreateObject> ShiftPatternCreateObjects { get; set;}
       
    }
    public class ShiftPatternCreateObject
    {
        public int DayOrder { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
    
}
