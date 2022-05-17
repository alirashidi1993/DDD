using Framework.Domain;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    public class DuplicateShiftNameException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.DuplicateShiftNameException;
    }
}
