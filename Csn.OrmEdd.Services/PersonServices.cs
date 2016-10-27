
namespace Csn.OrmEdd3b.Services
{
    using Csn.OrmEdd3b.Dal.DataMappers;
    using Csn.OrmEdd3b.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PersonServices : IPersonServices
    {
        public List<Person> GetAll()
        {
            IDataMapper<Person> dalPerson = new PersonDataMapper();
            List<Person> persons = dalPerson.GetAll();

            return persons;
        }
    }
}
