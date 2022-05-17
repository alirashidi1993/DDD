using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class NullOrEmptyLastNameException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullOrEmptyFirstNameException;
    }
    
}
