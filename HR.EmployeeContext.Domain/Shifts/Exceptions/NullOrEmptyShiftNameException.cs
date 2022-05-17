using Framework.Domain;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    internal class NullOrEmptyShiftNameException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullOrEmptyShiftNameException;
    }
}
