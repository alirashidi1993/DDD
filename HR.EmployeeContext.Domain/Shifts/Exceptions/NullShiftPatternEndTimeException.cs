using Framework.Domain;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    public class NullShiftPatternEndTimeException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullShiftPatternEndTimeException;
    }
}
