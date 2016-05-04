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
    public class TransportItemTypeAttributesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: TransportItemTypeAttributes
        public ActionResult Index()
        {
            var transportItemTypeAttributes = db.TransportItemTypeAttributes.Include(t => t.TransportItemType);
            return View(transportItemTypeAttributes.ToList());
        }

        // GET: TransportItemTypeAttributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemTypeAttribute transportItemTypeAttribute = db.TransportItemTypeAttributes.Find(id);
            if (transportItemTypeAttribute == null)
            {
                return HttpNotFound();
            }
            return View(transportItemTypeAttribute);
        }

        // GET: TransportItemTypeAttributes/Create
        public ActionResult Create()
        {
            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name");
            return View();
        }

        // POST: TransportItemTypeAttributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportItemTypeAttributeId,TransportItemTypeAttributeName,TransportItemTypeAttributeDescription,TransportItemTypeId")] TransportItemTypeAttribute transportItemTypeAttribute)
        {
            if (ModelState.IsValid)
            {
                db.TransportItemTypeAttributes.Add(transportItemTypeAttribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name", transportItemTypeAttribute.TransportItemTypeId);
            return View(transportItemTypeAttribute);
        }

        // GET: TransportItemTypeAttributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemTypeAttribute transportItemTypeAttribute = db.TransportItemTypeAttributes.Find(id);
            if (transportItemTypeAttribute == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name", transportItemTypeAttribute.TransportItemTypeId);
            return View(transportItemTypeAttribute);
        }

        // POST: TransportItemTypeAttributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportItemTypeAttributeId,TransportItemTypeAttributeName,TransportItemTypeAttributeDescription,TransportItemTypeId")] TransportItemTypeAttribute transportItemTypeAttribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportItemTypeAttribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportItemTypeId = new SelectList(db.TransportItemTypes, "TransportItemTypeId", "Name", transportItemTypeAttribute.TransportItemTypeId);
            return View(transportItemTypeAttribute);
        }

        // GET: TransportItemTypeAttributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemTypeAttribute transportItemTypeAttribute = db.TransportItemTypeAttributes.Find(id);
            if (transportItemTypeAttribute == null)
            {
                return HttpNotFound();
            }
            return View(transportItemTypeAttribute);
        }

        // POST: TransportItemTypeAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportItemTypeAttribute transportItemTypeAttribute = db.TransportItemTypeAttributes.Find(id);
            db.TransportItemTypeAttributes.Remove(transportItemTypeAttribute);
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
