using Framework.Domain;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    public class ShiftPatternEndTimeInvalidFormatException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.ShiftPatternEndTimeInvalidFormatException;
    }
}
