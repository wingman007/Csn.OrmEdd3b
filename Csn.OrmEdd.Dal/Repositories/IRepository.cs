using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd.Dal.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> prdicate);

        void Add(T entity);

        void Remove(T entity); // 
    }
}
