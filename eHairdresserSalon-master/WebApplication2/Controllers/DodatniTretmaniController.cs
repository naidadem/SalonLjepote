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
    public class DodatniTretmaniController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: DodatniTretmani
        public ActionResult Index()
        {
            var dodatniTretmanis = db.DodatniTretmanis.Include(d => d.VrsteUsluga);
            return View(dodatniTretmanis.ToList());
        }

        // GET: DodatniTretmani/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodatniTretmani dodatniTretmani = db.DodatniTretmanis.Find(id);
            if (dodatniTretmani == null)
            {
                return HttpNotFound();
            }
            return View(dodatniTretmani);
        }

        // GET: DodatniTretmani/Create
        public ActionResult Create()
        {
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv");
            return View();
        }

        // POST: DodatniTretmani/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TretmanID,NazivTretmana,Cijena,Opis,VrstaUslugeID")] DodatniTretmani dodatniTretmani)
        {
            if (ModelState.IsValid)
            {
                db.DodatniTretmanis.Add(dodatniTretmani);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", dodatniTretmani.VrstaUslugeID);
            return View(dodatniTretmani);
        }

        // GET: DodatniTretmani/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodatniTretmani dodatniTretmani = db.DodatniTretmanis.Find(id);
            if (dodatniTretmani == null)
            {
                return HttpNotFound();
            }
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", dodatniTretmani.VrstaUslugeID);
            return View(dodatniTretmani);
        }

        // POST: DodatniTretmani/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TretmanID,NazivTretmana,Cijena,Opis,VrstaUslugeID")] DodatniTretmani dodatniTretmani)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dodatniTretmani).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VrstaUslugeID = new SelectList(db.VrsteUslugas, "VrstaUslugeID", "Naziv", dodatniTretmani.VrstaUslugeID);
            return View(dodatniTretmani);
        }

        // GET: DodatniTretmani/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodatniTretmani dodatniTretmani = db.DodatniTretmanis.Find(id);
            if (dodatniTretmani == null)
            {
                return HttpNotFound();
            }
            return View(dodatniTretmani);
        }

        // POST: DodatniTretmani/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DodatniTretmani dodatniTretmani = db.DodatniTretmanis.Find(id);
            db.DodatniTretmanis.Remove(dodatniTretmani);
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
