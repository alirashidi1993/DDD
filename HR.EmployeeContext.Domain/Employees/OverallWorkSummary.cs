using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees
{
    public class OverallWorkSummary : ValueObject<OverallWorkSummary>
    {

        protected OverallWorkSummary() { }
        public OverallWorkSummary(
            DateTime startDate,
            DateTime endDate,
            double totalWorkInHours,
            double totalOvertimeInHours,
            double totalUndertimeInHours
            )
        {
            StartDate = startDate;
            EndDate = endDate;
            TotalWorkInHours = totalWorkInHours;
            TotalOvertimeInHours = totalOvertimeInHours;
            TotalUndertimeInHours = totalUndertimeInHours;
        }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double TotalWorkInHours { get; private set; }
        public double TotalOvertimeInHours { get; private set; }
        public double TotalUndertimeInHours { get; private set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return StartDate;
            yield return EndDate;
            yield return TotalWorkInHours;
            yield return TotalOvertimeInHours;
            yield return TotalUndertimeInHours;
        }
    }
}
