

namespace Csn.OrmEdd3b.Dal.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    class GenericEfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        protected readonly IDbSet<TEntity> _entitySet;
        public GenericEfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<TEntity>(); 
        }
        public IEnumerable<TEntity> GetAll()
        {
            // throw new NotImplementedException();
            return _entitySet.ToList();
        }

        public TEntity Get(object id) //int
        {
            // throw new NotImplementedException();
            return _entitySet.Find(id);
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            // throw new NotImplementedException();
            return _entitySet.Where(predicate); // FindAll on list also notice for  Expression and Where we need
            // if it is a list
            // return ((IQueryable)_entitySet).Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            // return Context.Set<TEntity>().SingleOrDefault(predicate);
            return _entitySet.SingleOrDefault(predicate); // It was asking initially for <> but from the context somehow it was OK
        }

        public void Add(TEntity entity)
        {
            // throw new NotImplementedException();
            _entitySet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            // throw new NotImplementedException();
            _entitySet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _entitySet.Attach(entity);
            }
            entry.State = EntityState.Modified;
            return entity;
        }
    }
}
