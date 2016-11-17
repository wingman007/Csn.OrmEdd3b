using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Csn.OrmEdd3b.Models;
using Csn.OrmEdd3b.Dal;
using Csn.OrmEdd3b.Dal.UnitOfWork;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Csn.OrmEdd3b.App.Controllers
{
    public class PersonsController : Controller
    {
        // 1. working directly with Ef. Code generator.
        // private CsnOrmEdd3bDbContext db = new CsnOrmEdd3bDbContext();

        // 2. Working with our adapter between Ef and the App
        private EfUnitOfWork db = new EfUnitOfWork(new CsnOrmEdd3bDbContext());

        // 3. Working with ADO
        // Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Stoyan\Source\Repos\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb
        //      <connectionStrings>
        //          <add name = "ConnectionString" connectionString="data source=.;Initial Catalog=MyDatabase;Integrated Security=SSPI" providerName="System.Data.SqlClient" />
        //      </connectionStrings>
        // System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString
//-        private AdoUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Stoyan\Source\Repos\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb"));
//-        private AdoUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fmi\Source\Repos\Csn.OrmEdd3b\Csn.OrmEdd.Console\App_Data\CsnOrmEdd3b.mdb;Persist Security Info=True"));

        // private AdoUnitOfWork db = new AdoUnitOfWork(new OdbcConnection());
        // ERROR [IM002] [Microsoft][ODBC Driver Manager] Data source name not found and no default driver specified
//-        private AdoUnitOfWork db = new AdoUnitOfWork(new OdbcConnection(@"DRIVER={MySQL ODBC 5.3 Driver};SERVER=localhost;DATABASE=ormedd;USER=ormedd;PASSWORD=ormedd;OPTION=3;"));

//-        private AdoUnitOfWork db = new AdoUnitOfWork(new OdbcConnection(@"DSN=OrmEdd;uid=ormedd;pwd=ormedd;DATABASE=ormedd"));


        // 4. Work with Files
        // Only the unit of work will be different
        // Access to the path 'C:\Program Files (x86)\IIS Express\Person.csv' is denied.
        // private FileUnitOfWork db = new FileUnitOfWork(); // "C:\Users\Stoyan"

//-        private FileUnitOfWork db = new FileUnitOfWork(@"C:\Users\Stoyan");
//-        private FileUnitOfWork db = new FileUnitOfWork(@"C:\Users\fmi");

        // GET: /Persons/
        public ActionResult Index()
        {
            // return View(db.Persons.ToList());
            return View(db.Persons.GetAll());
        }

        // GET: /Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Person person = db.Persons.Find(id);
            Person person = db.Persons.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: /Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,FamilyName,BirthDate,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: /Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Person person = db.Persons.Find(id);
            Person person = db.Persons.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,FamilyName,BirthDate,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                // boiler plating - the correct way
                //Person personFromEf = db.Persons.Get(person.Id);
                //personFromEf.Id = person.Id;

               // for conveninace
                db.Persons.Update(person);

                // db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: /Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Person person = db.Persons.Find(id);
            Person person = db.Persons.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Person person = db.Persons.Find(id);
            Person person = db.Persons.Get(id); // I bed the connection gets removed
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
