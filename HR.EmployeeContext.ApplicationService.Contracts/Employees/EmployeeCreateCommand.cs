using Framework.Core.ApplicationService;
using System;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeCreateCommand:Command
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string NationalCode { get;  set; }
        public DateTime Birthdate { get;  set; }
        public string Password { get;  set; }
        public string Address { get;  set; }
    }
}
