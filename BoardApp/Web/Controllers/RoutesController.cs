using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    public class RoutesController : Controller
    {
        private IUOW _uow;

        public RoutesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Routes
        public ActionResult Index()
        {
            return View(_uow.Routes.All);
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            var _vm = new RouteDetailsViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _vm.Route = _uow.Routes.GetById(id);

            if (_vm.Route == null)
            {
                return HttpNotFound();
            }

            _vm.Comments = _uow.RouteComments.GetAllCommentsForRoute((int) id);
            _vm.Characteristics = _uow.RouteAndCharacteristics.GetCharacteristicsForRoute((int) id);

            return View(_vm);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            var _vm = new RouteCreateViewModel();
            _vm.RouteCharacteristicSelectList = new MultiSelectList(_uow.RouteCharacteristics.All, "RouteCharacteristicId", "Name");
            
            return View(_vm);
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RouteCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Routes.Add(vm.Route);

                if (vm.CharacteristicIds.Count > 0 || vm.CharacteristicIds != null)
                {
                    foreach (var routeCharacteristicId in vm.CharacteristicIds)
                    {
                        _uow.RouteAndCharacteristics.Add(
                            new RouteAndCharacteristic
                            {
                                RouteId = vm.Route.RouteId,
                                RouteCharacteristicId = routeCharacteristicId
                            }
                        );
                    }
                }

                _uow.Commit();

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Route route = _uow.Routes.GetById(id);

            if (route == null)
            {
                return HttpNotFound();
            }

            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteId,RouteName,RouteDescription,RouteRating,CreatorId")] Route route)
        {
            if (ModelState.IsValid)
            {
                _uow.Routes.Update(route);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(route);
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Route route = _uow.Routes.GetById(id);

            if (route == null)
            {
                return HttpNotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Routes.Delete(id);
            _uow.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Routes.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
