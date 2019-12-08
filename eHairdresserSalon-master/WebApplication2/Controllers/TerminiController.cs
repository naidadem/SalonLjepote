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
    public class TerminiController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Termini
        public ActionResult Index()
        {
            var terminis = db.Terminis.Include(t => t.DodatniTretmani).Include(t => t.Frizeri).Include(t => t.Klijenti).Include(t => t.Usluge);
            return View(terminis.ToList());
        }

        // GET: Termini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Terminis.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            return View(termini);
        }

        // GET: Termini/Create
        public ActionResult Create()
        {
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana");
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime");
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime");
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge");
            return View();
        }

        // POST: Termini/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminID,Datum,Vrijeme,KlijentID,FrizerID,UslugaID,Zauzeto,TretmanID,OcijenjenaUsluga,OcijenjenTretman,prosaoTermin")] Termini termini)
        {
            if (ModelState.IsValid)
            {
                db.Terminis.Add(termini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", termini.TretmanID);
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", termini.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", termini.KlijentID);
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge", termini.UslugaID);
            return View(termini);
        }

        // GET: Termini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Terminis.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", termini.TretmanID);
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", termini.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", termini.KlijentID);
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge", termini.UslugaID);
            return View(termini);
        }

        // POST: Termini/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminID,Datum,Vrijeme,KlijentID,FrizerID,UslugaID,Zauzeto,TretmanID,OcijenjenaUsluga,OcijenjenTretman,prosaoTermin")] Termini termini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", termini.TretmanID);
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", termini.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", termini.KlijentID);
            ViewBag.UslugaID = new SelectList(db.Usluges, "UslugaID", "NazivUsluge", termini.UslugaID);
            return View(termini);
        }

        // GET: Termini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Terminis.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            return View(termini);
        }

        // POST: Termini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termini termini = db.Terminis.Find(id);
            db.Terminis.Remove(termini);
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
