using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class NullOrEmptyAddressException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullOrEmptyAddressException;
    }
}
