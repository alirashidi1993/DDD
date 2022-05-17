using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Facade
{
    public class EmployeeCommandFacade : CommandFacadeBase,IEmployeeCommandFacade
    {
        public EmployeeCommandFacade(ICommandBus commandBus):base(commandBus)
        {

        }
        public void AddContract(CreateContractCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void CreateEmployee(EmployeeCreateCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void EditContract(EditContractCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void EditEmployee(EmployeeEditCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void RemoveEmployee(EmployeeRemoveCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void AssignShift(AssignShiftCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void GenerateAllEmployeeOverallWorkSummary(GenerateAllEmployeeOverallWorkSummaryCommand command)
        {
            commandBus.Dispatch(command);
        }
    }
}
