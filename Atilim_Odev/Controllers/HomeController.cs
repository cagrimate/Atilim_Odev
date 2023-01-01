using Atilim_Odev.Models;
using Atilim_Odev.Models.Siniflar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Atilim_Odev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //db baglantı
        private readonly AtilimContext _db;
        public HomeController(ILogger<HomeController> logger,AtilimContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Kullanicilar k)
        {
            var bilgiler = _db.Kullanicilar.FirstOrDefault(x => x.Kullanici_Adi == k.Kullanici_Adi && x.Sifre == k.Sifre);
            if (bilgiler != null)
            {
                HttpContext.Session.SetString("KullaniciAdi", bilgiler.Kullanici_Adi);
                HttpContext.Session.SetString("Sifre", bilgiler.Sifre);
                HttpContext.Session.SetString("ID", bilgiler.Id.ToString());

                var id = HttpContext.Session.GetString("ID");

                if (bilgiler.Id.ToString() == "1")
                {
                    return RedirectToAction("Index", "Admin"); // once view sonra controller
                }
                else
                {
                    return RedirectToAction("Index", "Ogrenci");
                }
            }
            else
            {
                ViewBag.hata = " Kullanici Adi veya Sifre hatalı !.";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            var orglist = _db.Ogrenci.ToList();
            return View(orglist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
