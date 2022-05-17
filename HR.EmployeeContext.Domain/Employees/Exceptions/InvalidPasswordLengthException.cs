using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class InvalidPasswordLengthException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.InvalidPasswordLengthException;
    }
    
}
