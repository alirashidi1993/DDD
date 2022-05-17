using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Contracts = new HashSet<Contract>();
            EmployeeShiftAssignments = new HashSet<EmployeeShiftAssignment>();
        }

        public Guid Id { get; set; }
        public long PersonnelCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<EmployeeShiftAssignment> EmployeeShiftAssignments { get; set; }
    }
}
