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
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVCSTOKEntities db = new MVCSTOKEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.musteriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(musteriler p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.musteriler.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.musteriler.Find(id);
            db.musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.musteriler.Find(id);
            return View("MusteriGetir", musteri);

        }
        public ActionResult Guncelle(musteriler p1)
        {
            var musteri = db.musteriler.Find(p1.musteri_id);
            musteri.musteri_adi = p1.musteri_adi;
            musteri.musteri_soyad = p1.musteri_soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}