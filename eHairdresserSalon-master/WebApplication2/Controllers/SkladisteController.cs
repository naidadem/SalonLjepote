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
    public class SkladisteController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Skladiste
        public ActionResult Index()
        {
            var skladistes = db.Skladistes.Include(s => s.DodatniTretmani);
            return View(skladistes.ToList());
        }

        // GET: Skladiste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skladiste skladiste = db.Skladistes.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // GET: Skladiste/Create
        public ActionResult Create()
        {
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana");
            return View();
        }

        // POST: Skladiste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkladisteID,TretmanID,Kolicina")] Skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                db.Skladistes.Add(skladiste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", skladiste.TretmanID);
            return View(skladiste);
        }

        // GET: Skladiste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skladiste skladiste = db.Skladistes.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", skladiste.TretmanID);
            return View(skladiste);
        }

        // POST: Skladiste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkladisteID,TretmanID,Kolicina")] Skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skladiste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", skladiste.TretmanID);
            return View(skladiste);
        }

        // GET: Skladiste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skladiste skladiste = db.Skladistes.Find(id);
            if (skladiste == null)
            {
                return HttpNotFound();
            }
            return View(skladiste);
        }

        // POST: Skladiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skladiste skladiste = db.Skladistes.Find(id);
            db.Skladistes.Remove(skladiste);
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
