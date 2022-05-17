using Framework.Core.Domain;
using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {       
        Employee FindById(Guid Id);
        List<Employee> GetAll();
    }
}
