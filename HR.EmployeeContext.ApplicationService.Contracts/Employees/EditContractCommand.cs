using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EditContractCommand:Command
    {

        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
