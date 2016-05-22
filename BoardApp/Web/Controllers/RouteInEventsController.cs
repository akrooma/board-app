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
    public class RouteInEventsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        private IUOW _uow;

        public RouteInEventsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: RouteInEvents
        public ActionResult Index()
        {
            var routeInEvents = _uow.RouteInEvents.GetAllIncluding(r => r.Event, rr => rr.Route);
            return View(routeInEvents.ToList());
        }

        // GET: RouteInEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInEvent routeInEvent = _uow.RouteInEvents.GetById(id);
            if (routeInEvent == null)
            {
                return HttpNotFound();
            }
            return View(routeInEvent);
        }

        // GET: RouteInEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName");
            return View();
        }

        // POST: RouteInEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteInEventId,RouteInEventComment,RouteId,EventId")] RouteInEvent routeInEvent)
        {
            if (ModelState.IsValid)
            {
                db.RouteInEvents.Add(routeInEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", routeInEvent.EventId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeInEvent.RouteId);
            return View(routeInEvent);
        }

        // GET: RouteInEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInEvent routeInEvent = db.RouteInEvents.Find(id);
            if (routeInEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", routeInEvent.EventId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeInEvent.RouteId);
            return View(routeInEvent);
        }

        // POST: RouteInEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteInEventId,RouteInEventComment,RouteId,EventId")] RouteInEvent routeInEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeInEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", routeInEvent.EventId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeInEvent.RouteId);
            return View(routeInEvent);
        }

        // GET: RouteInEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInEvent routeInEvent = db.RouteInEvents.Find(id);
            if (routeInEvent == null)
            {
                return HttpNotFound();
            }
            return View(routeInEvent);
        }

        // POST: RouteInEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteInEvent routeInEvent = db.RouteInEvents.Find(id);
            db.RouteInEvents.Remove(routeInEvent);
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
