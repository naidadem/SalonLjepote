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
    public class UslugeController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Usluges
        public ActionResult Index()
        {
            var usluges = db.Usluges.Include(u => u.VrsteUsluga);
            return View(usluges.ToList());
        }

        // GET: Usluges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluge usluge = db.Usluges.Find(id);
            if (usluge == null)
            {
                return HttpNotFound();
            }
            return View(usluge);
        }

        // GET: Usluges/Create
        public ActionResult Create()
        {
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv");
            return View();
        }

        // POST: Usluges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UslugaID,NazivUsluge,TrajanjeMinute,CijenaUsluge,VrstaUslugeID")] Usluge usluge)
        {
            if (ModelState.IsValid)
            {
                db.Usluges.Add(usluge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", usluge.VrstaUslugeID);
            return View(usluge);
        }

        // GET: Usluges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluge usluge = db.Usluges.Find(id);
            if (usluge == null)
            {
                return HttpNotFound();
            }
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", usluge.VrstaUslugeID);
            return View(usluge);
        }

        // POST: Usluges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UslugaID,NazivUsluge,TrajanjeMinute,CijenaUsluge,VrstaUslugeID")] Usluge usluge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", usluge.VrstaUslugeID);
            return View(usluge);
        }

        // GET: Usluges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluge usluge = db.Usluges.Find(id);
            if (usluge == null)
            {
                return HttpNotFound();
            }
            return View(usluge);
        }

        // POST: Usluges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usluge usluge = db.Usluges.Find(id);
            db.Usluges.Remove(usluge);
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
