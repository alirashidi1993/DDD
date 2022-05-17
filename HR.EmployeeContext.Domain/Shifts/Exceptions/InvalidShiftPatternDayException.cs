using Framework.Domain;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    public class InvalidShiftPatternDayException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.InvalidShiftPatternDayException;
    }
}
