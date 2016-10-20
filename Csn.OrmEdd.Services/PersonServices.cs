
namespace Csn.OrmEdd.Services
{
    using Csn.OrmEdd.Dal.DataMappers;
    using Csn.OrmEdd.Models;
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
