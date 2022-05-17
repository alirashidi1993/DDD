using Framework.Domain;

namespace HR.EmployeeContext.Domain.Attendances.Exceptions
{
    public class AttendanceExitTimeInvalidFormatException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.AttendanceExitTimeInvalidFormatException;
    }
}
