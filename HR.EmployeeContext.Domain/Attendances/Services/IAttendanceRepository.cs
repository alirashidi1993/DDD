using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Attendances.Services
{
    public interface IAttendanceRepository:IBaseRepository<Attendance>
    {
        Attendance FindById(Guid Id);
        IQueryable<Attendance> GetByEmployeeId(Guid employeeId);
        IQueryable<Attendance> GetByEmployeeIdWithRange(Guid employeeId, DateTime startRange, DateTime endRange);
    }
}
