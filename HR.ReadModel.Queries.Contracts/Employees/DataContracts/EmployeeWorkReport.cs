using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ReadModel.Queries.Contracts.Employees.DataContracts
{
    public class EmployeeWorkReport
    {
        public EmployeeDTO Employee { get; set; }
        public DateTime WorkingDay { get; set; }
        public int TotalWorkHours { get; set; }

    }
}
