using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class NullOrEmptyPasswordException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullOrEmptyPasswordException;
    }
}
