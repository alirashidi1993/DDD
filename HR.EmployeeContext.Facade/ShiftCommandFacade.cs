

using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.EmployeeContext.ApplicationService.Contracts.Shifts;
using HR.EmployeeContext.Facade.Contracts;

namespace HR.EmployeeContext.Facade
{
    public class ShiftCommandFacade : CommandFacadeBase, IShiftCommandFacade
    {
        public ShiftCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void CreateShift(CreateShiftCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void EditShift(EditShiftCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void RemoveShift(RemoveShiftCommand command)
        {
            commandBus.Dispatch(command);
        }
    }
}
