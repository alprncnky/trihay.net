using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_odev3.filters;
using web_odev3.Models;

namespace web_odev3.Controllers
{
    public class Users1Controller : Controller
    {
        private acarEntities db = new acarEntities();

        // GET: Users1
        [AuthFilter]
        public ActionResult Index()
        {
            return View(db.Users1.ToList());
        }

        // GET: Users1/Details/5
        [AuthFilter]
        public ActionResult Details(string idd)
        {
            if (idd == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users1 users1 = db.Users1.Find(idd);
            if (users1 == null)
            {
                return HttpNotFound();
            }
            return View(users1);
        }

        // GET: Users1/Create
        public ActionResult Login()
        {
            if (Session["adm"] != null)
                ViewBag.ekran = "inline-block";
            else
                ViewBag.ekran = "none";
            return View();
        }

        // POST: Users1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "userEmail,userPassword")] Users1 baska)
        {
            if (ModelState.IsValid)
            {
                int girisyap = db.Users1.Where(x => x.userEmail == baska.userEmail && x.userPassword==baska.userPassword).Count();
                if(girisyap>0)
                {
                    if(baska.userEmail== "admin@gmail.com" && baska.userPassword== "admin")
                    {
                        Session["adm"] = baska;
                        //return RedirectToAction("AdminPage", "Home");
                    }
                    //giris yap
                    Session["usr"] = baska;
                    return RedirectToAction("Index", "Home");
                }

                int hatali = db.Users1.Where(x => x.userEmail == baska.userEmail).Count();
                if(hatali>0)
                {
                    return RedirectToAction("Login", "Users1");
                }

                db.Users1.Add(baska);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Login", "Users1");
        }

        // GET: Users1/Edit/5
        [AuthFilter]
        public ActionResult Edit(string idd)
        {
            if (idd == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users1 users1 = db.Users1.Find(idd);
            if (users1 == null)
            {
                return HttpNotFound();
            }
            return View(users1);
        }

        // POST: Users1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthFilter]
        public ActionResult Edit([Bind(Include = "userEmail,userPassword")] Users1 users1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users1);
        }

        // GET: Users1/Delete/5
        [AuthFilter]
        public ActionResult Delete(string idd)
        {
            if (idd == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users1 users1 = db.Users1.Find(idd);
            if (users1 == null)
            {
                return HttpNotFound();
            }
            return View(users1);
        }

        // POST: Users1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthFilter]
        public ActionResult DeleteConfirmed(string idd)
        {
            Users1 users1 = db.Users1.Find(idd);
            db.Users1.Remove(users1);
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
