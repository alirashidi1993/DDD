using Framework.Core.ApplicationService;
using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Framework.Domain;
using Framework.Core.Domain;

namespace Framework.ApplicationService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextBase dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext as DbContextBase;
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void RollBack()
        {
            foreach (var item in dbContext.ChangeTracker.Entries().Where(i => i.State == EntityState.Unchanged))
            {
                if (item.State == EntityState.Added)
                    item.State = EntityState.Detached;

                if (item.State == EntityState.Modified)
                    item.State = EntityState.Unchanged;

                if (item.State == EntityState.Deleted)
                    item.State = EntityState.Unchanged;
            }
        }
    }
}
