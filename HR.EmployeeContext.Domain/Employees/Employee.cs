using Framework.Core.Domain;
using Framework.Domain;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Employee : EntityBase, IAggregateRoot
    {

        private INationalCodeCheckSumService nationalCodeCheckSumService;
        private INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService;

        public Employee
            (
            INationalCodeCheckSumService nationalCodeCheckSumService,
            INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService,
            string firstName, string lastName, string nationalCode,
            DateTime birthdate, string password, string address, long personnelCode)
        {
            
            this.nationalCodeCheckSumService = nationalCodeCheckSumService;
            this.nationalCodeDuplicateCheckService = nationalCodeDuplicateCheckService;
            PersonnelCode = personnelCode;

            setFullName(firstName, lastName);
            setPassword(password);
            setNationalCode(nationalCode, nationalCodeCheckSumService, nationalCodeDuplicateCheckService);
            setBirthdate(birthdate);
            setAddress(address);

        }
        protected Employee()
        {

        }

        public void AssignShift(EmployeeShiftAssignment employeeShiftAssignment)
        {
            if (!_Contracts.Any())
                throw new AssignShiftToEmployeeWithoutContractException();

            var lastContract = _Contracts.OrderBy(i => i.StartDate).Last();

            ValidateShiftAssigmentDateRange(employeeShiftAssignment, lastContract);

            ArchiveLastAssignment();

            _EmployeeShiftAssignments.Add(employeeShiftAssignment);
        }

        
        public void AddContract(Contract contract)
        {
            if (_Contracts.Any())
            {
                var lastContract = _Contracts.OrderBy(i => i.StartDate).Last();
                if (contract.StartDate < lastContract.EndDate)
                    throw new StartDateEarlierThanLastEndDateException();
            }
            _Contracts.Add(contract);
        }
        public void EditContract(Guid contractId, DateTime startDate, DateTime endDate)
        {
            var contract = _Contracts.FirstOrDefault(i => i.Id == contractId);
            if (contract == null)
                throw new RequestedContractNotFoundException();

            CheckContractDateConflict(contractId, startDate, endDate);
            contract.SetContractDates(startDate, endDate);
        }

        public OverallWorkSummary CalculateOverallWorkSummary(
            IOverallWorkSummaryCalculationService overallWorkSummaryCalculationService,
            DateTime startDate, DateTime endDate)
        {
            return overallWorkSummaryCalculationService.CalculateOverallWorkSummary(this,startDate, endDate);
        }
        public void AddOverallWorkSummary(OverallWorkSummary workSummary)
        {
            _OverallWorkSummaries.Add(workSummary);
        }


        private void ArchiveLastAssignment()
        {
            if (_EmployeeShiftAssignments.Any())
            {
                var lastAssignment = _EmployeeShiftAssignments.OrderBy(i => i.AssignmentDate).Last();
                lastAssignment.setArchived(true);
            }
        }
        private void ValidateShiftAssigmentDateRange(EmployeeShiftAssignment employeeShiftAssignment, Contract lastContract)
        {
            if (employeeShiftAssignment.AssignmentDate > lastContract.EndDate ||
                           employeeShiftAssignment.AssignmentDate < lastContract.StartDate
                          )
            {
                throw new ShiftAssignmentMustBeInContractDateRangeException();
            }
        }
        private void CheckContractDateConflict(Guid contractId, DateTime startDate, DateTime endDate)
        {
            if (_Contracts.Any(i => (
            (startDate >= i.StartDate && endDate <= i.EndDate) ||
            (startDate >= i.StartDate && startDate <= i.EndDate) ||
            (endDate <= i.EndDate && endDate >= i.StartDate)
            )
                         && i.Id != contractId))
                throw new ContractDateConflictException();
        }

        public void setAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new NullOrEmptyAddressException();
            this.Address = address;
        }
        public void setBirthdate(DateTime birthdate)
        {
            var age = DateTime.Now.Year - birthdate.Year;

            if (age < 18 || age > 40)
                throw new EmployeeAgeOutOfRangeException();

            this.Birthdate = birthdate;
        }
        public void setNationalCode(string nationalCode,
            INationalCodeCheckSumService nationalCodeCheckSumService,
            INationalCodeDuplicateCheckService nationalCodeDuplicateCheckService)
        {
            if (string.IsNullOrEmpty(nationalCode))
                throw new NullOrEmptyNationalCodeException();

            if (nationalCode.Length != 10)
                throw new InvalidNationalCodeLengthException();

            if (!nationalCode.Any(char.IsDigit))
                throw new NationalCodeNonNumberException();

            if (nationalCodeDuplicateCheckService.isDuplicate(Id, nationalCode))
                throw new DuplicateNationalCodeException();

            if (!nationalCodeCheckSumService.isValid(nationalCode))
                throw new InvalidNationalCodeException();

            this.NationalCode = nationalCode;
        }
        public void setPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new NullOrEmptyPasswordException();

            if (!(password.Length > 8 && password.Length < 15))
                throw new InvalidPasswordLengthException();

            if (!(password.Any(char.IsUpper) && password.Any(char.IsLower)))
                throw new InvalidPasswordException();

            this.Password = password;
        }
        public void setFullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new NullOrEmptyFirstNameException();

            this.FirstName = firstName;

            if (string.IsNullOrEmpty(lastName))
                throw new NullOrEmptyLastNameException();

            this.LastName = lastName;
        }


        public long PersonnelCode { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }

        public IReadOnlyList<Contract> Contracts => _Contracts.AsReadOnly();
        public IReadOnlyList<EmployeeShiftAssignment> EmployeeShiftAssignments => _EmployeeShiftAssignments.AsReadOnly();
        public IReadOnlyList<OverallWorkSummary> OverallWorkSummaries => _OverallWorkSummaries.AsReadOnly();

        private List<Contract> _Contracts = new List<Contract>();
        private List<EmployeeShiftAssignment> _EmployeeShiftAssignments = new List<EmployeeShiftAssignment>();
        private List<OverallWorkSummary> _OverallWorkSummaries=new List<OverallWorkSummary>();
        
        
    }
}
