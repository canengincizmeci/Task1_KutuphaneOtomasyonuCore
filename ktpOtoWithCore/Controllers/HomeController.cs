using ktpOtoWithCore.Models;
using ktpOtoWithCore.Models.MyModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ktpOtoWithCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KtpCase1Context _context;

        public HomeController(ILogger<HomeController> logger, KtpCase1Context context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var kitaplar = _context.Kitaplars.Where(p => p.Aktiflik == true).OrderByDescending(p => p.Id).Select(p => new Kitap
            {
                Id = p.Id,
                Aktiflik = p.Aktiflik,
                KategoriId = p.KategoriId,
                KitapAd = p.KitapAd,
                SayfaSayisi = p.SayfaSayisi,
                Yazar = p.Yazar,
                KategoriAd = p.Kategori.KategoriAd
            }).ToList();
            return View(kitaplar);
        }
        public ActionResult Sil(int kitap_id)
        {
            _context.Kitaplars.Find(kitap_id).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Ekle()
        {

            List<SelectListItem> ktg = (from i in _context.Kategorilers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.KategoriAd,
                                            Value = i.Id.ToString()
                                        }).ToList();
            ViewBag.Ktg = ktg;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(string kitap_ad, string yazar, string sayfa_sayisi, int Id)
        {
            _context.Kitaplars.Add(new Kitaplar
            {
                Aktiflik = true,
                KategoriId = Id,
                KitapAd = kitap_ad,
                SayfaSayisi = sayfa_sayisi,
                Yazar = yazar
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Kategoriler()
        {
            var liste = _context.Kategorilers.Where(p => p.Aktiflik == true).OrderByDescending(p => p.Id).Select(p => new Kategori
            {
                Aktiflik = p.Aktiflik,
                Id = p.Id,
                KategoriAd = p.KategoriAd
            }).ToList();
            return View(liste);
        }
        public ActionResult KategoriSil(int kategori_id)
        {
            _context.Kategorilers.Find(kategori_id).Aktiflik = false;
            _context.SaveChanges();
            return RedirectToAction("Kategoriler", "Home");
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriEkle(string kategori_ad)
        {
            _context.Kategorilers.Add(new Kategoriler
            {
                Aktiflik = true,
                KategoriAd = kategori_ad
            });
            _context.SaveChanges();
            return RedirectToAction("Kategoriler", "Home");
        }
        
    }
}
