using Atilim_Odev.Models.Siniflar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Atilim_Odev.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //db baglantı
        private readonly AtilimContext _db;
        public AdminController(ILogger<HomeController> logger, AtilimContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetString("ID");

            if (id == null)
            {
                //session ile ogrenci ıd si tasımalıyım ki ogrenciyse buraya yonlensin.
                //admin değildir
                return RedirectToAction("Index", "Home");
            }
            else if (id.ToString() == "1")
            {
                return View(_db.Kimlik.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Ogrenci");
            }
        }

        // yeni kullanıcı ekleme butonu
        public IActionResult YeniOgrenci()
        {
            OgrenciViewModel vm = new OgrenciViewModel();
            vm.Mufredatlar = _db.Mufredatlar.ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult YeniOgrenci(OgrenciViewModel ogrenciModel)
        {
            Iletisim iletisim = new Iletisim()
            {
                Adres = ogrenciModel.Adres,
                Email = ogrenciModel.Email,
                GSM = ogrenciModel.GSM,
                Il = ogrenciModel.Il,
                Ilce = ogrenciModel.Ilce
            };
            _db.Iletisim.Add(iletisim);
            _db.SaveChanges();
            var iletisimId = _db.Iletisim.FirstOrDefault(x => x.Email == ogrenciModel.Email && x.GSM == ogrenciModel.GSM).Id; // çeşitlenir

            Kimlik kimlik = new Kimlik()
            {
                TC_No = ogrenciModel.TC_No,
                Ad = ogrenciModel.Ad,
                Soyad = ogrenciModel.Soyad,
                DogumYeri = ogrenciModel.DogumYeri,
                DogumTarihi = ogrenciModel.DogumTarihi ?? default,
                IletisimId = iletisimId
            };

            _db.Kimlik.Add(kimlik);
            _db.SaveChanges();
            var kimlikId = _db.Kimlik.FirstOrDefault(x => x.Ad == ogrenciModel.Ad && x.Soyad == ogrenciModel.Soyad).Id; // cesitle

            Ogrenci ogrenci = new Ogrenci()
            {
                Ogr_No = ogrenciModel.Ogr_No ?? default, // nullable cözüm,
                KimlikId = kimlikId,
                MufredatId = ogrenciModel.MufredatId ?? default,
            };

            _db.Ogrenci.Add(ogrenci);
            _db.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

        //ogrenci editleme
        public ActionResult Edit(int? id)
        {
            Kimlik k = _db.Kimlik.Find(id);
            var iletisimId = k.IletisimId;
            Iletisim i = _db.Iletisim.Find(iletisimId);

            var ogrId = _db.Ogrenci.FirstOrDefault(x => x.KimlikId == k.Id).Id;
            Ogrenci o = _db.Ogrenci.Find(ogrId);

            OgrenciDuzenleViewModel odvm = new OgrenciDuzenleViewModel();

            odvm.Ogr_No = o.Ogr_No;
            odvm.TC_No = k.TC_No;
            odvm.Ad = k.Ad;
            odvm.Soyad = k.Soyad;
            odvm.DogumYeri = k.DogumYeri;
            odvm.DogumTarihi = k.DogumTarihi;
            odvm.Adres = i.Adres;
            odvm.Il = i.Il;
            odvm.Ilce = i.Il;
            odvm.Email = i.Email;
            odvm.GSM = i.GSM;

            return View(odvm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int? id, OgrenciDuzenleViewModel ogrDvm)
        {

            Kimlik kim = _db.Kimlik.Find(id);
            var iletisimId = kim.IletisimId;
            Iletisim ilId = _db.Iletisim.Find(iletisimId);

            var ogrId = _db.Ogrenci.FirstOrDefault(x => x.KimlikId == kim.Id).Id;
            Ogrenci ogId = _db.Ogrenci.Find(ogrId);

            var o = _db.Ogrenci.Find(ogrId);
            var k = _db.Kimlik.Find(id);
            var i = _db.Iletisim.Find(iletisimId);

            if (o != null)
            {
                o.Ogr_No = ogrDvm.Ogr_No ?? default;
                o.KimlikId = k.Id;
            }
            _db.SaveChanges();

            if (k != null)
            {
                k.TC_No = ogrDvm.TC_No;
                k.Ad = ogrDvm.Ad;
                k.Soyad = ogrDvm.Soyad;
                k.DogumYeri = ogrDvm.DogumYeri;
                k.DogumTarihi = ogrDvm.DogumTarihi ?? default;
                k.IletisimId = k.IletisimId;
            }
            _db.SaveChanges();
            if (i != null)
            {
                i.Adres = ogrDvm.Adres;
                i.Il = ogrDvm.Il;
                i.Ilce = ogrDvm.Ilce;
                i.Email = ogrDvm.Email;
                i.GSM = ogrDvm.GSM;
            }
            _db.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

        //ogrenci silme
        public IActionResult OgrenciSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kimlik = _db.Kimlik.FirstOrDefault(x => x.Id == id);
            if (kimlik == null)
            {
                return NotFound();
            }

            return View(kimlik);
        }

        [HttpPost]
        public IActionResult OgrenciSil(int id)
        {
            Kimlik kim = _db.Kimlik.Find(id);
            var iletisimId = kim.IletisimId;
            Iletisim ilId = _db.Iletisim.Find(iletisimId);

            var ogrId = _db.Ogrenci.FirstOrDefault(x => x.KimlikId == kim.Id).Id;
            Ogrenci ogId = _db.Ogrenci.Find(ogrId);

            var o = _db.Ogrenci.Find(ogrId);
            var k = _db.Kimlik.Find(id);
            var i = _db.Iletisim.Find(iletisimId);

            _db.Kimlik.Remove(k);
            _db.Iletisim.Remove(i);
            _db.Ogrenci.Remove(o);

            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        //iletisim goruntuleme
        public IActionResult Iletisim(int? id)
        {
            Kimlik kim = _db.Kimlik.Find(id);
            var iletisimId = kim.IletisimId;
            var iletisim = _db.Iletisim.Find(iletisimId);

            return View(iletisim);
        }

        // mufredat sayfası
        public IActionResult Mufredat()
        {
            return View(_db.Mufredatlar.ToList());
        }

        //mufredat ekle sayfası 
        public IActionResult MufredatEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MufredatEkle(Mufredat mufredat)
        {
            _db.Add(mufredat);
            _db.SaveChanges();
            return View(mufredat);
        }
        //mufredat duzenle
        public IActionResult MufredatDuzenle(int? id)
        {
            var mufredat = _db.Mufredatlar.FirstOrDefault(x => x.Id == id);
            if (mufredat == null)
            {
                return NotFound();
            }
            return View(mufredat);
        }

        [HttpPost]
        public IActionResult MufredatDuzenle(int? id, Mufredat mufredat)
        {
            _db.Update(mufredat);
            _db.SaveChanges();

            return RedirectToAction("Mufredat", "Admin");
        }

        //mufredat sil
        public IActionResult MufredatSil(int? id)
        {
            var mufredat = _db.Mufredatlar.Find(id);
            return View(mufredat);
        }

        [HttpPost]
        public IActionResult MufredatSil(int id)
        {
            var mufredat = _db.Mufredatlar.Find(id);
            _db.Mufredatlar.Remove(mufredat);
            _db.SaveChanges();

            return RedirectToAction("Mufredat", "Admin");
        }

        //ders sayfası
        public IActionResult Ders()
        {
            return View(_db.Dersler.ToList());
        }

        //Ders EKLE
        public IActionResult DersEkle(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult DersEkle(int? id, Dersler ders)
        {
            _db.Add(ders);
            _db.SaveChanges();
            return RedirectToAction("Ders", "Admin");
        }

        //Ders Duzenle
        public IActionResult DersDuzenle(int? id)
        {
            var ders = _db.Dersler.Find(id);
            return View(ders);
        }

        [HttpPost]
        public IActionResult DersDuzenle(int? id, Dersler ders)
        {
            _db.Dersler.Update(ders);
            _db.SaveChanges();
            return RedirectToAction("Ders", "Admin");
        }

        //ders sil
        public IActionResult DersSil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ders = _db.Dersler.FirstOrDefault(x => x.Id == id);

            return View(ders);
        }

        [HttpPost]
        public IActionResult DersSil(int id)
        {
            var ders = _db.Dersler.Find(id);
            _db.Dersler.Remove(ders);
            _db.SaveChanges();

            return RedirectToAction("Ders", "Admin");
        }

        //kullanıcı saysası
        public IActionResult Kullanici()
        {
            return View(_db.Kullanicilar.ToList());
        }

        //mufredat atama sayafsı
        public IActionResult MufredatAta(int id)
        {
            var ogrenciId = _db.Ogrenci.SingleOrDefault(x => x.KimlikId == id).Id;
            ViewBag.OgrenciId = ogrenciId;

            return View(_db.Mufredatlar.ToList());
        }

        //mufredat onay 
        public IActionResult MufredatOnay(int? id, int? ogrenciId)
        {
            var ogrenci = _db.Ogrenci.SingleOrDefault(x => x.Id == ogrenciId);
            ogrenci.MufredatId = id ?? default;

            _db.Ogrenci.Update(ogrenci);
            _db.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult DersGoruntule(int? id)
        {
            var ogrenci = _db.Ogrenci.FirstOrDefault(x => x.KimlikId == id);
            var dersList = _db.Ders_Kayit.Include(x => x.Ders).Where(x => x.OgrenciId == ogrenci.Id).ToList();

            return View(dersList);
        }
    }
}
