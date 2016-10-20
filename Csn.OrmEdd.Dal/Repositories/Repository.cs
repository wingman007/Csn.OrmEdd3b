using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csn.OrmEdd.Dal.DataMappers;

namespace Csn.OrmEdd.Dal.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly List<T> _dataSet;

        public Repository(IDataMapper<T> dataMapper)
        {
            _dataSet = dataMapper.GetAll();
        }

        public IEnumerable<T> GetAll()
        {
            // throw new NotImplementedException();
            return _dataSet;
        }

        public T Get(int id)
        {
            // T entityTmp;
            throw new NotImplementedException();
            /*
            // Todo find a btter way to find the elements LINQ
            foreach(T entity in _dataSet)
            {
                // entity.
            }
            return entityTmp;
            */
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> prdicate)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
