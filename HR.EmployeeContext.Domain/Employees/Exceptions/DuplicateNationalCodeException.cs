using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class DuplicateNationalCodeException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.DuplicateNationalCodeException;
    }
}
