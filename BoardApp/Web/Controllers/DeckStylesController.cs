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
    public class DeckStylesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: DeckStyles
        public ActionResult Index()
        {
            return View(db.DeckStyles.ToList());
        }

        // GET: DeckStyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeckStyle deckStyle = db.DeckStyles.Find(id);
            if (deckStyle == null)
            {
                return HttpNotFound();
            }
            return View(deckStyle);
        }

        // GET: DeckStyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeckStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeckStyleId,DeckStyleName,DeckStyleComment")] DeckStyle deckStyle)
        {
            if (ModelState.IsValid)
            {
                db.DeckStyles.Add(deckStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deckStyle);
        }

        // GET: DeckStyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeckStyle deckStyle = db.DeckStyles.Find(id);
            if (deckStyle == null)
            {
                return HttpNotFound();
            }
            return View(deckStyle);
        }

        // POST: DeckStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeckStyleId,DeckStyleName,DeckStyleComment")] DeckStyle deckStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deckStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deckStyle);
        }

        // GET: DeckStyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeckStyle deckStyle = db.DeckStyles.Find(id);
            if (deckStyle == null)
            {
                return HttpNotFound();
            }
            return View(deckStyle);
        }

        // POST: DeckStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeckStyle deckStyle = db.DeckStyles.Find(id);
            db.DeckStyles.Remove(deckStyle);
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
