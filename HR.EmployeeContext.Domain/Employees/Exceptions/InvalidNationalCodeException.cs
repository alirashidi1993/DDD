using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class InvalidNationalCodeException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.InvalidNationalCodeException;
    }
    
}
