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
    public class NagradeController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Nagrade
        public ActionResult Index()
        {
            return View(db.Nagrades.ToList());
        }

        // GET: Nagrade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagrade nagrade = db.Nagrades.Find(id);
            if (nagrade == null)
            {
                return HttpNotFound();
            }
            return View(nagrade);
        }

        // GET: Nagrade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nagrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NagradaID,Naziv,Od,Do")] Nagrade nagrade)
        {
            if (ModelState.IsValid)
            {
                db.Nagrades.Add(nagrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nagrade);
        }

        // GET: Nagrade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagrade nagrade = db.Nagrades.Find(id);
            if (nagrade == null)
            {
                return HttpNotFound();
            }
            return View(nagrade);
        }

        // POST: Nagrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NagradaID,Naziv,Od,Do")] Nagrade nagrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nagrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nagrade);
        }

        // GET: Nagrade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagrade nagrade = db.Nagrades.Find(id);
            if (nagrade == null)
            {
                return HttpNotFound();
            }
            return View(nagrade);
        }

        // POST: Nagrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nagrade nagrade = db.Nagrades.Find(id);
            db.Nagrades.Remove(nagrade);
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
