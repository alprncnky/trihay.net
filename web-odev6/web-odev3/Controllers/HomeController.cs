using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_odev3.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using web_odev3.filters;

namespace web_odev3.Controllers
{
    public class HomeController : Controller
    {
        private acarEntities db = new acarEntities();

        public void buton()
        {
            if (Session["adm"] != null)
                ViewBag.ekran = "inline-block";
            else
                ViewBag.ekran = "none";
        }
        // GET: Home
        public ActionResult Index()
        {
            buton();
            return View(db.Haber);
        }

        public ActionResult iletisim()
        {
            buton();
            return View();
        }

        //public ActionResult Login()
        //{
        //    var viewmodel = new ViewModel();
        //    viewmodel.user1 = new Users1();
        //    return View(viewmodel);
        //}

        public ActionResult Sondakika()
        {
            buton();
            var viewmodel = new ViewModel();
            viewmodel.haber = new Haber();
            viewmodel.ListH = db.Haber.ToList();
            return View(viewmodel);
        }

        public ActionResult gundem()
        {
            buton();
            return View(db.Haber);
        }

        public ActionResult Spor()
        {
            buton();
            return View(db.Haber);
        }

        public ActionResult Dunya()
        {
            buton();
            return View(db.Haber);
        }

        [AuthFilter]
        public ActionResult AdminPage()
        {
            buton();
            var viewmodel = new ViewModel();
            viewmodel.user1 = new Users1();
            viewmodel.yorum1 = new Yorum1();
            viewmodel.haber = new Haber();
            viewmodel.ListH = db.Haber.ToList();
            viewmodel.ListY = db.Yorum1.ToList();
            viewmodel.ListU = db.Users1.ToList();
            return View(viewmodel);
        }

        public ActionResult haber(int? id)
        {
            buton();
            var viewmodel = new ViewModel();
            Haber TargetID = db.Haber.Find(id);
            viewmodel.ListY = db.Yorum1.ToList();
            viewmodel.yorum1 = new Yorum1();
            viewmodel.TargetId = TargetID;
            return View(viewmodel);
        }

    }
}