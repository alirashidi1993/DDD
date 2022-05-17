using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class InvalidBirthdateFormatException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.InvalidBirthdateFormatException;
    }
    
}
