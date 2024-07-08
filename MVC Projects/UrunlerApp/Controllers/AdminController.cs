using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using UrunlerApp.Models;

namespace UrunlerApp.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View(UrunleriGetir());
		}

		[HttpPost]
		public IActionResult Index(EklemeModel model)
		{
			var urunler = UrunleriGetir();

			if (!ModelState.IsValid)
			{
				ViewData["Hata"] = "Ürün eklenemedi!";
				return View("Index", urunler);
			}

			urunler.Add(model);
			TxtKaydet(urunler);
			ViewData["Mesaj"] = "Ürün eklendi!";

			return View();
		}

		public IActionResult Guncelle()
		{
			return View(UrunleriGetir());
		}

		[HttpPost]
		public IActionResult Guncelle(EklemeModel model)
		{
			var urunler = UrunleriGetir();

			if (!ModelState.IsValid)
			{
				ViewData["Hata"] = "Ürün Güncellenemedi!";
				return View("Guncelle", urunler);
			}

			//bool urunGuncellendi = false;
			for (int i = 0; i < urunler.Count; i++)
			{
				if (urunler[i].UrunAdi == model.UrunAdi)
				{
					urunler[i] = model;
					//urunGuncellendi = true;
					ViewData["Mesaj"] = "Ürün Güncellendi!";
					break;
				}
			}

			//if (!urunGuncellendi)
			//{
			//	urunler.Add(model);
			//}

			//urunler.Add(model);
			TxtKaydet(urunler);
			return View("Guncelle", urunler);
		}

		public void TxtKaydet(List<EklemeModel> urunler)
		{
			var txt = "";
			foreach (var urun in urunler)
			{
				txt += $"{urun.UrunAdi}|{urun.Fiyat}|{urun.Stok}\n";
			}

			txt = txt.Substring(0, txt.Length - 1);

			using StreamWriter writer = new StreamWriter("App_Data/urunler.txt");
			writer.Write(txt);
		}

		public List<EklemeModel> UrunleriGetir()
		{
			var urunler = new List<EklemeModel>();
			using StreamReader reader = new StreamReader("App_Data/urunler.txt");
			var urunlerTxt = reader.ReadToEnd();

			if (string.IsNullOrEmpty(urunlerTxt))
			{
				return urunler;
			}

			var urunlerDizi = urunlerTxt.Split("\n");
			foreach (var urun in urunlerDizi)
			{
				var urunBilgileri = urun.Split("|");
				urunler.Add(
					new EklemeModel
					{
						UrunAdi = urunBilgileri[0],
						Fiyat = int.Parse(urunBilgileri[1]),
						Stok = int.Parse(urunBilgileri[2])
					});
			}

			return urunler;
		}
	}
}
