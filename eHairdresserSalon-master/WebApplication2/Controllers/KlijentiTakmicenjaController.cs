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
    public class KlijentiTakmicenjaController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: KlijentiTakmicenja
        public ActionResult Index()
        {
            var klijentiTakmicenjas = db.KlijentiTakmicenjas.Include(k => k.Klijenti).Include(k => k.Takmicenja);
            return View(klijentiTakmicenjas.ToList());
        }

        // GET: KlijentiTakmicenja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlijentiTakmicenja klijentiTakmicenja = db.KlijentiTakmicenjas.Find(id);
            if (klijentiTakmicenja == null)
            {
                return HttpNotFound();
            }
            return View(klijentiTakmicenja);
        }

        // GET: KlijentiTakmicenja/Create
        public ActionResult Create()
        {
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime");
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenjas, "TakmicenjeID", "Naziv");
            return View();
        }

        // POST: KlijentiTakmicenja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlijentID,TakmicenjeID,DatumPrijave")] KlijentiTakmicenja klijentiTakmicenja)
        {
            if (ModelState.IsValid)
            {
                db.KlijentiTakmicenjas.Add(klijentiTakmicenja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", klijentiTakmicenja.KlijentID);
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenjas, "TakmicenjeID", "Naziv", klijentiTakmicenja.TakmicenjeID);
            return View(klijentiTakmicenja);
        }

        // GET: KlijentiTakmicenja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlijentiTakmicenja klijentiTakmicenja = db.KlijentiTakmicenjas.Find(id);
            if (klijentiTakmicenja == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", klijentiTakmicenja.KlijentID);
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenjas, "TakmicenjeID", "Naziv", klijentiTakmicenja.TakmicenjeID);
            return View(klijentiTakmicenja);
        }

        // POST: KlijentiTakmicenja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KlijentID,TakmicenjeID,DatumPrijave")] KlijentiTakmicenja klijentiTakmicenja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klijentiTakmicenja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", klijentiTakmicenja.KlijentID);
            ViewBag.TakmicenjeID = new SelectList(db.Takmicenjas, "TakmicenjeID", "Naziv", klijentiTakmicenja.TakmicenjeID);
            return View(klijentiTakmicenja);
        }

        // GET: KlijentiTakmicenja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlijentiTakmicenja klijentiTakmicenja = db.KlijentiTakmicenjas.Find(id);
            if (klijentiTakmicenja == null)
            {
                return HttpNotFound();
            }
            return View(klijentiTakmicenja);
        }

        // POST: KlijentiTakmicenja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KlijentiTakmicenja klijentiTakmicenja = db.KlijentiTakmicenjas.Find(id);
            db.KlijentiTakmicenjas.Remove(klijentiTakmicenja);
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
