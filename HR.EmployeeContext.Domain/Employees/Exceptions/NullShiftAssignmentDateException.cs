using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class NullShiftAssignmentDateException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullShiftAssignmentDateException;
    }
}
