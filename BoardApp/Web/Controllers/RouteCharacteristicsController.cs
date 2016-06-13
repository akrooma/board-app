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
    public class RouteCharacteristicsController : Controller
    {
        private IUOW _uow;

        public RouteCharacteristicsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: RouteCharacteristics
        public ActionResult Index()
        {
            return View(_uow.RouteCharacteristics.All);
        }

        // GET: RouteCharacteristics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RouteCharacteristic routeCharacteristic = _uow.RouteCharacteristics.GetById(id);

            if (routeCharacteristic == null)
            {
                return HttpNotFound();
            }

            return View(routeCharacteristic);
        }

        // GET: RouteCharacteristics/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RouteCharacteristics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteCharacteristicId,Name,Comment")] RouteCharacteristic routeCharacteristic)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteCharacteristics.Add(routeCharacteristic);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            return View(routeCharacteristic);
        }

        // GET: RouteCharacteristics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RouteCharacteristic routeCharacteristic = _uow.RouteCharacteristics.GetById(id);

            if (routeCharacteristic == null)
            {
                return HttpNotFound();
            }

            return View(routeCharacteristic);
        }

        // POST: RouteCharacteristics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteCharacteristicId,RouteCharacteristicName,RouteCharacteristicComment")] RouteCharacteristic routeCharacteristic)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteCharacteristics.Update(routeCharacteristic);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            return View(routeCharacteristic);
        }

        // GET: RouteCharacteristics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RouteCharacteristic routeCharacteristic = _uow.RouteCharacteristics.GetById(id);

            if (routeCharacteristic == null)
            {
                return HttpNotFound();
            }

            return View(routeCharacteristic);
        }

        // POST: RouteCharacteristics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.RouteCharacteristics.Delete(id);
            _uow.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.RouteCharacteristics.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
