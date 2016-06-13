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
    public class RouteCommentsController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();
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
            var _vm = new RouteCommentCreateViewModel();
            _vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName");

            return View(_vm);
        }

        // POST: RouteComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RouteCommentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteComments.Add(vm.RouteComment);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName", vm.RouteComment.RouteId);

            return View(vm);
        }

        // GET: RouteComments/Edit/5
        public ActionResult Edit(int? id)
        {
            var _vm = new RouteCommentEditViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _vm.RouteComment = _uow.RouteComments.GetById(id);

            if (_vm.RouteComment == null)
            {
                return HttpNotFound();
            }

            _vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName", _vm.RouteComment.RouteId);

            return View(_vm);
        }

        // POST: RouteComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RouteCommentEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.RouteComments.Update(vm.RouteComment);
                _uow.Commit();

                return RedirectToAction("Index");
            }

            vm.RouteSelectList = new SelectList(_uow.Routes.All, "RouteId", "RouteName", vm.RouteComment.RouteId);

            return View(vm);
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
