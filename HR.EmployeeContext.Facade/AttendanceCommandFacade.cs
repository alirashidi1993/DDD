using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.EmployeeContext.ApplicationService.Contracts.Attendances;
using HR.EmployeeContext.Facade.Contracts;

namespace HR.EmployeeContext.Facade
{
    public class AttendanceCommandFacade : CommandFacadeBase,IAttendanceCommandFacade
    {
        public AttendanceCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void AddAttendance(AddAttendanceCommand command)
        {
            commandBus.Dispatch(command);
        }
    }
}
