using Csn.OrmEdd3b.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal
{
    public class CsnOrmEdd3bDbContext : IdentityDbContext<User>
    {
        public CsnOrmEdd3bDbContext()
            : base("CsnOrmEdd3bConnection")
        {
        }
    }
}
