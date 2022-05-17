using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Shifts;
using HR.EmployeeContext.Domain.Shifts.Services;

namespace HR.EmployeeContext.ApplicationService.Shifts
{
    public class RemoveShiftCommandHandler : ICommandHandler<RemoveShiftCommand>
    {
        private readonly IShiftRepository shiftRepository;

        public RemoveShiftCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public void Execute(RemoveShiftCommand command)
        {
            var shift = shiftRepository.FindById(command.Id);
            shiftRepository.Remove(shift);
        }
    }
}
