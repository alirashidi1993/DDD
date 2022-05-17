using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Attendances.Services
{
    public  interface IAttendanceConflictCheckService:IDomainService
    {
        bool HasConflict(Guid Id, Guid employeeId, DateTime workingDate, TimeSpan entranceTime, TimeSpan exitTime);
    }
}
