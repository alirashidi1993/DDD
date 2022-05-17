using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class CreateContractCommandHandler : ICommandHandler<CreateContractCommand>
    {
        private readonly IEmployeeRepository employeeRepository;

        public CreateContractCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void Execute(CreateContractCommand command)
        {
            var employee = employeeRepository.FindById(command.EmployeeId);
            var contract = new Contract(employee.Id, command.StartDate, command.EndDate);

            employee.AddContract(contract);

            employeeRepository.Edit(employee);
        }
    }
}
