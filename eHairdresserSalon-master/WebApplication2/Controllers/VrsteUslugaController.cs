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
    public class VrsteUslugaController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: VrsteUsluga
        public ActionResult Index()
        {
            return View(db.VrsteUslugas.ToList());
        }

        // GET: VrsteUsluga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrsteUsluga vrsteUsluga = db.VrsteUslugas.Find(id);
            if (vrsteUsluga == null)
            {
                return HttpNotFound();
            }
            return View(vrsteUsluga);
        }

        // GET: VrsteUsluga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VrsteUsluga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VrstaUslugeID,Naziv")] VrsteUsluga vrsteUsluga)
        {
            if (ModelState.IsValid)
            {
                db.VrsteUslugas.Add(vrsteUsluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrsteUsluga);
        }

        // GET: VrsteUsluga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrsteUsluga vrsteUsluga = db.VrsteUslugas.Find(id);
            if (vrsteUsluga == null)
            {
                return HttpNotFound();
            }
            return View(vrsteUsluga);
        }

        // POST: VrsteUsluga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VrstaUslugeID,Naziv")] VrsteUsluga vrsteUsluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrsteUsluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrsteUsluga);
        }

        // GET: VrsteUsluga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VrsteUsluga vrsteUsluga = db.VrsteUslugas.Find(id);
            if (vrsteUsluga == null)
            {
                return HttpNotFound();
            }
            return View(vrsteUsluga);
        }

        // POST: VrsteUsluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VrsteUsluga vrsteUsluga = db.VrsteUslugas.Find(id);
            db.VrsteUslugas.Remove(vrsteUsluga);
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
