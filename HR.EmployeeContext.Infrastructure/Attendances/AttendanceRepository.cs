using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Attendances;
using HR.EmployeeContext.Domain.Attendances.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.EmployeeContext.Infrastructure.Attendances
{
    public class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Attendance FindById(Guid Id)
        {
            return dbContext.Set<Attendance>().FirstOrDefault(i => i.Id == Id);
        }

        public IQueryable<Attendance> GetByEmployeeId(Guid employeeId)
        {
            return dbContext.Set<Attendance>().Where(i => i.EmployeeId == employeeId);
        }

        public IQueryable<Attendance> GetByEmployeeIdWithRange(Guid employeeId, DateTime startRange, DateTime endRange)
        {
            return
                dbContext.Set<Attendance>()
                .Where(i => i.EmployeeId == employeeId &&
                (i.WorkingDayDate >= startRange && i.WorkingDayDate <= endRange));
        }
    }
}
