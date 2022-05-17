using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class AssignShiftCommandHandler : ICommandHandler<AssignShiftCommand>
    {
        private readonly IEmployeeRepository employeeRepository;

        public AssignShiftCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Execute(AssignShiftCommand command)
        {
            var employee=employeeRepository.FindById(command.EmployeeId);

            var shiftAssignment = new EmployeeShiftAssignment(command.ShiftId, command.AssignmentDate);

            employee.AssignShift(shiftAssignment);
            employeeRepository.Edit(employee);
        }
    }
}
