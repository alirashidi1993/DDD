using Framework.Domain;

namespace HR.EmployeeContext.Domain.Attendances.Exceptions
{
    public class NullAttendanceExitTimeException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullAttendanceExitTimeException;
    }
}
