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
    public class RouteAndCharacteristicsController : Controller
    {
        private IUOW _uow;

        public RouteAndCharacteristicsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: RouteAndCharacteristics
        public ActionResult Index()
        {
            var routeAndCharacteristics = _uow.RouteAndCharacteristics.GetAllIncluding(a => a.RouteCharacteristic, p => p.Route);
            //var routeAndCharacteristics = db.RouteAndCharacteristics.Include(r => r.Route).Include(r => r.RouteCharacteristic);
            return View(routeAndCharacteristics.ToList());
        }

        // GET: RouteAndCharacteristics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteAndCharacteristic routeAndCharacteristic = _uow.RouteAndCharacteristics.GetById(id);
            if (routeAndCharacteristic == null)
            {
                return HttpNotFound();
            }
            return View(routeAndCharacteristic);
        }

        // GET: RouteAndCharacteristics/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName");
            ViewBag.RouteCharacteristicId = new SelectList(db.RouteCharacteristics, "RouteCharacteristicId", "RouteCharacteristicName");
            return View();
        }

        // POST: RouteAndCharacteristics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteAndCharacteristicId,RouteId,RouteCharacteristicId")] RouteAndCharacteristic routeAndCharacteristic)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteAndCharacteristics.Add(routeAndCharacteristic);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeAndCharacteristic.RouteId);
            ViewBag.RouteCharacteristicId = new SelectList(db.RouteCharacteristics, "RouteCharacteristicId", "RouteCharacteristicName", routeAndCharacteristic.RouteCharacteristicId);
            return View(routeAndCharacteristic);
        }

        // GET: RouteAndCharacteristics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteAndCharacteristic routeAndCharacteristic = _uow.RouteAndCharacteristics.GetById(id);
            if (routeAndCharacteristic == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeAndCharacteristic.RouteId);
            ViewBag.RouteCharacteristicId = new SelectList(db.RouteCharacteristics, "RouteCharacteristicId", "RouteCharacteristicName", routeAndCharacteristic.RouteCharacteristicId);
            return View(routeAndCharacteristic);
        }

        // POST: RouteAndCharacteristics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteAndCharacteristicId,RouteId,RouteCharacteristicId")] RouteAndCharacteristic routeAndCharacteristic)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteAndCharacteristics.Update(routeAndCharacteristic);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeAndCharacteristic.RouteId);
            ViewBag.RouteCharacteristicId = new SelectList(db.RouteCharacteristics, "RouteCharacteristicId", "RouteCharacteristicName", routeAndCharacteristic.RouteCharacteristicId);
            return View(routeAndCharacteristic);
        }

        // GET: RouteAndCharacteristics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteAndCharacteristic routeAndCharacteristic = _uow.RouteAndCharacteristics.GetById(id);
            if (routeAndCharacteristic == null)
            {
                return HttpNotFound();
            }
            return View(routeAndCharacteristic);
        }

        // POST: RouteAndCharacteristics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.RouteAndCharacteristics.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.RouteAndCharacteristics.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
