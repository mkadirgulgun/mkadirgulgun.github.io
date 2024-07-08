using Microsoft.AspNetCore.Mvc;
using MVCUrunSatisSistemi.Models;
using System.Diagnostics;

namespace MVCUrunSatisSistemi.Controllers
{
    public class HomeController : Controller
    {
        public void SaveTxt(List<Shop> products)
        {
            var linesTxt = "";
            foreach(var product in products)
            {
                linesTxt += $"{product.Id}|{product.Name}|{product.Price}|{product.Currency}|{product.ImgUrl}|{product.Stock}{(product != products.Last() ? "\n" : "")}";
            }
            using StreamWriter writer = new("App_Data/index.txt");
            writer.Write(linesTxt);
        }

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
                            Currency = product[3],
                            Stock = int.Parse(product[4]),
                            ImgUrl = product[5],
                        }
                        );
                }
            }
            return products;
        }
        [HttpGet]
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
                if (selectedProduct.Stock <= 0)
                {
                    ViewData["Msg"] = "<div class=\"alert alert-warning\">Bu ürünün stoðu kalmadý.</div>";
                    return View(products);
                }

                selectedProduct.Price = model.Quantity * selectedProduct.Price;

                if (model.Payment >= selectedProduct.Price)
                {
                    model.Change = model.Payment - selectedProduct.Price;
                    selectedProduct.Stock -= model.Quantity;
                    SaveTxt(products);

                    return View("PaymentSuccess", model);
                }
                else
                {
                    ViewData["Msg"] = $"Yetersiz ödeme miktarý. {selectedProduct.Price - model.Payment} TL daha ekleyin.";
                }
            }
            //var selectedProduct = new Shop();
            //foreach (var product in products)
            //{
            //    if(selectedProduct.Id == product.Id)
            //    {
            //        selectedProduct = product;
            //        break;
            //    }
            //}
            //if(selectedProduct.Stock <= 0)
            //{
            //    ViewData["Msg"] = "<div class=\"alert alert-warning\">Bu ürünün stoðu kalmadý.</div>";
            //    return View(products);

            //}
            //var change = model.Payment - selectedProduct.Price;

            //if(change >= 0)
            //{
            //    selectedProduct.Stock --;
            //    ViewData["Msg"] = $"<div class=\"alert alert-success\">Teþekkür ederiz. {(change > 0 ? $"Para üstünüz {change} TL" : "")}</div>";
            //}
            //else
            //{
            //    ViewData["Msg"] = $"<div class=\"alert alert-danger\">Paranýz yetersiz. {selectedProduct.Price- model.Payment} TL eksik.</div>";
            //}

            return View(products);
        }

        public IActionResult PaymentSuccess() { return View(); }
    }
}
