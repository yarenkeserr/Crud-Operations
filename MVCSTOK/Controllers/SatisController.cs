using MVCSTOK.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSTOK.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MVCSTOKEntities db = new MVCSTOKEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(satıslar p1)
        {
            db.satıslar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }


    }
}