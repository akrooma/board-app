﻿using System;
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
    public class BoardsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Boards
        public ActionResult Index()
        {
            var boards = db.Boards.Include(b => b.DeckStyle).Include(b => b.RidingStyle);
            return View(boards.ToList());
        }

        // GET: Boards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            ViewBag.DeckStyleId = new SelectList(db.DeckStyles, "DeckStyleId", "DeckStyleName");
            ViewBag.RidingStyleId = new SelectList(db.RidingStyles, "RidingStyleId", "RidingStyleName");
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardId,BoardName,BoardDescription,OwnerId,RidingStyleId,DeckStyleId")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(board);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeckStyleId = new SelectList(db.DeckStyles, "DeckStyleId", "DeckStyleName", board.DeckStyleId);
            ViewBag.RidingStyleId = new SelectList(db.RidingStyles, "RidingStyleId", "RidingStyleName", board.RidingStyleId);
            return View(board);
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeckStyleId = new SelectList(db.DeckStyles, "DeckStyleId", "DeckStyleName", board.DeckStyleId);
            ViewBag.RidingStyleId = new SelectList(db.RidingStyles, "RidingStyleId", "RidingStyleName", board.RidingStyleId);
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardId,BoardName,BoardDescription,OwnerId,RidingStyleId,DeckStyleId")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeckStyleId = new SelectList(db.DeckStyles, "DeckStyleId", "DeckStyleName", board.DeckStyleId);
            ViewBag.RidingStyleId = new SelectList(db.RidingStyles, "RidingStyleId", "RidingStyleName", board.RidingStyleId);
            return View(board);
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Board board = db.Boards.Find(id);
            db.Boards.Remove(board);
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
