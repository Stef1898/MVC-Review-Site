using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeekProj5.Models;

namespace WeekProj5.Controllers
{
    public class Category2Controller : Controller
    {
        private WeekProj5Context db = new WeekProj5Context();

        // GET: Category2
        public ActionResult Index()
        {
            return View(db.Category2.ToList());
        }

        // GET: Category2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category2 category2 = db.Category2.Find(id);
            if (category2 == null)
            {
                return HttpNotFound();
            }
            return View(category2);
        }

        // GET: Category2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Weapon")] Category2 category2)
        {
            if (ModelState.IsValid)
            {
                db.Category2.Add(category2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category2);
        }

        // GET: Category2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category2 category2 = db.Category2.Find(id);
            if (category2 == null)
            {
                return HttpNotFound();
            }
            return View(category2);
        }

        // POST: Category2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Weapon")] Category2 category2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category2);
        }

        // GET: Category2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category2 category2 = db.Category2.Find(id);
            if (category2 == null)
            {
                return HttpNotFound();
            }
            return View(category2);
        }

        // POST: Category2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category2 category2 = db.Category2.Find(id);
            db.Category2.Remove(category2);
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
