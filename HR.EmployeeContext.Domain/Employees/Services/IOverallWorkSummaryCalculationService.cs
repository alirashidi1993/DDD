using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IOverallWorkSummaryCalculationService:IDomainService
    {
        public OverallWorkSummary CalculateOverallWorkSummary(Employee employee,DateTime startDate, DateTime endDate);
    }
}
