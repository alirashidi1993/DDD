using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeRemoveCommandHandler : ICommandHandler<EmployeeRemoveCommand>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeRemoveCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeRemoveCommand command)
        {
            var employee = employeeRepository.FindById(command.Id);
            employeeRepository.Remove(employee);
        }
    }
}
