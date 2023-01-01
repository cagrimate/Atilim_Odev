using Atilim_Odev.Models.Siniflar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atilim_Odev.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AtilimContext _db;
        public OgrenciController(ILogger<HomeController> logger, AtilimContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            var sid = HttpContext.Session.GetString("ID");
            var id = int.Parse(sid);

            var kimlikId = _db.Kullanicilar.Find(id).kimlikId;
            var kisi = _db.Kimlik.Find(kimlikId);


            return View(kisi);
        }
        //ogrenci iletisim bilgilerini görmeli ve guncellemeli....

        public IActionResult Iletisim()
        {
            var sid = HttpContext.Session.GetString("ID");
            var id = int.Parse(sid);

            var kimlikId = _db.Kullanicilar.Find(id).kimlikId;
            var iletisimID = _db.Kimlik.Find(kimlikId).IletisimId;

            var iletisim = _db.Iletisim.Find(iletisimID);
            return View(iletisim);
        }

        public IActionResult IletisimGuncelle()
        {

            var sid = HttpContext.Session.GetString("ID");
            var id = int.Parse(sid);

            var kimlikId = _db.Kullanicilar.Find(id).kimlikId;
            var iletisimID = _db.Kimlik.Find(kimlikId).IletisimId;

            var iletisim = _db.Iletisim.Find(iletisimID);


            return View(iletisim);
        }

        [HttpPost]
        public IActionResult IletisimGuncelle(int? id, Iletisim iletisim)
        {
            _db.Update(iletisim);
            _db.SaveChanges();

            return RedirectToAction("Iletisim", "Ogrenci");
        }
        //ogrenciye atanan dersler goruntulenecek
        //ogrenci tablosunda mufredat id var
        //mufredat tablosunda o id nin karşılığı olan bölümün ismi var
        //mufredat dersler tablosunda da ders ıd var 
        // bu ders id ile dersler tablosundan öğrenciye acık olan dersleri görüntüleyebiliriz

        public IActionResult Mufredat()
        {
            var sid = HttpContext.Session.GetString("ID");
            var id = int.Parse(sid); //kullanici id
            var kimlikId = _db.Kullanicilar.Find(id).kimlikId; //kimlik ıd

            var ogrenci = _db.Ogrenci.FirstOrDefault(x => x.KimlikId == kimlikId);


            var ogrMuf = ogrenci.MufredatId; //mufredat ıd
            var dersler = _db.Mufredatlar.Include(x => x.Dersler).SingleOrDefault(x => x.Id == ogrMuf);
            List<Dersler> aktifDersler = new List<Dersler>();

            foreach (var item in dersler.Dersler)
            {
                if (item.Durum == true)
                {
                    aktifDersler.Add(item);
                };
            }
            return View(aktifDersler);
        }

        //derse kayıt sayfası
        public IActionResult DersKayit(Ders_Kayit dersKayit)
        {

            return View();
        }
        [HttpPost]
        public IActionResult DersKayit(int? did, Ders_Kayit dersKayit)
        {

            var sid = HttpContext.Session.GetString("ID");
            var id = int.Parse(sid); //kullanici id
            var kimlikId = _db.Kullanicilar.Find(id).kimlikId; //kimlik ıd

            var ogrenci = _db.Ogrenci.FirstOrDefault(x => x.KimlikId == kimlikId).Id;


            Ders_Kayit drs = new Ders_Kayit();
            drs.OgrenciId = ogrenci;
            drs.DersId = dersKayit.Id;//ID olcak
            drs.CreatedDate = DateTime.Now;

            if (_db.Ders_Kayit.Any(x => x.DersId == dersKayit.Id && x.OgrenciId == ogrenci))
            {
                return NotFound();
                //todo
                //hata yonetimi hatası
            }
            else
            {
                _db.Ders_Kayit.Add(drs);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Ogrenci");

        }

    }
}
