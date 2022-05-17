using Framework.Core.Persistence;
using System;

namespace HR.EmployeeContext.Domain.Shifts.Services
{
    public interface IShiftRepository : IBaseRepository<Shift>
    {
        public Shift FindById(Guid Id);
    }
}
