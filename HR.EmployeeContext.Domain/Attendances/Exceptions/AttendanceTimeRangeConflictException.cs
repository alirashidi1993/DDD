using Framework.Domain;

namespace HR.EmployeeContext.Domain.Attendances.Exceptions
{
    public class AttendanceTimeRangeConflictException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.AttendanceTimeRangeConflictException;
    }
}
