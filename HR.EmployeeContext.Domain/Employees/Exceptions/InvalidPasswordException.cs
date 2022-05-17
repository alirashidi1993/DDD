using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class InvalidPasswordException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.InvalidPasswordException;
    }
    
}
