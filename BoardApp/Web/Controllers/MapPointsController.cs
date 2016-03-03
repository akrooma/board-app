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

namespace Web.Controllers
{
    public class MapPointsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: MapPoints
        public ActionResult Index()
        {
            var mapPoints = db.MapPoints.Include(m => m.Route);
            return View(mapPoints.ToList());
        }

        // GET: MapPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPoint mapPoint = db.MapPoints.Find(id);
            if (mapPoint == null)
            {
                return HttpNotFound();
            }
            return View(mapPoint);
        }

        // GET: MapPoints/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName");
            return View();
        }

        // POST: MapPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapPointId,Latitude,Longitude,RouteId,CreatorId")] MapPoint mapPoint)
        {
            if (ModelState.IsValid)
            {
                db.MapPoints.Add(mapPoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", mapPoint.RouteId);
            return View(mapPoint);
        }

        // GET: MapPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPoint mapPoint = db.MapPoints.Find(id);
            if (mapPoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", mapPoint.RouteId);
            return View(mapPoint);
        }

        // POST: MapPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapPointId,Latitude,Longitude,RouteId,CreatorId")] MapPoint mapPoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapPoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", mapPoint.RouteId);
            return View(mapPoint);
        }

        // GET: MapPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPoint mapPoint = db.MapPoints.Find(id);
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
            MapPoint mapPoint = db.MapPoints.Find(id);
            db.MapPoints.Remove(mapPoint);
            db.SaveChanges();
            return RedirectToAction("Index");
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
