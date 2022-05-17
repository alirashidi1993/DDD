using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class ContractDateConflictException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.ContractDateConflictException;
    }
}
