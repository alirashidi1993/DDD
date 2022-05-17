using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Shifts.Exceptions
{
    public class CycleDurationInDaysNotQualToPatternsCountException:DomainException
    {
        public override string Message => ExceptionResources.Exceptions.CycleDurationInDaysNotQualToPatternsCountException;
    }
}
