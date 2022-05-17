using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class EmployeeAgeOutOfRangeException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.EmployeeAgeOutOfRangeException;
    }
    
}
