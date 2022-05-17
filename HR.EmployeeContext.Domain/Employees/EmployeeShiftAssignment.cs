using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees
{
    public class EmployeeShiftAssignment:ValueObject<EmployeeShiftAssignment>
    {
        protected EmployeeShiftAssignment() { }
        public EmployeeShiftAssignment(Guid shiftId,DateTime assignmentDate,bool archived=false)
        {
            this.ShiftId = shiftId;
            this.AssignmentDate = assignmentDate;
            setArchived(archived);
        }

        public void setArchived(bool archived)
        {
            this.Archived = archived;
        }

        public Guid ShiftId { get; private set; }
        public DateTime AssignmentDate { get; private set; }
        public bool Archived { get;private set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            
            yield return this.ShiftId;
            yield return this.AssignmentDate;
            yield return this.Archived;
        }
    }
}
