using Csn.OrmEdd3b.Dal.Repositories;
using Csn.OrmEdd3b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // PersonRepository Persons { get; } // private set;
        IRepository<Person> Persons { get; }
        IRepository<Phone> Phones { get; }
        void SaveChanges(); // SaveAll();
    }
}
