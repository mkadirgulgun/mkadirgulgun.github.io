using Microsoft.AspNetCore.Mvc;
using MVCUrunSatisSistemi.Models;
using System.Diagnostics;

namespace MVCUrunSatisSistemi.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            var products = new List<Shop>();
            using StreamReader reader = new StreamReader("App_Data/index.txt");
            var productsTxt = reader.ReadToEnd();
            if (!string.IsNullOrEmpty(productsTxt))
            {
                var productsList = productsTxt.Split('\n');
                foreach (var productLine in productsList)
                {
                    var product = productLine.Split('|');
                    products.Add(
                        new Shop
                        {
                            Id = int.Parse(product[0]),
                            Name = product[1],
                            Price = int.Parse(product[2]),
                            Currency = product[3],
                            Stock = int.Parse(product[4]),
                            ImgUrl = product[5]
                        }
                        );
                }
            }
            return View(products);
        }
        [HttpPost]
        public IActionResult Index(PaymentViewModel model)
        {
            var products = new List<Shop>();
            using StreamReader reader = new StreamReader("App_Data/index.txt");
            var productsTxt = reader.ReadToEnd();
            if (!string.IsNullOrEmpty(productsTxt))
            {
                var productsList = productsTxt.Split('\n');
                foreach (var productLine in productsList)
                {
                    var product = productLine.Split('|');
                    products.Add(
                        new Shop
                        {
                            Id = int.Parse(product[0]),
                            Name = product[1],
                            Price = int.Parse(product[2]),
                            Currency = product[3],
                            Stock = int.Parse(product[4]),
                            ImgUrl = product[5]
                        }
                        );
                }
            }

            var selectedProduct = products.FirstOrDefault(product => product.Id == model.SelectedProduct);

            if (selectedProduct != null)
            {
                selectedProduct.Price = model.Quantity * selectedProduct.Price;

                if (model.Payment >= selectedProduct.Price)
                {
                    model.Change = model.Payment - selectedProduct.Price;
                    return View("PaymentSuccess", model);
                }
                else
                {
                    ViewData["Hata"] = $"Yetersiz ödeme miktarý. {selectedProduct.Price-model.Payment} TL daha ekleyin.";

                }
            }
            return View(products);
        }

        public IActionResult PaymentSuccess() { return View(); }
    }
}
