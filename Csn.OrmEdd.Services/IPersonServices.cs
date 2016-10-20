namespace Csn.OrmEdd.Services
{
    using Csn.OrmEdd.Models;
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
