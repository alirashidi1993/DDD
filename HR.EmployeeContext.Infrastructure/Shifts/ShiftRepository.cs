using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Shifts;
using HR.EmployeeContext.Domain.Shifts.Services;
using System;
using System.Linq;

namespace HR.EmployeeContext.Infrastructure.Shifts
{
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Shift FindById(Guid Id)
        {
            return dbContext.Set<Shift>()
                .FirstOrDefault(s => s.Id == Id);
        }
    }
}
