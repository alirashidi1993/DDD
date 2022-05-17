using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class NationalCodeNonNumberException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NationalCodeNonNumberException;
    }
    
}
