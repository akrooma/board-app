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
    public class TransportItemTypeAttributeValuesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: TransportItemTypeAttributeValues
        public ActionResult Index()
        {
            var transportItemTypeAttributeValues = db.TransportItemTypeAttributeValues.Include(t => t.TransportItemTypeAttribute);
            return View(transportItemTypeAttributeValues.ToList());
        }

        // GET: TransportItemTypeAttributeValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemTypeAttributeValue transportItemTypeAttributeValue = db.TransportItemTypeAttributeValues.Find(id);
            if (transportItemTypeAttributeValue == null)
            {
                return HttpNotFound();
            }
            return View(transportItemTypeAttributeValue);
        }

        // GET: TransportItemTypeAttributeValues/Create
        public ActionResult Create()
        {
            ViewBag.TransportItemTypeAttributeId = new SelectList(db.TransportItemTypeAttributes, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName");
            return View();
        }

        // POST: TransportItemTypeAttributeValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportItemTypeAttributeValueId,Name,Description,TransportItemTypeAttributeId")] TransportItemTypeAttributeValue transportItemTypeAttributeValue)
        {
            if (ModelState.IsValid)
            {
                db.TransportItemTypeAttributeValues.Add(transportItemTypeAttributeValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeAttributeId = new SelectList(db.TransportItemTypeAttributes, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName", transportItemTypeAttributeValue.TransportItemTypeAttributeId);
            return View(transportItemTypeAttributeValue);
        }

        // GET: TransportItemTypeAttributeValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemTypeAttributeValue transportItemTypeAttributeValue = db.TransportItemTypeAttributeValues.Find(id);
            if (transportItemTypeAttributeValue == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportItemTypeAttributeId = new SelectList(db.TransportItemTypeAttributes, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName", transportItemTypeAttributeValue.TransportItemTypeAttributeId);
            return View(transportItemTypeAttributeValue);
        }

        // POST: TransportItemTypeAttributeValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportItemTypeAttributeValueId,Name,Description,TransportItemTypeAttributeId")] TransportItemTypeAttributeValue transportItemTypeAttributeValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportItemTypeAttributeValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportItemTypeAttributeId = new SelectList(db.TransportItemTypeAttributes, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName", transportItemTypeAttributeValue.TransportItemTypeAttributeId);
            return View(transportItemTypeAttributeValue);
        }

        // GET: TransportItemTypeAttributeValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemTypeAttributeValue transportItemTypeAttributeValue = db.TransportItemTypeAttributeValues.Find(id);
            if (transportItemTypeAttributeValue == null)
            {
                return HttpNotFound();
            }
            return View(transportItemTypeAttributeValue);
        }

        // POST: TransportItemTypeAttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportItemTypeAttributeValue transportItemTypeAttributeValue = db.TransportItemTypeAttributeValues.Find(id);
            db.TransportItemTypeAttributeValues.Remove(transportItemTypeAttributeValue);
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
