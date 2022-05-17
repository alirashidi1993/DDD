using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HR.Persistence
{
    public class HRDesignTimeDbContext : IDesignTimeDbContextFactory<HRDbContext>
    {
        public HRDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =new  DbContextOptionsBuilder<HRDbContext>();
            optionsBuilder.UseSqlServer(@"server=RASHIDI-A;database=HR;integrated security=true");
            return new HRDbContext(optionsBuilder.Options);
        }
    }
}
