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
    public class TransportItemsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: TransportItems
        public ActionResult Index()
        {
            var transportItems = db.TransportItems.Include(t => t.TransportItemType);
            return View(transportItems.ToList());
        }

        // GET: TransportItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItem transportItem = db.TransportItems.Find(id);
            if (transportItem == null)
            {
                return HttpNotFound();
            }
            return View(transportItem);
        }

        // GET: TransportItems/Create
        public ActionResult Create()
        {
            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name");
            return View();
        }

        // POST: TransportItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportItemId,Name,Description,TransportItemTypeId")] TransportItem transportItem)
        {
            if (ModelState.IsValid)
            {
                db.TransportItems.Add(transportItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name", transportItem.TransportItemTypeId);
            return View(transportItem);
        }

        // GET: TransportItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItem transportItem = db.TransportItems.Find(id);
            if (transportItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name", transportItem.TransportItemTypeId);
            return View(transportItem);
        }

        // POST: TransportItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportItemId,Name,Description,TransportItemTypeId")] TransportItem transportItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name", transportItem.TransportItemTypeId);
            return View(transportItem);
        }

        // GET: TransportItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItem transportItem = db.TransportItems.Find(id);
            if (transportItem == null)
            {
                return HttpNotFound();
            }
            return View(transportItem);
        }

        // POST: TransportItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportItem transportItem = db.TransportItems.Find(id);
            db.TransportItems.Remove(transportItem);
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
