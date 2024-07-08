using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using MVCUrunSatisSistemi.Models;
using System.Diagnostics;

namespace MVCUrunSatisSistemi.Controllers
{
    public class HomeController : Controller
    {
        public List<Shop> ReadTxt()
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
                            //Currency = product[3],
                            Stock = int.Parse(product[3]),
                            //ImgUrl = product[5]
                        }
                        );
                }
            }
            return products;
        }

        public IActionResult Index()
        {
            var products = ReadTxt();
            return View(products);
        }
        [HttpPost]
        public IActionResult Index(PaymentViewModel model)
        {
            var products = ReadTxt();

            var selectedProduct = products.FirstOrDefault(product => product.Id == model.SelectedProduct);

            if (selectedProduct != null)
            {
                var totalPrice = model.Quantity * selectedProduct.Price;
                if (model.Payment >= selectedProduct.Price)
                {
                    selectedProduct.Stock -= model.Quantity;
                    SaveTxt(products);


                    model.Change = model.Payment - totalPrice;
                    ViewData["Hata"] = $"<div class=\"alert alert-success\">Teþekkür ederiz. {(model.Change > 0 ? $"Para üstünüz {model.Change} TL" : "")}</div>";

                    var salesTxt = $"{selectedProduct.Id}|{selectedProduct.Name}|{selectedProduct.Price}|{model.Quantity}|{totalPrice}";

                    using StreamWriter writerSale = new("App_Data/satislar.txt");
                    writerSale.Write(salesTxt);
                }
                else
                {
                    ViewData["Hata"] = $"<div class=\"alert alert-danger\">Paranýz yetersiz. {totalPrice - model.Payment} TL eksik.</div>";
                }
            }
            return View(products);
        }

        public void SaveTxt(List<Shop> products)
        {
            var satirlarTxt = "";
            foreach (var product in products)
            {
                satirlarTxt += $"{product.Id}|{product.Name}|{product.Price}|{product.Stock}{(product != products.Last() ? "\n" : "")}";
            }
            using StreamWriter writer = new("App_Data/index.txt");
            writer.Write(satirlarTxt);
            writer.Close();

        }
        public IActionResult PaymentSuccess() { return View(); }
    }
}
