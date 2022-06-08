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
    public class UrunController : Controller
    {
        // GET: Urun
        MVCSTOKEntities db = new MVCSTOKEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler=db.urunler.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategori_adi, Value = i.kategori_id.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;                                            
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(urunler p1)
        {
            var kategori =db.kategoriler.Where(m=>m.kategori_id==p1.kategoriler.kategori_id).FirstOrDefault();
            p1.kategoriler = kategori;
            db.urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.urunler.Find(id);
            db.urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategori_adi,
                                                 Value = i.kategori_id.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(urunler p1)
        {
            var urun = db.urunler.Find(p1.urun_id);
            urun.urun_adi = p1.urun_adi;
            //urun.kategori_id = p1.kategori_id;
            var kategori = db.kategoriler.Where(m => m.kategori_id == p1.kategoriler.kategori_id).FirstOrDefault();
            urun.kategori_id=kategori.kategori_id;
            urun.fiyat = p1.fiyat;
            urun.marka=p1.marka;
            urun.stok = p1.stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}