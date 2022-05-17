using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeRemoveCommand:Command
    {
        public Guid Id { get; set; }
    }
}
