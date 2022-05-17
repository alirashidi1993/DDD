using HR.EmployeeContext.ApplicationService.Contracts.Employees;

namespace HR.EmployeeContext.Facade.Contracts
{
    public interface IEmployeeCommandFacade
    {
        void CreateEmployee(EmployeeCreateCommand command);
        void EditEmployee(EmployeeEditCommand command);
        void RemoveEmployee(EmployeeRemoveCommand command);
        void AddContract(CreateContractCommand command);
        void EditContract(EditContractCommand command);
        void AssignShift(AssignShiftCommand command);
        void GenerateAllEmployeeOverallWorkSummary(GenerateAllEmployeeOverallWorkSummaryCommand command);
    }
}
