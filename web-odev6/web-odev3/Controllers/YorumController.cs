using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_odev3.Models;

namespace web_odev3.Controllers
{
    public class YorumController : Controller
    {
        private acarEntities db = new acarEntities();

        // GET: Yorum
        public ActionResult Index()
        {
            var yorum1 = db.Yorum1.Include(y => y.Haber);
            return View(yorum1.ToList());
        }

        // GET: Yorum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum1 yorum1 = db.Yorum1.Find(id);
            if (yorum1 == null)
            {
                return HttpNotFound();
            }
            return View(yorum1);
        }

        // GET: Yorum/Create
        public ActionResult Create()
        {
            ViewBag.HaberID = new SelectList(db.Haber, "HaberID", "haber_yazisi");
            return View();
        }

        // POST: Yorum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int input,[Bind(Include = "YorumID,Yorum_satiri,HaberID")] Yorum1 yorum1)
        {
            if(Session["usr"]==null) return RedirectToAction("Login", "Users1");
            if (ModelState.IsValid)
            {
                yorum1.HaberID = input;
                db.Yorum1.Add(yorum1);
                db.SaveChanges();
                return RedirectToAction("haber","Home", new { id = yorum1.HaberID });
            }

            ViewBag.HaberID = new SelectList(db.Haber, "HaberID", "haber_yazisi", yorum1.HaberID);
            return RedirectToAction("Index", "Home", new { id = yorum1.HaberID });
        }

        // GET: Yorum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum1 yorum1 = db.Yorum1.Find(id);
            if (yorum1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.HaberID = new SelectList(db.Haber, "HaberID", "haber_yazisi", yorum1.HaberID);
            return View(yorum1);
        }

        // POST: Yorum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumID,Yorum_satiri,HaberID")] Yorum1 yorum1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminPage", "Home");
            }
            ViewBag.HaberID = new SelectList(db.Haber, "HaberID", "haber_yazisi", yorum1.HaberID);
            return View(yorum1);
        }

        // GET: Yorum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum1 yorum1 = db.Yorum1.Find(id);
            if (yorum1 == null)
            {
                return HttpNotFound();
            }
            return View(yorum1);
        }

        // POST: Yorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum1 yorum1 = db.Yorum1.Find(id);
            db.Yorum1.Remove(yorum1);
            db.SaveChanges();
            return RedirectToAction("AdminPage", "Home");
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
