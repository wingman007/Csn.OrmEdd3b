

namespace Csn.OrmEdd3b.WebApi.Controllers
{
    using Csn.OrmEdd3b.Dal;
    using Csn.OrmEdd3b.Dal.UnitOfWork;
    using Csn.OrmEdd3b.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class PersonsController : ApiController
    {
        // private IUnitOfWork db = new EfUnitOfWork(new CsnOrmEdd3bDbContext());
        private AdoUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fmi\Source\Repos\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb;Persist Security Info=True"));
        public IEnumerable<Person> Get()
        {
            // return strings;
            return db.Persons.GetAll();
        }

        public Person Get(int id)
        {
            return db.Persons.Get(id);
        }

        public void Post([FromBody] Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public void Put(int id, [FromBody] Person person)
        {
            // Person personFromDb = db.Persons.Get(id);
            // 
            person.Id = id;
            db.Persons.Update(person);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Person personFromDb = db.Persons.Get(id);
            db.Persons.Remove(personFromDb);
            db.SaveChanges();
        }
    }
}
