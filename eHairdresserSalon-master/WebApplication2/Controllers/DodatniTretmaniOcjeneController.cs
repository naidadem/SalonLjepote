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
    public class DodatniTretmaniOcjeneController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: DodatniTretmaniOcjene
        public ActionResult Index()
        {
            var dodatniTretmaniOcjenes = db.DodatniTretmaniOcjenes.Include(d => d.DodatniTretmani).Include(d => d.Frizeri).Include(d => d.Klijenti);
            return View(dodatniTretmaniOcjenes.ToList());
        }

        // GET: DodatniTretmaniOcjene/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodatniTretmaniOcjene dodatniTretmaniOcjene = db.DodatniTretmaniOcjenes.Find(id);
            if (dodatniTretmaniOcjene == null)
            {
                return HttpNotFound();
            }
            return View(dodatniTretmaniOcjene);
        }

        // GET: DodatniTretmaniOcjene/Create
        public ActionResult Create()
        {
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana");
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime");
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime");
            return View();
        }

        // POST: DodatniTretmaniOcjene/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TretmanOcjenaID,KlijentID,TretmanID,Ocjena,FrizerID")] DodatniTretmaniOcjene dodatniTretmaniOcjene)
        {
            if (ModelState.IsValid)
            {
                db.DodatniTretmaniOcjenes.Add(dodatniTretmaniOcjene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", dodatniTretmaniOcjene.TretmanID);
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", dodatniTretmaniOcjene.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", dodatniTretmaniOcjene.KlijentID);
            return View(dodatniTretmaniOcjene);
        }

        // GET: DodatniTretmaniOcjene/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodatniTretmaniOcjene dodatniTretmaniOcjene = db.DodatniTretmaniOcjenes.Find(id);
            if (dodatniTretmaniOcjene == null)
            {
                return HttpNotFound();
            }
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", dodatniTretmaniOcjene.TretmanID);
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", dodatniTretmaniOcjene.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", dodatniTretmaniOcjene.KlijentID);
            return View(dodatniTretmaniOcjene);
        }

        // POST: DodatniTretmaniOcjene/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TretmanOcjenaID,KlijentID,TretmanID,Ocjena,FrizerID")] DodatniTretmaniOcjene dodatniTretmaniOcjene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dodatniTretmaniOcjene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TretmanID = new SelectList(db.DodatniTretmanis, "TretmanID", "NazivTretmana", dodatniTretmaniOcjene.TretmanID);
            ViewBag.FrizerID = new SelectList(db.Frizeris, "FrizerID", "Ime", dodatniTretmaniOcjene.FrizerID);
            ViewBag.KlijentID = new SelectList(db.Klijentis, "KlijentID", "Ime", dodatniTretmaniOcjene.KlijentID);
            return View(dodatniTretmaniOcjene);
        }

        // GET: DodatniTretmaniOcjene/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DodatniTretmaniOcjene dodatniTretmaniOcjene = db.DodatniTretmaniOcjenes.Find(id);
            if (dodatniTretmaniOcjene == null)
            {
                return HttpNotFound();
            }
            return View(dodatniTretmaniOcjene);
        }

        // POST: DodatniTretmaniOcjene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DodatniTretmaniOcjene dodatniTretmaniOcjene = db.DodatniTretmaniOcjenes.Find(id);
            db.DodatniTretmaniOcjenes.Remove(dodatniTretmaniOcjene);
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
