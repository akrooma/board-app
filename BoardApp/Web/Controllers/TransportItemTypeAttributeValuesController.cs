using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;

namespace Web.Controllers
{
    public class TransportItemTypeAttributeValuesController : Controller
    {
        private IUOW _uow;

        public TransportItemTypeAttributeValuesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: TransportItemTypeAttributeValues
        public ActionResult Index()
        {
            var transportItemTypeAttributeValues = _uow.TransportItemTypeAttributeValues.GetAllIncluding(t => t.TransportItemTypeAttribute);

            return View(transportItemTypeAttributeValues);
        }

        // GET: TransportItemTypeAttributeValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemTypeAttributeValue transportItemTypeAttributeValue = _uow.TransportItemTypeAttributeValues.GetById(id);

            if (transportItemTypeAttributeValue == null)
            {
                return HttpNotFound();
            }

            return View(transportItemTypeAttributeValue);
        }

        // GET: TransportItemTypeAttributeValues/Create
        public ActionResult Create()
        {
            ViewBag.TransportItemTypeAttributeId = new SelectList(_uow.TransportItemTypeAttributes.All, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName");

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
                _uow.TransportItemTypeAttributeValues.Add(transportItemTypeAttributeValue);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeAttributeId = new SelectList(_uow.TransportItemTypeAttributes.All, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName", transportItemTypeAttributeValue.TransportItemTypeAttributeId);

            return View(transportItemTypeAttributeValue);
        }

        // GET: TransportItemTypeAttributeValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemTypeAttributeValue transportItemTypeAttributeValue = _uow.TransportItemTypeAttributeValues.GetById(id);

            if (transportItemTypeAttributeValue == null)
            {
                return HttpNotFound();
            }

            ViewBag.TransportItemTypeAttributeId = new SelectList(_uow.TransportItemTypeAttributes.All, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName", transportItemTypeAttributeValue.TransportItemTypeAttributeId);

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
                _uow.TransportItemTypeAttributeValues.Update(transportItemTypeAttributeValue);

                _uow.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeAttributeId = new SelectList(_uow.TransportItemTypeAttributes.All, "TransportItemTypeAttributeId", "TransportItemTypeAttributeName", transportItemTypeAttributeValue.TransportItemTypeAttributeId);

            return View(transportItemTypeAttributeValue);
        }

        // GET: TransportItemTypeAttributeValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemTypeAttributeValue transportItemTypeAttributeValue = _uow.TransportItemTypeAttributeValues.GetById(id);

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
            _uow.TransportItemTypeAttributeValues.Delete(id);
            _uow.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.TransportItemTypeAttributeValues.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
