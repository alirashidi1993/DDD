using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ReadModel.Queries.Contracts.Employees.DataContracts
{
    public class EmployeeDTO
    {
         Guid Id { get; set; }
         long PersonnelCode { get;  set; }
         string FirstName { get;  set; }
         string LastName { get;  set; }
         string NationalCode { get;  set; }
         DateTime Birthdate { get;  set; }
         string Address { get;  set; }

    }
}
