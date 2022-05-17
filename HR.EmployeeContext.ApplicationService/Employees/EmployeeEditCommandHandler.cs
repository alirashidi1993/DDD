using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeEditCommandHandler : ICommandHandler<EmployeeEditCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly INationalCodeCheckSumService nationalCodeCheckSumService;
        private readonly INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService;

        public EmployeeEditCommandHandler(
            IEmployeeRepository employeeRepository,
            INationalCodeCheckSumService nationalCodeCheckSumService,
            INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService
            )
        {
            this.employeeRepository = employeeRepository;
            this.nationalCodeCheckSumService = nationalCodeCheckSumService;
            this.nationalCodeDuplicateCheckService = nationalCodeDuplicateCheckService;
        }
        public void Execute(EmployeeEditCommand command)
        {
            var employee = employeeRepository.FindById(command.Id);

            employee.setFullName(command.FirstName, command.LastName);
            employee.setNationalCode(command.NationalCode,nationalCodeCheckSumService,nationalCodeDuplicateCheckService);
            employee.setAddress(command.Address);
            employee.setPassword(command.Password);
            employee.setBirthdate(command.Birthdate);

            employeeRepository.Edit(employee);
        }
    }
}
