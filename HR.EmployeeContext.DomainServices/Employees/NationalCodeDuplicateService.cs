using Framework.Core.Domain;
using HR.EmployeeContext.Domain.Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.DomainServices.Employees
{
    public class NationalCodeDuplicateService : INationalCodeDuplicateCheckService
    {
        private readonly IEmployeeRepository employeeRepository;

        public NationalCodeDuplicateService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public bool isDuplicate(Guid Id,string nationalCode)
        {
            return employeeRepository.Any(i => i.NationalCode == nationalCode && i.Id!=Id);
        }
    }
}
