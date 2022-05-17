using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class StartDateEarlierThanLastEndDateException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.StartDateEarlierThanLastEndDateException;
    }
}
