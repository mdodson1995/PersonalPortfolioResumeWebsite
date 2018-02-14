using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalPortfolio.Models;
using PagedList;

namespace PersonalPortfolio.Controllers
{
    public class examplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: examples
        public ViewResult Index(string sortOrder, string searchString, string filterValue, int? pageNo)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "dob" : "";
            ViewBag.NameSortParm = sortOrder == "name" ? "name" : "name";

            if (searchString != null)
                pageNo = 1;
            else
                searchString = filterValue;

            ViewBag.FilterValue = searchString;

            var people = from s in db.examples
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.name.Contains(searchString)
                                       || s.name.Contains(searchString));
            }
        
            switch (sortOrder)
            {

                case "name":
                    people = db.examples.OrderBy(s => s.name);
                    break;
                case "dob":
                    people = people.OrderBy(s => s.dob);
                    break;
                case "address":
                    people = people.OrderBy(s => s.address);
                    break;
                case "city":
                    people = people.OrderBy(s => s.city);
                    break;
                case "state":
                    people = people.OrderBy(s => s.state);
                    break;
                case "zip":
                    people = people.OrderBy(s => s.ZipCode);
                    break;

                default:
                    people = people.OrderBy(s => s.id);
                    break;
            }

            int sizeOfPage = 5;
            int numberOfPage = (pageNo ?? 1);
            return View(people.ToPagedList(numberOfPage, sizeOfPage));
        }


        // GET: examples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            example example = db.examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // GET: examples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: examples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,dob,address,city,state,ZipCode")] example example)
        {
            if (ModelState.IsValid)
            {
                db.examples.Add(example);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(example);
        }

        // GET: examples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            example example = db.examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: examples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,dob,address,city,state,ZipCode")] example example)
        {
            if (ModelState.IsValid)
            {
                db.Entry(example).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(example);
        }

        // GET: examples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            example example = db.examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: examples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            example example = db.examples.Find(id);
            db.examples.Remove(example);
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
