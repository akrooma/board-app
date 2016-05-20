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
    public class RouteCommentsController : Controller
    {
        private IUOW _uow;

        public RouteCommentsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: RouteComments
        public ActionResult Index()
        {
            var routeComments = _uow.RouteComments.GetAllIncluding(r => r.Route);
            //var routeComments = db.RouteComments.Include(r => r.Route);
            return View(routeComments.ToList());
        }

        // GET: RouteComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteComment routeComment = _uow.RouteComments.GetById(id);
            if (routeComment == null)
            {
                return HttpNotFound();
            }
            return View(routeComment);
        }

        // GET: RouteComments/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName");
            return View();
        }

        // POST: RouteComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteCommentId,RouteCommentContent,PostDate,UpdateDate,OwnerId,RouteId")] RouteComment routeComment)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteComments.Add(routeComment);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeComment.RouteId);
            return View(routeComment);
        }

        // GET: RouteComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteComment routeComment = _uow.RouteComments.GetById(id);
            if (routeComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeComment.RouteId);
            return View(routeComment);
        }

        // POST: RouteComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteCommentId,RouteCommentContent,PostDate,UpdateDate,OwnerId,RouteId")] RouteComment routeComment)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteComments.Update(routeComment);
                _uow.Commit();
                //db.Entry(routeComment).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteName", routeComment.RouteId);
            return View(routeComment);
        }

        // GET: RouteComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteComment routeComment = _uow.RouteComments.GetById(id);
            if (routeComment == null)
            {
                return HttpNotFound();
            }
            return View(routeComment);
        }

        // POST: RouteComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.RouteComments.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.RouteComments.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
