using Microsoft.AspNetCore.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    public class UrunController : Controller
    {
        public List<Urun> ReadTxt()
        {
            var urun = new List<Urun>();
            using StreamReader reader = new StreamReader("App_Data/index.txt");
            var urunData = reader.ReadToEnd();
            var urunLines = urunData.Split('\n');
            foreach (var line in urunLines)
            {
                var urunParts = line.Split('|');
                urun.Add(
                    new Urun()
                    {
                        Id = int.Parse(urunParts[0]),
                        Name = urunParts[1],
                        Price = int.Parse(urunParts[2]),
                        Currency = urunParts[3],
                        Stock = int.Parse(urunParts[4]),
                        Img = urunParts[5]
                    }
                );
            }

            return urun;
            
        }
        public IActionResult Index()
        {
            var urun = ReadTxt();
            return View(urun);
        }

        [HttpPost]
        public IActionResult Index(Satis model)
        {
            var urun = ReadTxt();


            var selectedProduct = urun.FirstOrDefault(urunler => urunler.Id == model.SelectedProduct);

            if (selectedProduct != null)
            {   
                selectedProduct.Price = model.Quantity * selectedProduct.Price;

                if (model.Payment >= selectedProduct.Price)
                {
                    model.Change = model.Payment - selectedProduct.Price;
                    return View("BasariliOdeme", model);
                }
                else
                {
                   ViewData["Hata"] = "Yetersiz ödeme miktarı. Lütfen    tekrar deneyin.";
                }

            }

            return View(urun);
        }

        public IActionResult BasariliOdeme()
        {
            return View();
        }

        
    }
}
