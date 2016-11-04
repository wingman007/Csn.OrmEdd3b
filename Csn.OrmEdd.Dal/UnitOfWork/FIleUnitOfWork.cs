using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csn.OrmEdd3b.Dal.Repositories;
using Csn.OrmEdd3b.Models;
using Csn.OrmEdd3b.Dal.DataMappers;

namespace Csn.OrmEdd3b.Dal.UnitOfWork
{
    public class FileUnitOfWork : IUnitOfWork
    {
        private readonly string _directoryPath;
        public FileUnitOfWork()
        {
            Persons = new GenericFileRepository<Person>(new PersonFileDataMapper());
        }

        public FileUnitOfWork(string directoryPath)
        {
            // Access to the path 'C:\Program Files (x86)\IIS Express\Person.csv' is denied.
            _directoryPath = directoryPath;
            Persons = new GenericFileRepository<Person>(new PersonFileDataMapper(_directoryPath + "\\Person.csv"));
        }
        public IRepository<Person> Persons { get; protected set; }

        public IRepository<Phone> Phones { get; protected set; }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            // throw new NotImplementedException();
            // in this implementation does nothing
        }
    }
}
