namespace Csn.OrmEdd3b.Dal.UnitOfWork
{
    using Csn.OrmEdd3b.Dal.Repositories;
    using Csn.OrmEdd3b.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EfUnitOfWork(DbContext context)
        {
            _context = context;
            Persons = new GenericEfRepository<Person>(_context);
            Phones = new GenericEfRepository<Phone>(_context);
        }
        public Repositories.IRepository<Models.Person> Persons { get; protected set;}

        public Repositories.IRepository<Models.Phone> Phones { get; protected set; }

        public void SaveChanges()
        {
            // throw new NotImplementedException();
            _context.SaveChanges();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
            _context.Dispose();
        }
    }
}
