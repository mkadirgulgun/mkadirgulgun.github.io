using Microsoft.AspNetCore.Mvc;
using Sale.Models;
using System.Diagnostics;

namespace Sale.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var urunler = UrunleriGetir();
            return View(urunler);
        }

        [HttpPost]
        public IActionResult Index(SatisModel model)
        {
            var urunler = UrunleriGetir();

            var alinacakUrun = new Urun();
            foreach (var urun in urunler)
            {
                if (urun.Ad == model.Ad)
                {
                    alinacakUrun = urun;
                    break;
                }
            }

            if (alinacakUrun.Stok <= 0)
            {
                ViewData["Msg"] = "<div class=\"alert alert-warning\">Bu ürünün stoðu kalmadý.</div>";
                return View(urunler);
            }

          
            var paraUstu = model.Para - alinacakUrun.Fiyat;

            if (paraUstu >= 0)
            {
              
                alinacakUrun.Stok--;
                DegisiklikleriKaydet(urunler);

                ViewData["Msg"] = $"<div class=\"alert alert-success\">Teþekkür ederiz. {(paraUstu > 0 ? $"Para üstünüz {paraUstu} TL" : "")}</div>";
            }
            else
            {
                ViewData["Msg"] = $"<div class=\"alert alert-danger\">Paranýz yetersiz. {alinacakUrun.Fiyat - model.Para} TL eksik.</div>";
            }

        

            return View(urunler);
        }

        public void DegisiklikleriKaydet(List<Urun> urunler)
        {
            var satirlarTxt = "";
            foreach (var urun in urunler)
            {
                satirlarTxt += $"{urun.Ad}|{urun.Fiyat}|{urun.Stok}|{urun.ImgUrl}{(urun != urunler.Last() ? "\n" : "")}";
            }

           
            using StreamWriter writer = new("App_Data/urunler.txt");
            writer.Write(satirlarTxt);
        }

        public List<Urun> UrunleriGetir()
        {
            var urunler = new List<Urun>();

            using StreamReader reader = new("App_Data/urunler.txt");
            var urunlerTxt = reader.ReadToEnd();
            var urunlerSatirlar = urunlerTxt.Split('\n');
            foreach (var satir in urunlerSatirlar)
            {
                var urunSatir = satir.Split('|');
                urunler.Add(new Urun
                {
                    Ad = urunSatir[0],
                    Fiyat = int.Parse(urunSatir[1]),
                    Stok = int.Parse(urunSatir[2]),
                    ImgUrl = urunSatir[3]
                });
            }

            return urunler;
        }
    }
}
