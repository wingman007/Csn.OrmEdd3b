using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csn.OrmEdd3b.Dal.Repositories;
using Csn.OrmEdd3b.Models;
using System.Data;
using Csn.OrmEdd3b.Dal.DataMappers;

namespace Csn.OrmEdd3b.Dal.UnitOfWork
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;

        // private readonly IDataMapper<T> _dataMapper;
        public AdoUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            Persons = new GenericAdoRepository<Person>(new PersonAdoDataMapper(_connection));
        }
        public IRepository<Person> Persons { get; protected set; }

        public IRepository<Phone> Phones { get; protected set; }

        public void Dispose()
        {
            // throw new NotImplementedException();
            // doesn't do anything, but it is required by the Interface
        }

        public void SaveChanges()
        {
            // We are chaeting . We are not using in memry collections. In fact alwais working with the DB.
            // throw new NotImplementedException();
        }
    }
}
