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
    public class WeapDetailsController : Controller
    {
        private WeekProj5Context db = new WeekProj5Context();

        // GET: WeapDetails
        public ActionResult Index()
        {
            var weapDetails = db.WeapDetails.Include(w => w.Category).Include(w => w.Category2);
            return View(weapDetails.ToList());
        }

        // GET: WeapDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeapDetail weapDetail = db.WeapDetails.Find(id);
            if (weapDetail == null)
            {
                return HttpNotFound();
            }
            return View(weapDetail);
        }

        // GET: WeapDetails/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "WeaponType");
            ViewBag.Category2ID = new SelectList(db.Category2, "ID", "Weapon");
            return View();
        }

        // POST: WeapDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,Category2ID,Description")] WeapDetail weapDetail)
        {
            if (ModelState.IsValid)
            {
                db.WeapDetails.Add(weapDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "WeaponType", weapDetail.CategoryID);
            ViewBag.Category2ID = new SelectList(db.Category2, "ID", "Weapon", weapDetail.Category2ID);
            return View(weapDetail);
        }

        // GET: WeapDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeapDetail weapDetail = db.WeapDetails.Find(id);
            if (weapDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "WeaponType", weapDetail.CategoryID);
            ViewBag.Category2ID = new SelectList(db.Category2, "ID", "Weapon", weapDetail.Category2ID);
            return View(weapDetail);
        }

        // POST: WeapDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,Category2ID,Description")] WeapDetail weapDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weapDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "WeaponType", weapDetail.CategoryID);
            ViewBag.Category2ID = new SelectList(db.Category2, "ID", "Weapon", weapDetail.Category2ID);
            return View(weapDetail);
        }

        // GET: WeapDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeapDetail weapDetail = db.WeapDetails.Find(id);
            if (weapDetail == null)
            {
                return HttpNotFound();
            }
            return View(weapDetail);
        }

        // POST: WeapDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeapDetail weapDetail = db.WeapDetails.Find(id);
            db.WeapDetails.Remove(weapDetail);
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
