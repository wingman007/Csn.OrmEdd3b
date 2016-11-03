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

namespace Csn.OrmEdd3b.App.Controllers
{
    public class PersonsController : Controller
    {
        // private CsnOrmEdd3bDbContext db = new CsnOrmEdd3bDbContext();
        private EfUnitOfWork db = new EfUnitOfWork(new CsnOrmEdd3bDbContext());

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
            Person person = db.Persons.Get(id);
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
