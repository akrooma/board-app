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
using Web.ViewModels;

namespace Web.Controllers
{
    public class RouteAndCharacteristicsController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
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
            var _vm = new RouteAndCharacteristicCreateViewModel();

            _vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName");
            _vm.RouteCharacteristicSelectList = new SelectList(_uow.RouteCharacteristics.All, "RouteCharacteristicId", "RouteCharacteristicName");

            return View(_vm);
        }

        // POST: RouteAndCharacteristics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RouteAndCharacteristicCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteAndCharacteristics.Add(vm.RouteAndCharacteristic);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName", vm.RouteAndCharacteristic.RouteId);
            vm.RouteCharacteristicSelectList = new SelectList(_uow.RouteCharacteristics.All, "RouteCharacteristicId", "RouteCharacteristicName", vm.RouteAndCharacteristic.RouteCharacteristicId);

            return View(vm);
        }

        // GET: RouteAndCharacteristics/Edit/5
        public ActionResult Edit(int? id)
        {
            var _vm = new RouteAndCharacteristicEditViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _vm.RouteAndCharacteristic = _uow.RouteAndCharacteristics.GetById(id);

            if (_vm.RouteAndCharacteristic == null)
            {
                return HttpNotFound();
            }

            _vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName", _vm.RouteAndCharacteristic.RouteId);
            _vm.RouteCharacteristicSelectList = new SelectList(_uow.RouteCharacteristics.All, "RouteCharacteristicId", "RouteCharacteristicName", _vm.RouteAndCharacteristic.RouteCharacteristicId);

            return View(_vm);
        }

        // POST: RouteAndCharacteristics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RouteAndCharacteristicEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteAndCharacteristics.Update(vm.RouteAndCharacteristic);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName", vm.RouteAndCharacteristic.RouteId);
            vm.RouteCharacteristicSelectList = new SelectList(_uow.RouteCharacteristics.All, "RouteCharacteristicId", "RouteCharacteristicName", vm.RouteAndCharacteristic.RouteCharacteristicId);

            return View(vm);
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
