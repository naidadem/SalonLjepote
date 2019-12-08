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
    public class FrizeriController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Frizeri
        public ActionResult Index()
        {
            var frizeris = db.Frizeris.Include(f => f.VrsteUsluga);
            return View(frizeris.ToList());
        }

        // GET: Frizeri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frizeri frizeri = db.Frizeris.Find(id);
            if (frizeri == null)
            {
                return HttpNotFound();
            }
            return View(frizeri);
        }

        // GET: Frizeri/Create
        public ActionResult Create()
        {
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv");
            return View();
        }

        // POST: Frizeri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrizerID,Ime,Prezime,KorisnickoIme,ProfilnaSlika,LozinkaSalt,LozinkaHash,SlikaThumb,Opis,VrstaUslugeID")] Frizeri frizeri)
        {
            if (ModelState.IsValid)
            {
                db.Frizeris.Add(frizeri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", frizeri.VrstaUslugeID);
            return View(frizeri);
        }

        // GET: Frizeri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frizeri frizeri = db.Frizeris.Find(id);
            if (frizeri == null)
            {
                return HttpNotFound();
            }
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", frizeri.VrstaUslugeID);
            return View(frizeri);
        }

        // POST: Frizeri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FrizerID,Ime,Prezime,KorisnickoIme,ProfilnaSlika,LozinkaSalt,LozinkaHash,SlikaThumb,Opis,VrstaUslugeID")] Frizeri frizeri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frizeri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", frizeri.VrstaUslugeID);
            return View(frizeri);
        }

        // GET: Frizeri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frizeri frizeri = db.Frizeris.Find(id);
            if (frizeri == null)
            {
                return HttpNotFound();
            }
            return View(frizeri);
        }

        // POST: Frizeri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frizeri frizeri = db.Frizeris.Find(id);
            db.Frizeris.Remove(frizeri);
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
