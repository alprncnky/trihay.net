using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_odev3.Models;
using System.IO;
using web_odev3.filters;

namespace web_odev3.Controllers
{
    public class HaberController : Controller
    {
        private acarEntities db = new acarEntities();

        // GET: Haber
        public ActionResult Index()
        {
            return View(db.Haber.ToList());
        }

        // GET: Haber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Haber.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        [AuthFilter]
        // GET: Haber/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Haber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AuthFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HaberID,haber_resmi,haber_yazisi,haber_turu,haber_baslik")] Haber haber, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                haber.haber_resmi = new byte[image1.ContentLength];
                image1.InputStream.Read(haber.haber_resmi,0,image1.ContentLength);
                db.Haber.Add(haber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(haber);
        }

        // GET: Haber/Edit/5
        [AuthFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Haber.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // POST: Haber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthFilter]
        public ActionResult Edit([Bind(Include = "HaberID,haber_resmi,haber_yazisi,haber_turu,haber_baslik")] Haber haber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(haber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(haber);
        }


        // GET: Haber/Delete/5
        [AuthFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haber haber = db.Haber.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // POST: Haber/Delete/5
        [AuthFilter]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Haber haber = db.Haber.Find(id);
            db.Haber.Remove(haber);
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
