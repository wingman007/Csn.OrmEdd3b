﻿namespace Csn.OrmEdd3b.WebApi.Controllers
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
    using System.Web.Http.Description;

    public class PersonsController : ApiController
    {
        private IUnitOfWork db = new EfUnitOfWork(new CsnOrmEdd3bDbContext());
        // private AdoUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fmi\Source\Repos\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb;Persist Security Info=True"));
        // private AdoUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Stoyan\Source\Repos\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb;Persist Security Info=True"));

        public IEnumerable<Person> Get()
        {
            // return strings;
            using(db)
            {
                return db.Persons.GetAll();
            }      
        }

        public Person Get(int id)
        {
            using (db)
            {
                return db.Persons.Get(id);
            }
        }

        //[ResponseType(typeof(Person))]
        //public IHttpActionResult PostPerson(Person person)
        //public HttpResponseMessage Post([FromBody] Person person) //public IHttpActionResult Post([FromBody] Person person)

        // [HttpPost]
        public IHttpActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);

            // or 

            //try
            //{
            //    using (db)
            //    {
            //        db.Persons.Add(person);
            //        db.SaveChanges();

            //        var message = Request.CreateResponse(HttpStatusCode.Created, person);
            //        message.Headers.Location = new Uri(Request.RequestUri + person.Id.ToString());

            //        return message;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
        }

        //public void Put(int id, [FromBody] Person person)

        //  [ResponseType(typeof(void))]
        // public IHttpActionResult Put(int id, Person person) // PutPerson
        // public HttpResponseMessage Put(int id, Person person) // PutPerson
        public IHttpActionResult Put(int id, [FromBody] Person person) // PutPerson
        {
            // Person personFromDb = db.Persons.Get(id);
            // 

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
                // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "person id doesn't match"); //, ex);
            }

            if (null == db.Persons.Get(id))
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                //    "Person with Id " + id.ToString() + " not found to update");
            }

            // db.Entry(person).State = EntityState.Modified;

            try
            {
                person.Id = id;
                db.Persons.Update(person);
                db.SaveChanges();
            }
            //catch (DbUpdateConcurrencyException)
            catch(Exception e)
            {
                 throw e;
            }

            return StatusCode(HttpStatusCode.NoContent); // 204

            // return Ok(person); ???
            // or
            // return Request.CreateResponse(HttpStatusCode.OK, person);


            //person.Id = id;
            //db.Persons.Update(person);
            //db.SaveChanges();
        }

        //[ResponseType(typeof(Person))]
        public IHttpActionResult Delete(int id)
        {
            Person personFromDb = db.Persons.Get(id);
            if (personFromDb == null)
            {
                return NotFound();
            }

            db.Persons.Remove(personFromDb);
            db.SaveChanges();

            return Ok(personFromDb);
        }
    }
}

/*
Autogenerated
namespace Csn.OrmEdd3b.WebApi.Controllers
{
    public class PersonsController : ApiController
    {
        private CsnOrmEdd3bDbContext db = new CsnOrmEdd3bDbContext();

        // GET: api/Persons
        public IQueryable<Person> GetPeople()
        {
            return db.Persons;
        }

        // GET: api/Persons/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/Persons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Persons
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/Persons/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Persons.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.Persons.Count(e => e.Id == id) > 0;
        }
    }
} 
 
*/
/*
 Another example
         public IEnumerable<Person> Get()
        {
            using (PersonsDBEntities entities = new PersonsDBEntities())
            {
                return entities.Persons.ToList();
            }
        }

        public Persons Get(int id)
        {
            using (PersonsDBEntities entities = new PersonsDBEntities())
            {
                return entities.Persons.FirstOrDefault(e => e.ID == id);
            }
        }


    public HttpResponseMessage Post([FromBody] Employee employee)
{
    try
    {
        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        {
            entities.Employees.Add(employee);
            entities.SaveChanges();

            var message = Request.CreateResponse(HttpStatusCode.Created, employee);
            message.Headers.Location = new Uri(Request.RequestUri + 
                employee.ID.ToString());

            return message;
        }
    }
    catch (Exception ex)
    {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
    }
}


    public HttpResponseMessage Put(int id, [FromBody]Employee employee)
{
    try
    {
        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        {
            var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Employee with Id " + id.ToString() + " not found to update");
            }
            else
            {
                entity.FirstName = employee.FirstName;
                entity.LastName = employee.LastName;
                entity.Gender = employee.Gender;
                entity.Salary = employee.Salary;

                entities.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
        }
    }
    catch (Exception ex)
    {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
    }
}

public HttpResponseMessage Delete(int id)
{
    try
    {
        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        {
            var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
            if (entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Employee with Id = " + id.ToString() + " not found to delete");
            }
            else
            {
                entities.Employees.Remove(entity);
                entities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
    catch (Exception ex)
    {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
    }
}
*/

/*
 Error example
 {
  "Message": "An error has occurred.",
  "ExceptionMessage": "'C:\\Users\\fmi\\Source\\Repos\\Csn.OrmEdd3b\\Csn.OrmEdd.Console\\App_Data\\CsnOrmEdd3b.mdb' is not a valid path.  Make sure that the path name is spelled correctly and that you are connected to the server on which the file resides.",
  "ExceptionType": "System.Data.OleDb.OleDbException",
  "StackTrace": "   at System.Web.Http.ApiController.<InvokeActionWithExceptionFilters>d__1.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Web.Http.Dispatcher.HttpControllerDispatcher.<SendAsync>d__0.MoveNext()"
}

    Example of the answer:

    [
  {
    "Id": 1,
    "Name": "Stoyan",
    "FamilyName": "Cheresharov",
    "BirthDate": "1964-03-29T00:00:00",
    "Address": "7 Avliga str.",
    "Phones": null
  },
  {
    "Id": 2,
    "Name": "Emil",
    "FamilyName": "Dodnikov",
    "BirthDate": "1996-05-05T00:00:00",
    "Address": "bul. Bulgaria 45, 4001, Plovdiv, Bulgaria",
    "Phones": null
  },
  {
    "Id": 4,
    "Name": "Ivan",
    "FamilyName": "Ivanov",
    "BirthDate": "2000-10-21T00:00:00",
    "Address": "bul. Bulgaria 123",
    "Phones": null
  }
]
try with

{
  "Name": "sample string 7",
  "FamilyName": "sample string 7",
  "BirthDate": "2016-11-28",
  "Address": "sample string 7"
}

*/
