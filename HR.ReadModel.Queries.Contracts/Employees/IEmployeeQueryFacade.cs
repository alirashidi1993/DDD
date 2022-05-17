using HR.ReadModel.Queries.Contracts.Employees.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ReadModel.Queries.Contracts.Employees
{
    public interface IEmployeeQueryFacade
    {
        EmployeeWorkReport GetEmployeeWorkReport(Guid employeeId,DateTime from,DateTime to);
    }
}
