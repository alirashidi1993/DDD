using HR.EmployeeContext.Domain.Attendances;
using HR.EmployeeContext.Domain.Attendances.Services;
using HR.EmployeeContext.Domain.Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.DomainServices.Attendances
{
    public class AttendanceConflictCheckService : IAttendanceConflictCheckService
    {
        private readonly IAttendanceRepository attendanceRepository;

        public AttendanceConflictCheckService(
            IAttendanceRepository attendanceRepository
            )
        {
            this.attendanceRepository = attendanceRepository;
        }
        public bool HasConflict(Guid Id,Guid employeeId, DateTime workingDate, TimeSpan entranceTime, TimeSpan exitTime)
        {
            var attendances = attendanceRepository
                .GetByEmployeeId(employeeId)
                .Where(i => i.WorkingDayDate == workingDate && i.Id != Id);

            if (!attendances.Any()) return false;

            if (attendances.Any(i =>
             (entranceTime >= i.EntranceTime && exitTime <= i.ExitTime) ||
             (entranceTime >= i.EntranceTime && entranceTime <= i.ExitTime) ||
             (exitTime <= i.EntranceTime && exitTime >= i.ExitTime)
            ))
            {
                return true;
            }

            return false;
        }
    }
}
