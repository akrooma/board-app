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
using DAL.Repositories;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    public class MapPointsController : BaseController
    {
        private IUOW _uow;

        public MapPointsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: MapPoints
        public ActionResult Index()
        {
            return View(_uow.MapPoints.All);
        }

        // GET: MapPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MapPoint mapPoint = _uow.MapPoints.GetById(id);

            if (mapPoint == null)
            {
                return HttpNotFound();
            }

            return View(mapPoint);
        }

        // GET: MapPoints/Create
        public ActionResult Create()
        {
            var _vm = new MapPointCreateViewModel();

            _vm.RouteSelectList = new SelectList(_uow.MapPoints.All, "RouteId", "RouteName");

            return View(_vm);
        }

        // POST: MapPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MapPointCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.MapPoints.Add(vm.MapPoint);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            vm.RouteSelectList = new SelectList(_uow.MapPoints.All, "RouteId", "RouteName", vm.MapPoint.RouteId);

            return View(vm);
        }

        // GET: MapPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            var _vm = new MapPointEditViewModel();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _vm.MapPoint = _uow.MapPoints.GetById(id);

            if (_vm.MapPoint == null)
            {
                return HttpNotFound();
            }

            _vm.RouteSelectList = new SelectList(_uow.MapPoints.All, "RouteId", "RouteName", _vm.MapPoint.RouteId);

            return View(_vm);
        }

        // POST: MapPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MapPointEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.MapPoints.Update(vm.MapPoint);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            vm.RouteSelectList = new SelectList(_uow.MapPoints.All, "RouteId", "RouteName", vm.MapPoint.RouteId);

            return View(vm);
        }

        // GET: MapPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MapPoint mapPoint = _uow.MapPoints.GetById(id);

            if (mapPoint == null)
            {
                return HttpNotFound();
            }

            return View(mapPoint);
        }

        // POST: MapPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.MapPoints.Delete(id);
            _uow.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.MapPoints.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
