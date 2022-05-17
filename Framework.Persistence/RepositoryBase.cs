using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot> : IBaseRepository<TAggregateRoot> where TAggregateRoot : EntityBase, IAggregateRoot
    {
        protected readonly DbContextBase dbContext;

        protected  RepositoryBase(IDbContext dbContext)
        {
            this.dbContext = dbContext as DbContextBase;
        }

        public virtual bool Any(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return dbContext.Set<TAggregateRoot>().Any(expression);
        }

        public virtual void Create(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Add(aggregateRoot);
        }
        public virtual void Edit(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Update(aggregateRoot);
        }
        public virtual void Remove(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
        }
    }
}
