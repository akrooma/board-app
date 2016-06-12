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
    public class TransportItemTypesController : Controller
    {
        private IUOW _uow;

        public TransportItemTypesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: TransportItemTypes
        public ActionResult Index()
        {
            return View(_uow.TransportItemTypes.All);
        }

        // GET: TransportItemTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemType transportItemType = _uow.TransportItemTypes.GetById(id);

            if (transportItemType == null)
            {
                return HttpNotFound();
            }

            return View(transportItemType);
        }

        // GET: TransportItemTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportItemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportItemTypeId,Name,Description")] TransportItemType transportItemType)
        {
            if (ModelState.IsValid)
            {
                _uow.TransportItemTypes.Add(transportItemType);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(transportItemType);
        }

        // GET: TransportItemTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemType transportItemType = _uow.TransportItemTypes.GetById(id);

            if (transportItemType == null)
            {
                return HttpNotFound();
            }

            return View(transportItemType);
        }

        // POST: TransportItemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportItemTypeId,Name,Description")] TransportItemType transportItemType)
        {
            if (ModelState.IsValid)
            {
                _uow.TransportItemTypes.Update(transportItemType);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(transportItemType);
        }

        // GET: TransportItemTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItemType transportItemType = _uow.TransportItemTypes.GetById(id);

            if (transportItemType == null)
            {
                return HttpNotFound();
            }

            return View(transportItemType);
        }

        // POST: TransportItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.TransportItemTypes.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.TransportItemTypes.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
