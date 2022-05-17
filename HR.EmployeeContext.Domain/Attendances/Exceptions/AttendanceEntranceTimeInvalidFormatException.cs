using Framework.Domain;

namespace HR.EmployeeContext.Domain.Attendances.Exceptions
{
    public class AttendanceEntranceTimeInvalidFormatException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.AttendanceEntranceTimeInvalidFormatException;
    }
}
