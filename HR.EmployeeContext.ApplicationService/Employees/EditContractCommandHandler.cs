using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using System.Linq;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EditContractCommandHandler:ICommandHandler<EditContractCommand>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EditContractCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Execute(EditContractCommand command)
        {
            var employee = employeeRepository.FindById(command.EmployeeId);
            
            employee.EditContract(command.Id,command.StartDate,command.EndDate);

            employeeRepository.Edit(employee);
        }
    }
}
