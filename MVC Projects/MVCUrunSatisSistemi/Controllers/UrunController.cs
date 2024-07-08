using Microsoft.AspNetCore.Mvc;
using MVCUrunSatisSistemi.Models;

namespace MVCUrunSatisSistemi.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kasa()
        {
            var products = new List<Urun>();
            using StreamReader reader = new StreamReader("App_Data/index.txt");
            var productsTxt = reader.ReadToEnd();
            if (!string.IsNullOrEmpty(productsTxt))
            {
                var productsList = productsTxt.Split('\n');
                foreach (var productLine in productsList)
                {
                    var product = productLine.Split('|');
                    products.Add(
                        new Urun
                        {
                            Name = product[0],
                            Price = double.Parse(product[1]),
                            Currency = product[2],
                            Stock = int.Parse(product[3]),
                            ImgUrl = product[4]
                        }
                        );
                }
            }
            return View(products);
        }

        public IActionResult SatisYap()
        {

            var products = new List<Satis>();
            products.Add
            return View();
        }
    }
}
