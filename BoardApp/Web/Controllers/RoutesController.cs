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

namespace Web.Controllers
{
    public class RoutesController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();

        //private readonly IRouteRepository _routeRepository = new RouteRepository(new DataBaseContext());
        private readonly IRouteRepository _routeRepository;

        public RoutesController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        // GET: Routes
        public ActionResult Index()
        {
            return View(_routeRepository.All);
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = _routeRepository.GetById(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteId,RouteName,RouteDescription,RouteRating,CreatorId")] Route route)
        {
            if (ModelState.IsValid)
            {
                _routeRepository.Add(route);
                _routeRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(route);
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = _routeRepository.GetById(id);
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
                _routeRepository.Update(route);
                _routeRepository.SaveChanges();
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
            Route route = _routeRepository.GetById(id);
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
            _routeRepository.Delete(id);
            _routeRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _routeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
