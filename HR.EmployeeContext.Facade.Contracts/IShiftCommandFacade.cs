
using HR.EmployeeContext.ApplicationService.Contracts.Shifts;

namespace HR.EmployeeContext.Facade.Contracts
{
    public interface IShiftCommandFacade
    {
        void CreateShift(CreateShiftCommand command);
        void EditShift(EditShiftCommand command);
        void RemoveShift(RemoveShiftCommand command);

    }
}
