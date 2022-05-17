using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeEditCommand:Command
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
