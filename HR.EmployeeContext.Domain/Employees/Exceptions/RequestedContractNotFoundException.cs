using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class RequestedContractNotFoundException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.RequestedContractNotFoundException;
    }
}
