using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.ExceptionResources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{

    public class NullOrEmptyFirstNameException : DomainException
    {
        public override string Message => ExceptionResources.Exceptions.NullOrEmptyFirstNameException;
    }
    
}
