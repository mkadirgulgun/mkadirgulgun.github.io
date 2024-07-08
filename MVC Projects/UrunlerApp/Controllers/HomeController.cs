using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrunlerApp.Models;

namespace UrunlerApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(UrunleriGetir());
        }

        public IActionResult SatinAl(SatisModel model)
        {
            var urunler = UrunleriGetir();

            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Ürün seçimi yapýlmadý!";
                return View("Index", urunler);
            }

            Urun? alinacakUrun = null;
            foreach (var urun in urunler)
            {
                if (urun.Ad == model.Ad)
                {
                    alinacakUrun = urun;
                }
            }

            if (alinacakUrun == null)
            {
                ViewData["Hata"] = "Ürün bulunamadý!";
                return View();
            }

            if (alinacakUrun.Stok < 1)
            {
                ViewData["Hata"] = "Stokta ürün kalmadý!";
                return View();
            }

            alinacakUrun.Stok--;
            DegisiklikleriKaydet(urunler);
            SatisEkle(alinacakUrun);

            return View();
        }

        static void SatisEkle(Urun urun)
        {
            using StreamReader reader = new StreamReader("App_Data/satislar.txt");
            var satislarTxt = reader.ReadToEnd();
            reader.Close();

            if (!string.IsNullOrEmpty(satislarTxt))
            {
                satislarTxt += "\n";
            }

            using StreamWriter writer = new StreamWriter("App_Data/satislar.txt");
            writer.Write($"{satislarTxt}{urun.Ad}|{urun.Fiyat}");
        }

        static void DegisiklikleriKaydet(List<Urun> urunler)
        {
            var txt = "";
            foreach (var urun in urunler)
            {
                txt += $"{urun.Ad}|{urun.Fiyat}|{urun.Stok}\n";
            }
            txt = txt.Substring(0, txt.Length - 1);

            using StreamWriter writer = new StreamWriter("App_Data/urunler.txt");
            writer.Write(txt);
        }

        public List<Urun> UrunleriGetir()
        {
            var urunler = new List<Urun>();

            using StreamReader reader = new StreamReader("App_Data/urunler.txt");
            var urunlerTxt = reader.ReadToEnd();
            var txtLines = urunlerTxt.Split("\n");

            foreach (var line in txtLines)
            {
                urunler.Add(
                    new Urun
                    {
                        Ad = line.Split("|")[0],
                        Fiyat = int.Parse(line.Split("|")[1]),
                        Stok = int.Parse(line.Split("|")[2])
                    }
                );
            }

            return urunler;
        }

        public IActionResult Rapor()
        {
            var satislar = new List<Satis>();
            var toplamSatis = 0;

            using StreamReader reader = new StreamReader("App_Data/satislar.txt");
            var satislarTxt = reader.ReadToEnd();
            var txtLines = satislarTxt.Split("\n");

            foreach (var line in txtLines)
            {
                var fiyat = int.Parse(line.Split("|")[1]);
                var urunAdi = line.Split("|")[0];
                toplamSatis += fiyat;

                Satis? oncekiSatis = SatisKaydiBul(urunAdi, satislar);
                if (oncekiSatis == null)
                {
                    satislar.Add(
                     new Satis
                     {
                         UrunAdi = urunAdi,
                         ToplamSatis = fiyat,
                         Adet = 1
                     }
                );
                }
                else
                {
                    oncekiSatis.ToplamSatis += fiyat;
                    oncekiSatis.Adet++;
                }
            }

            //ViewData["ToplamSatis"] = toplamSatis;
            ViewBag.Toplam = toplamSatis;
            return View(satislar);
        }

        public Satis? SatisKaydiBul(string urunAdi, List<Satis> satislar)
        {
            foreach (var satis in satislar)
            {
                if (satis.UrunAdi == urunAdi)
                {
                    return satis;
                }
            }

            return null;
        }
    }
}
