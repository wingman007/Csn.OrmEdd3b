using Csn.OrmEdd3b.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        PersonRepository Persons { get; } // private set;

        void SaveAll();
    }
}
