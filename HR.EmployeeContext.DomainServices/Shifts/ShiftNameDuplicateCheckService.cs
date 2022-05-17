using HR.EmployeeContext.Domain.Shifts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.DomainServices.Shifts
{
    public class ShiftNameDuplicateCheckService : IShiftNameDuplicateCheckService
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftNameDuplicateCheckService(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public bool isDuplicate(Guid Id, string Name)
        {
            return shiftRepository.Any(i => i.Id != Id && i.Name == Name);
        }
    }
}
