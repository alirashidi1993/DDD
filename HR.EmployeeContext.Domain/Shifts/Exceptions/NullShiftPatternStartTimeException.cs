using Framework.Domain;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    public class NullShiftPatternStartTimeException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullShiftPatternStartTimeException;
    }
}
