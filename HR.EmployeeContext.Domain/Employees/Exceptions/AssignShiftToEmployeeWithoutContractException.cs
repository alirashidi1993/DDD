using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class AssignShiftToEmployeeWithoutContractException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.AssignShiftToEmployeeWithoutContractException;
    }
}
