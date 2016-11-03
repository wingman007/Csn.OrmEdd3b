using Csn.OrmEdd3b.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal
{
    public class CsnOrmEdd3bDbContext : IdentityDbContext<User>
    {
        public CsnOrmEdd3bDbContext()
            : base("CsnOrmEdd3bConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }

        // public System.Data.Entity.DbSet<Csn.OrmEdd3b.Models.Person> People { get; set; }
    }
}
