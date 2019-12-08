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
    public class UslugeOcjeneController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: UslugeOcjene
        public ActionResult Index()
        {
            var uslugeOcjenes = db.UslugeOcjenes.Include(u => u.Frizeri).Include(u => u.Klijenti).Include(u => u.Termini).Include(u => u.Usluge);
            return View(uslugeOcjenes.ToList());
        }

        // GET: UslugeOcjene/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UslugeOcjene uslugeOcjene = db.UslugeOcjenes.Find(id);
            if (uslugeOcjene == null)
            {
                return HttpNotFound();
            }
            return View(uslugeOcjene);
        }

        // GET: UslugeOcjene/Create
        public ActionResult Create()
        {
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime");
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime");
            ViewBag.TerminID = new SelectList(db.Terminis, "TerminID", "TerminID");
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge");
            return View();
        }

        // POST: UslugeOcjene/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UslugaOcjenaID,KlijentID,UslugaID,FrizerID,Ocjena,TerminID")] UslugeOcjene uslugeOcjene)
        {
            if (ModelState.IsValid)
            {
                db.UslugeOcjenes.Add(uslugeOcjene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", uslugeOcjene.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", uslugeOcjene.KlijentID);
            ViewBag.TerminID = new SelectList(db.Terminis, "TerminID", "TerminID", uslugeOcjene.TerminID);
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge", uslugeOcjene.UslugaID);
            return View(uslugeOcjene);
        }

        // GET: UslugeOcjene/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UslugeOcjene uslugeOcjene = db.UslugeOcjenes.Find(id);
            if (uslugeOcjene == null)
            {
                return HttpNotFound();
            }
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", uslugeOcjene.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", uslugeOcjene.KlijentID);
            ViewBag.TerminID = new SelectList(db.Terminis, "TerminID", "TerminID", uslugeOcjene.TerminID);
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge", uslugeOcjene.UslugaID);
            return View(uslugeOcjene);
        }

        // POST: UslugeOcjene/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UslugaOcjenaID,KlijentID,UslugaID,FrizerID,Ocjena,TerminID")] UslugeOcjene uslugeOcjene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uslugeOcjene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", uslugeOcjene.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", uslugeOcjene.KlijentID);
            ViewBag.TerminID = new SelectList(db.Terminis, "TerminID", "TerminID", uslugeOcjene.TerminID);
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge", uslugeOcjene.UslugaID);
            return View(uslugeOcjene);
        }

        // GET: UslugeOcjene/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UslugeOcjene uslugeOcjene = db.UslugeOcjenes.Find(id);
            if (uslugeOcjene == null)
            {
                return HttpNotFound();
            }
            return View(uslugeOcjene);
        }

        // POST: UslugeOcjene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UslugeOcjene uslugeOcjene = db.UslugeOcjenes.Find(id);
            db.UslugeOcjenes.Remove(uslugeOcjene);
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
