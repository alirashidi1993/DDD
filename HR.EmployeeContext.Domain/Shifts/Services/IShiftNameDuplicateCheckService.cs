using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Shifts.Services
{
    public interface IShiftNameDuplicateCheckService:IDomainService
    {
        bool isDuplicate(Guid Id, string Name);
    }
}
