using HR.EmployeeContext.ApplicationService.Contracts.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Facade.Contracts
{
    public interface IAttendanceCommandFacade
    {
        void AddAttendance(AddAttendanceCommand command);
    }
}
