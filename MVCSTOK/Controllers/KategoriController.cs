using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entitiy;
using PagedList;
using PagedList.Mvc;

namespace MVCSTOK.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCSTOKEntities db = new MVCSTOKEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.kategoriler.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SIL(int id)
        {
            var kategori = db.kategoriler.Find(id);
            db.kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult Guncelle(kategoriler p1)
        {
            var kategori = db.kategoriler.Find(p1.kategori_id);
            kategori.kategori_adi = p1.kategori_adi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}