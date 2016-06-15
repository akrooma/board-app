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
using DAL.Interfaces;

namespace Web.Controllers
{
    public class TransportItemAndAttributeValuesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
		private IUOW _uow;

		public TransportItemAndAttributeValuesController(IUOW uow)
		{
			_uow = uow;
		}

		// GET: TransportItemAndAttributeValues
		public ActionResult Index()
        {
            var transportItemAndAttributeValues = db.TransportItemAndAttributeValues.Include(t => t.TransportItem).Include(t => t.TransportItemTypeAttributeValue);
            return View(transportItemAndAttributeValues.ToList());
        }

        // GET: TransportItemAndAttributeValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemAndAttributeValue transportItemAndAttributeValue = db.TransportItemAndAttributeValues.Find(id);
            if (transportItemAndAttributeValue == null)
            {
                return HttpNotFound();
            }
            return View(transportItemAndAttributeValue);
        }

        // GET: TransportItemAndAttributeValues/Create
        public ActionResult Create()
        {
            ViewBag.TransportItemId = new SelectList(db.TransportItems, "TransportItemId", "Name");
            ViewBag.TransportItemTypeAttributeValueId = new SelectList(db.TransportItemTypeAttributeValues, "TransportItemTypeAttributeValueId", "Value");
            return View();
        }

        // POST: TransportItemAndAttributeValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportItemAndAttributeValueId,TransportItemId,TransportItemTypeAttributeValueId")] TransportItemAndAttributeValue transportItemAndAttributeValue)
        {
            if (ModelState.IsValid)
            {
                db.TransportItemAndAttributeValues.Add(transportItemAndAttributeValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportItemId = new SelectList(db.TransportItems, "TransportItemId", "Name", transportItemAndAttributeValue.TransportItemId);
            ViewBag.TransportItemTypeAttributeValueId = new SelectList(db.TransportItemTypeAttributeValues, "TransportItemTypeAttributeValueId", "Value", transportItemAndAttributeValue.TransportItemTypeAttributeValueId);
            return View(transportItemAndAttributeValue);
        }

        // GET: TransportItemAndAttributeValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemAndAttributeValue transportItemAndAttributeValue = db.TransportItemAndAttributeValues.Find(id);
            if (transportItemAndAttributeValue == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportItemId = new SelectList(db.TransportItems, "TransportItemId", "Name", transportItemAndAttributeValue.TransportItemId);
            ViewBag.TransportItemTypeAttributeValueId = new SelectList(db.TransportItemTypeAttributeValues, "TransportItemTypeAttributeValueId", "Value", transportItemAndAttributeValue.TransportItemTypeAttributeValueId);
            return View(transportItemAndAttributeValue);
        }

        // POST: TransportItemAndAttributeValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportItemAndAttributeValueId,TransportItemId,TransportItemTypeAttributeValueId")] TransportItemAndAttributeValue transportItemAndAttributeValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportItemAndAttributeValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportItemId = new SelectList(db.TransportItems, "TransportItemId", "Name", transportItemAndAttributeValue.TransportItemId);
            ViewBag.TransportItemTypeAttributeValueId = new SelectList(db.TransportItemTypeAttributeValues, "TransportItemTypeAttributeValueId", "Value", transportItemAndAttributeValue.TransportItemTypeAttributeValueId);
            return View(transportItemAndAttributeValue);
        }

        // GET: TransportItemAndAttributeValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportItemAndAttributeValue transportItemAndAttributeValue = db.TransportItemAndAttributeValues.Find(id);
            if (transportItemAndAttributeValue == null)
            {
                return HttpNotFound();
            }
            return View(transportItemAndAttributeValue);
        }

        // POST: TransportItemAndAttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
	        var transportItemId = _uow.TransportItemAndAttributeValues.GetById(id).TransportItemId;

	        _uow.TransportItemAndAttributeValues.Delete(id);
	        _uow.Commit();

			return RedirectToAction("Edit", "TransportItems", new { id = transportItemId });
			//return RedirectToAction("Index");
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
