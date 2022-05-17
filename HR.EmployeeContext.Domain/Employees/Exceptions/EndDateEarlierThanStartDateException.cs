using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class EndDateEarlierThanStartDateException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.EndDateEarlierThanStartDateException;
    }
}
