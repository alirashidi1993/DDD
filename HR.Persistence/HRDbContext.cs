using Framework.Persistence;
using HR.EmployeeContext.Infrastructure.Employees.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence
{
    public class HRDbContext : DbContextBase
    {
        public HRDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeMapping).Assembly);
        }
    }
}
