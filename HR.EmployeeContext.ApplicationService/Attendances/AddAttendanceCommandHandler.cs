using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Attendances;
using HR.EmployeeContext.Domain.Attendances;
using HR.EmployeeContext.Domain.Attendances.Services;

namespace HR.EmployeeContext.ApplicationService.Attendances
{
    public class AddAttendanceCommandHandler : ICommandHandler<AddAttendanceCommand>
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IAttendanceConflictCheckService attendanceConflictCheckService;

        public AddAttendanceCommandHandler(IAttendanceRepository attendanceRepository,
            IAttendanceConflictCheckService attendanceConflictCheckService
            )
        {
            this.attendanceRepository = attendanceRepository;
            this.attendanceConflictCheckService = attendanceConflictCheckService;
        }
        public void Execute(AddAttendanceCommand command)
        {
            var attendance = new Attendance(attendanceConflictCheckService,
                command.EmployeeId,
                command.WorkingDayDate,
                command.EntranceTime,
                command.ExitTime);

            attendanceRepository.Create(attendance);
        }
    }
}
