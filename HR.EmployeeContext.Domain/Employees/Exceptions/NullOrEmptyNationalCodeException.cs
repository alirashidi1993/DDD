using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class NullOrEmptyNationalCodeException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullOrEmptyNationalCodeException;
    }
}
