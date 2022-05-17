using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class InvalidNationalCodeLengthException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.InvalidNationalCodeLengthException;
    }
    
}
