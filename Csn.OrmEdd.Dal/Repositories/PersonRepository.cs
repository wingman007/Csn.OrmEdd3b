using Csn.OrmEdd3b.Dal.DataMappers;
using Csn.OrmEdd3b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal.Repositories
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

        public Person Get(object id)
        {
            // throw new NotImplementedException();
            // _dataMapper.Get(id);
            // return _dataSet.Find(c => c.Id == id);
            return _dataSet.Find(c => c.Id == (int)id);
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

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
