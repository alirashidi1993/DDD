using Framework.Core.Domain;
using System;
using System.Linq.Expressions;

namespace Framework.Core.Persistence
{
    public interface IBaseRepository<TAggregateRoot> : IRepository 
        where TAggregateRoot : IAggregateRoot
    {
        public  void Create(TAggregateRoot aggregateRoot);
        public void Edit(TAggregateRoot aggregateRoot);
        bool Any(Expression<Func<TAggregateRoot, bool>> expression);
        public void Remove(TAggregateRoot aggregateRoot);
    }
}
