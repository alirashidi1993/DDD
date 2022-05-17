using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class GenerateAllEmployeeOverallWorkSummaryCommand : Command
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
