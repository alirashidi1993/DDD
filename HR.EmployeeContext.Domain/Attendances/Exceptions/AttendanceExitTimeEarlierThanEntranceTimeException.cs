using Framework.Domain;

namespace HR.EmployeeContext.Domain.Attendances.Exceptions
{
    public class AttendanceExitTimeEarlierThanEntranceTimeException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.AttendanceExitTimeEarlierThanEntranceTimeException;
    }
}
