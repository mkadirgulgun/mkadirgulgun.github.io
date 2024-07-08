﻿using IlanSitesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IlanSitesi.Controllers
{
    public class EditorController : Controller
    {
        public List<Ilan> UrunleriGetir()
        {
            var ilanlar = new List<Ilan>();
            using StreamReader reader = new StreamReader("App_Data/ilanlar.txt");
            var txt = reader.ReadToEnd();

            if (string.IsNullOrEmpty(txt))
            {
                return ilanlar;
            }

            var txtLines = txt.Split("\n");
            foreach (var urun in txtLines)
            {
                var txtParts = urun.Split("|");
                ilanlar.Add(
                    new Ilan
                    {
                        Name = txtParts[0],
                        Price = int.Parse(txtParts[1]),
                        Img = txtParts[2],
                        Date = DateTime.Parse(txtParts[3])
                    });
            }

            return ilanlar;
        }

        public void TxtKaydet(List<Ilan> ilanlar)
        {
            var txt = "";
            foreach (var ilan in ilanlar)
            {
                txt += $"{ilan.Name}|{ilan.Price}|{ilan.Img}|{ilan.Date}\n";
            }

            txt = txt.Substring(0, txt.Length - 1);

            using StreamWriter writer = new StreamWriter("App_Data/ilanlar.txt");
            writer.Write(txt);
        }

        public IActionResult Index()
        {
            return View(UrunleriGetir());
        }

        public IActionResult IlanEkle()
        {
            
            return View(UrunleriGetir());
        }

        [HttpPost]
        public IActionResult IlanEkle(Ilan model)
        {
            var ilanlar = UrunleriGetir();

            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Ürün eklenemedi!";
                return View("IlanEkle", ilanlar);
            }

            ilanlar.Add(model);
            TxtKaydet(ilanlar);
            ViewData["Mesaj"] = "İlan başarıyla eklendi";

            return View();
        }

        public IActionResult IlanGuncelle()
        {
            return View(UrunleriGetir());
        }

        [HttpPost]
        public IActionResult IlanGuncelle(Ilan model)
        {
			var ilanlar = UrunleriGetir();

			if (!ModelState.IsValid)
			{
				ViewData["Hata"] = "Ürün Güncellenemedi!";
				return View("IlanGuncelle", ilanlar);
			}

			for (int i = 0; i < ilanlar.Count; i++)
			{
				if (ilanlar[i].Name == model.Name)
				{
					ilanlar[i] = model;
					ViewData["Mesaj"] = "Ürün Güncellendi!";
					break;
				}
			}

			TxtKaydet(ilanlar);
			return View("IlanGuncelle", ilanlar);
        }

        public IActionResult IlanSil()
        {
            return View(UrunleriGetir());
        }

        [HttpPost]
        public IActionResult IlanSil(Ilan model)
        {
            var ilanlar = UrunleriGetir();

            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Ürün silinemedi!";
                return View("IlanSil", ilanlar);
            }

            for (int i = 0; i < ilanlar.Count; i++)
            {
                if (ilanlar[i].Name == model.Name)
                {
                    ilanlar.RemoveAt(i);
                    ViewData["Mesaj"] = "Ürün Silindi!";
                    break;
                }
            }

            TxtKaydet(ilanlar);

            return View(ilanlar);
        }

        public void Listele()
        {
            static void Main()
            {
                var list = new List<DateTime>();
                list.Add(new DateTime(1980, 5, 5));
                list.Add(new DateTime(1982, 10, 20));
                list.Add(new DateTime(1984, 1, 4));
                list.Add(new DateTime(1979, 6, 19));

                Display(SortAscending(list), "SortAscending");
                Display(SortDescending(list), "SortDescending");
                Display(SortMonthAscending(list), "SortMonthAscending");
                Display(SortMonthDescending(list), "SortMonthDescending");

            }

            static List<DateTime> SortAscending(List<DateTime> list)
            {
                list.Sort((a, b) => a.CompareTo(b));
                return list;
            }

            static List<DateTime> SortDescending(List<DateTime> list)
            {
                list.Sort((a, b) => b.CompareTo(a));
                return list;
            }

            static List<DateTime> SortMonthAscending(List<DateTime> list)
            {
                list.Sort((a, b) => a.Month.CompareTo(b.Month));
                return list;
            }

            static List<DateTime> SortMonthDescending(List<DateTime> list)
            {
                list.Sort((a, b) => b.Month.CompareTo(a.Month));
                return list;
            }

            static void Display(List<DateTime> list, string message)
            {
                Console.WriteLine(message);
                foreach (var datetime in list)
                {
                    Console.WriteLine(datetime);
                }
                Console.WriteLine();
            }

        }
    }
}
