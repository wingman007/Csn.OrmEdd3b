namespace Csn.OrmEdd3b.Services
{
    using Csn.OrmEdd3b.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPersonServices
    {
        List<Person> GetAll();
    }
}
