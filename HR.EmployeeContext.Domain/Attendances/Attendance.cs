using Framework.Core.Domain;
using Framework.Domain;
using HR.EmployeeContext.Domain.Attendances.Exceptions;
using HR.EmployeeContext.Domain.Attendances.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Attendances
{
    public class Attendance : EntityBase, IAggregateRoot
    {
        private readonly IAttendanceConflictCheckService attendanceConflictCheckService;

        protected Attendance() { }

        public Attendance(
            IAttendanceConflictCheckService attendanceConflictCheckService,
            Guid employeeId,DateTime workingDayDate,string entranceTime,string exitTime)
        {
            this.attendanceConflictCheckService = attendanceConflictCheckService;
            EmployeeId = employeeId;
            WorkingDayDate = workingDayDate;

            setWorkingTimes(entranceTime,exitTime);
        }

        private void setWorkingTimes(string entranceTime, string exitTime)
        {
            ValidateWorkTimes(entranceTime, exitTime);

            var _entranceTime = entranceTime.ConvertToTimeSpan();
            var _exitTime = exitTime.ConvertToTimeSpan();

            CheckConflicts(_entranceTime, _exitTime);

            EntranceTime= _entranceTime;
            ExitTime= _exitTime;
            
        }

        private void CheckConflicts(TimeSpan entranceTime,TimeSpan exitTime)
        {
            if (attendanceConflictCheckService.HasConflict(Id,EmployeeId,WorkingDayDate,entranceTime,exitTime))
                throw new AttendanceTimeRangeConflictException();
        }

        private void ValidateWorkTimes(string entranceTime, string exitTime)
        {
            if (entranceTime == null)
                throw new NullAttendanceEntranceTimeException();

            if (exitTime == null)
                throw new NullAttendanceExitTimeException();

            if (!IsTimeValid(entranceTime))
                throw new AttendanceEntranceTimeInvalidFormatException();

            if (!IsTimeValid(exitTime))
                throw new AttendanceExitTimeInvalidFormatException();
        }

        
        private bool IsTimeValid(string time)
        {
            if (!time.Contains(':'))
                return false;

            var hour = time.Split(':')[0];
            var minute = time.Split(':')?[1];

            if (hour.Length != 2 || minute?.Length != 2)
                return false;

            return true;
        }
        public Guid EmployeeId { get;private set; }
        public DateTime WorkingDayDate { get;private set; }
        public TimeSpan EntranceTime { get;private set; }
        public TimeSpan ExitTime { get;private set; }

    }
}
