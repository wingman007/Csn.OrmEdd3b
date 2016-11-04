using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csn.OrmEdd3b.Dal.DataMappers;

namespace Csn.OrmEdd3b.Dal.Repositories
{
    public class GenericAdoRepository<T> : IRepository<T> where T: class
    {
        // private List<T> _dataSet;

        private readonly IDataMapper<T> _dataMapper;

        public GenericAdoRepository(IDataMapper<T> dataMapper)
        {
            // _dataSet = dataMapper.GetAll();
            // I have no choice but to work directly with the DB not with objects in memory
            // insert and update will change the DB but not in memory collection
            _dataMapper = dataMapper;
        }

        public IEnumerable<T> GetAll()
        {
            // throw new NotImplementedException();
            // return _dataSet;
            // I cano be sure with ADO that the in memory and DB are in sync. I am forced to work with the DB
            return _dataMapper.GetAll();
        }

        public T Get(object id)
        {
            // T entityTmp;
            // throw new NotImplementedException();
            /*
            // Todo find a btter way to find the elements LINQ
            foreach(T entity in _dataSet)
            {
                // entity.
            }
            return entityTmp;
            */
            // return _dataSet.Find(e => e.Id == id); // is not going to work. There is no guarantee you will find it by Id
            // you are not sure there is such property Id
            // return _dataSet.FindAll()

            // In this case we have 2 variants we can force all models to have Id property, but this still 
            // doesn't fix the problem, because the problem with the syn between the DB and in memory remains
            // So I am forced again to use the Data Mapper directly
            // I have DB where the Primary Keys are not called Id
            return _dataMapper.Get(id);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            // throw new NotImplementedException();
            // return _dataSet.FindAll()

            // here I can "lazy load" the objects and do search in memory
            IQueryable<T> dataSet = (IQueryable<T>)_dataMapper.GetAll();
            return dataSet.Where<T>(predicate);
            // return (IQueryable)_dataSet.Where(predicate);
        }

        public void Add(T entity)
        {
            // throw new NotImplementedException();
            // I have no choice but to cheat and write directly in the DB
            _dataMapper.Insert(entity);
        }

        public void Remove(T entity)
        {
            // throw new NotImplementedException(); // Again I have to send this to the under layer it knows better the object
            // Othervise I have to make sure each object has Id with Interface or Abstract class
            _dataMapper.Delete(entity);
        }


        public T Update(T entity) // Change the method return value to void
        {
            // throw new NotImplementedException();
            _dataMapper.Update(entity);
            return entity; // ???
        }
    }
}
