using Framework.Domain;

namespace HR.EmployeeContext.Domain.Attendances.Exceptions
{
    public class NullAttendanceEntranceTimeException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullAttendanceEntranceTimeException;
    }
}
