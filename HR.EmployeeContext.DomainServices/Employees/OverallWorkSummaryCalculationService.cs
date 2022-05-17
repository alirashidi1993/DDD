using HR.EmployeeContext.Domain.Attendances.Services;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Constants;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Domain.Shifts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.DomainServices.Employees
{
    public class OverallWorkSummaryCalculationService : IOverallWorkSummaryCalculationService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IShiftRepository shiftRepository;

        public OverallWorkSummaryCalculationService(
            IEmployeeRepository employeeRepository,
            IAttendanceRepository attendanceRepository,
            IShiftRepository shiftRepository)
        {
            this.employeeRepository = employeeRepository;
            this.attendanceRepository = attendanceRepository;
            this.shiftRepository = shiftRepository;
        }
        public OverallWorkSummary CalculateOverallWorkSummary(Employee employee, DateTime startDate, DateTime endDate)
        {
            
            var shiftAssignment = employee.EmployeeShiftAssignments.FirstOrDefault(i => i.Archived == false);

            var shiftAssignedToEmployee = shiftRepository.FindById(shiftAssignment.ShiftId);

            var attendances = attendanceRepository.GetByEmployeeIdWithRange(employee.Id, startDate, endDate).ToList();

            var AttendancesGroupedByDay = attendances.GroupBy(i => i.WorkingDayDate).ToList();

            var totalWorkHours = 0D;
            var totalOvertime = 0D;
            var totalUndertime = 0D;

             AttendancesGroupedByDay.ForEach(attendancesOfDay =>
            {
                foreach(var singleAttendanceInDay in attendancesOfDay)
                {
                    var dailyWorkHours = (singleAttendanceInDay.ExitTime - singleAttendanceInDay.EntranceTime).TotalHours;
                    totalWorkHours += dailyWorkHours;

                    var dailyOvertime=dailyWorkHours - ConstantEmployeeWorkHourPerDay.EmployeeWorkHourPerDay;
                    var dailyUndertime= dailyWorkHours - ConstantEmployeeWorkHourPerDay.EmployeeWorkHourPerDay;

                    totalOvertime +=dailyOvertime>0?dailyOvertime:0;
                    totalUndertime+=dailyUndertime<0?Math.Abs(dailyUndertime):0;
                }
            });

            return new OverallWorkSummary
                (startDate, endDate, totalWorkHours, totalOvertime, totalUndertime);
        }
    }
}
