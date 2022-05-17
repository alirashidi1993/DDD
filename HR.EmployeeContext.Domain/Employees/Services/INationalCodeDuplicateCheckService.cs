using Framework.Core.Domain;
using System;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface INationalCodeDuplicateCheckService:IDomainService
    {
        public bool isDuplicate(Guid Id,string nationalCode);
    }
}
