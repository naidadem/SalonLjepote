using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TakmicenjaController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Takmicenja
        public ActionResult Index()
        {
            var takmicenjas = db.Takmicenjas.Include(t => t.Frizeri);
            return View(takmicenjas.ToList());
        }

        // GET: Takmicenja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takmicenja takmicenja = db.Takmicenjas.Find(id);
            if (takmicenja == null)
            {
                return HttpNotFound();
            }
            return View(takmicenja);
        }

        // GET: Takmicenja/Create
        public ActionResult Create()
        {
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime");
            return View();
        }

        // POST: Takmicenja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TakmicenjeID,Naziv,Datum,Mjesto,Opis,FrizerID")] Takmicenja takmicenja)
        {
            if (ModelState.IsValid)
            {
                db.Takmicenjas.Add(takmicenja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", takmicenja.FrizerID);
            return View(takmicenja);
        }

        // GET: Takmicenja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takmicenja takmicenja = db.Takmicenjas.Find(id);
            if (takmicenja == null)
            {
                return HttpNotFound();
            }
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", takmicenja.FrizerID);
            return View(takmicenja);
        }

        // POST: Takmicenja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TakmicenjeID,Naziv,Datum,Mjesto,Opis,FrizerID")] Takmicenja takmicenja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(takmicenja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", takmicenja.FrizerID);
            return View(takmicenja);
        }

        // GET: Takmicenja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Takmicenja takmicenja = db.Takmicenjas.Find(id);
            if (takmicenja == null)
            {
                return HttpNotFound();
            }
            return View(takmicenja);
        }

        // POST: Takmicenja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Takmicenja takmicenja = db.Takmicenjas.Find(id);
            db.Takmicenjas.Remove(takmicenja);
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
