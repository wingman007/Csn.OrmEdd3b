using Csn.OrmEdd.Dal.DataMappers;
using Csn.OrmEdd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd.Dal.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly List<Person> _dataSet;

        IDataMapper<Person> _dataMapper;
        public PersonRepository(IDataMapper<Person> dataMapper)
        {
            _dataSet = dataMapper.GetAll();
            _dataMapper = dataMapper;
        }
        public IEnumerable<Person> GetAll()
        {
            // throw new NotImplementedException();
            return _dataSet;
        }

        public Person Get(int id)
        {
            // throw new NotImplementedException();
            // _dataMapper.Get(id);
            return _dataSet.Find(c => c.Id == id);
        }

        public IEnumerable<Person> Find(System.Linq.Expressions.Expression<Func<Person, bool>> prdicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
