using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.Domain.Employees.Exceptions;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Contract:EntityBase
    {
        public Contract(Guid employeeId,DateTime startDate,DateTime endDate)
        {

            this.EmployeeId = employeeId;

            SetContractDates(startDate, endDate);
            
        }

        protected Contract() { }
        public  void SetContractDates(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new EndDateEarlierThanStartDateException();

            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid EmployeeId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

    }
    
}
