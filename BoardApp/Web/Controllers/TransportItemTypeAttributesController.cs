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
    public class TransportItemTypeAttributesController : Controller
    {
        private IUOW _uow;

        public TransportItemTypeAttributesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: TransportItemTypeAttributes
        public ActionResult Index()
        {
            var transportItemTypeAttributes = _uow.TransportItemTypeAttributes.GetAllIncluding(t => t.TransportItemType);

            return View(transportItemTypeAttributes.ToList());
        }

        // GET: TransportItemTypeAttributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemTypeAttribute transportItemTypeAttribute = _uow.TransportItemTypeAttributes.GetById(id);

            if (transportItemTypeAttribute == null)
            {
                return HttpNotFound();
            }

            return View(transportItemTypeAttribute);
        }

        // GET: TransportItemTypeAttributes/Create
        public ActionResult Create()
        {
            ViewBag.TransportItemTypeId = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name");

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
                _uow.TransportItemTypeAttributes.Add(transportItemTypeAttribute);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeId = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name", transportItemTypeAttribute.TransportItemTypeId);

            return View(transportItemTypeAttribute);
        }

        // GET: TransportItemTypeAttributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemTypeAttribute transportItemTypeAttribute = _uow.TransportItemTypeAttributes.GetById(id);

            if (transportItemTypeAttribute == null)
            {
                return HttpNotFound();
            }

            ViewBag.TransportItemTypeId = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name", transportItemTypeAttribute.TransportItemTypeId);

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
                _uow.TransportItemTypeAttributes.Update(transportItemTypeAttribute);

                _uow.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.TransportItemTypeId = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name", transportItemTypeAttribute.TransportItemTypeId);

            return View(transportItemTypeAttribute);
        }

        // GET: TransportItemTypeAttributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemTypeAttribute transportItemTypeAttribute = _uow.TransportItemTypeAttributes.GetById(id);

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
            _uow.TransportItemTypeAttributes.Delete(id);
            _uow.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.TransportItemTypeAttributes.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
