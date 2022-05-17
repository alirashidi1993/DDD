using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.EmployeeContext.Infrastructure.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext context) : base(context) { }

        public Employee FindById(Guid Id)
        {
            return dbContext.Set<Employee>()
                .Include(i => i.Contracts)
                .FirstOrDefault(i => i.Id == Id);
        }

        public List<Employee> GetAll()
        {
            var e = dbContext.Set<Employee>()
            .Include(i => i.Contracts)
            .ToList();
            return e;
        }
    }
}
