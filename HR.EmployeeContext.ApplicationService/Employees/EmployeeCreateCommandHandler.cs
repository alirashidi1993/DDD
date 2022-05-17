using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using System;
using System.Globalization;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly INationalCodeCheckSumService nationalCodeCheckSumService;
        private readonly INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService;

        public EmployeeCreateCommandHandler(
            IEmployeeRepository employeeRepository,
            INationalCodeCheckSumService nationalCodeCheckSumService,
            INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService
            )
        {
            this.employeeRepository = employeeRepository;
            this.nationalCodeCheckSumService = nationalCodeCheckSumService;
            this.nationalCodeDuplicateCheckService = nationalCodeDuplicateCheckService;
        }
        public void Execute(EmployeeCreateCommand command)
        {
            var personnelCode = GeneratePersonnelCode();

            var employee = new Employee
                (
                nationalCodeCheckSumService,
                nationalCodeDuplicateCheckService,
                command.FirstName, command.LastName,
                command.NationalCode, command.Birthdate,
                command.Password, command.Address, personnelCode
                );

            employeeRepository.Create(employee);
        }

        private long GeneratePersonnelCode()
        {

            var pr = new PersianCalendar();
            var year = pr.GetYear(DateTime.Now).ToString();
            var month = pr.GetMonth(DateTime.Now).ToString();
            month = (month.Length == 1) ? "0" + month : month;
            var rnd = (new Random().Next(1111, 9999)).ToString();
            var generatedNumber = long.Parse(year + month + rnd);

            while (employeeRepository.Any(i => i.PersonnelCode == generatedNumber))
            {
                rnd = (new Random().Next(1111, 9999)).ToString();
                generatedNumber = long.Parse(year + month + rnd);
            }
            return generatedNumber;
        }
    }
}
