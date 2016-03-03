using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class RidingStylesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: RidingStyles
        public ActionResult Index()
        {
            return View(db.RidingStyles.ToList());
        }

        // GET: RidingStyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RidingStyle ridingStyle = db.RidingStyles.Find(id);
            if (ridingStyle == null)
            {
                return HttpNotFound();
            }
            return View(ridingStyle);
        }

        // GET: RidingStyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RidingStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RidingStyleId,RidingStyleName,RidingStyleComment")] RidingStyle ridingStyle)
        {
            if (ModelState.IsValid)
            {
                db.RidingStyles.Add(ridingStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ridingStyle);
        }

        // GET: RidingStyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RidingStyle ridingStyle = db.RidingStyles.Find(id);
            if (ridingStyle == null)
            {
                return HttpNotFound();
            }
            return View(ridingStyle);
        }

        // POST: RidingStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RidingStyleId,RidingStyleName,RidingStyleComment")] RidingStyle ridingStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ridingStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ridingStyle);
        }

        // GET: RidingStyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RidingStyle ridingStyle = db.RidingStyles.Find(id);
            if (ridingStyle == null)
            {
                return HttpNotFound();
            }
            return View(ridingStyle);
        }

        // POST: RidingStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RidingStyle ridingStyle = db.RidingStyles.Find(id);
            db.RidingStyles.Remove(ridingStyle);
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
