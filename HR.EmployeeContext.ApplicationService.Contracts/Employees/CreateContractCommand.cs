using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class CreateContractCommand : Command
    {
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
