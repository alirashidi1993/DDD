using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class GenerateAllEmployeeOverallWorkSummaryCommandHandler : ICommandHandler<GenerateAllEmployeeOverallWorkSummaryCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IOverallWorkSummaryCalculationService overallWorkSummaryCalculationService;

        public GenerateAllEmployeeOverallWorkSummaryCommandHandler(
            IEmployeeRepository employeeRepository,
            IOverallWorkSummaryCalculationService overallWorkSummaryCalculationService
            )
        {
            this.employeeRepository = employeeRepository;
            this.overallWorkSummaryCalculationService = overallWorkSummaryCalculationService;
        }
        public void Execute(GenerateAllEmployeeOverallWorkSummaryCommand command)
        {
            var employees = employeeRepository.GetAll();
            foreach (var employee in employees)
            {
                var calculation = employee
                    .CalculateOverallWorkSummary(overallWorkSummaryCalculationService, command.StartDate, command.EndDate);
                employee.AddOverallWorkSummary(calculation);

                employeeRepository.Edit(employee);
            }

        }
    }
}
