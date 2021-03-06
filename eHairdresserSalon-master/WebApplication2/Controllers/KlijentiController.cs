﻿using System;
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
    public class KlijentiController : Controller
    {
        private FrizerskiSalonEntities db = new FrizerskiSalonEntities();

        // GET: Klijenti
        public ActionResult Index()
        {
            return View(db.Klijentis.ToList());
        }

        // GET: Klijenti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijenti klijenti = db.Klijentis.Find(id);
            if (klijenti == null)
            {
                return HttpNotFound();
            }
            return View(klijenti);
        }

        // GET: Klijenti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klijenti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlijentID,Ime,Prezime,DatumRodjenja,Adresa,Email,BrojTelefona,Napomena,LozinkaSalt,LozinkaHash,KorisnickoIme,TerminiCount,Aktivan")] Klijenti klijenti)
        {
            if (ModelState.IsValid)
            {
                db.Klijentis.Add(klijenti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klijenti);
        }

        // GET: Klijenti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijenti klijenti = db.Klijentis.Find(id);
            if (klijenti == null)
            {
                return HttpNotFound();
            }
            return View(klijenti);
        }

        // POST: Klijenti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KlijentID,Ime,Prezime,DatumRodjenja,Adresa,Email,BrojTelefona,Napomena,LozinkaSalt,LozinkaHash,KorisnickoIme,TerminiCount,Aktivan")] Klijenti klijenti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klijenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klijenti);
        }

        // GET: Klijenti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijenti klijenti = db.Klijentis.Find(id);
            if (klijenti == null)
            {
                return HttpNotFound();
            }
            return View(klijenti);
        }

        // POST: Klijenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klijenti klijenti = db.Klijentis.Find(id);
            db.Klijentis.Remove(klijenti);
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
