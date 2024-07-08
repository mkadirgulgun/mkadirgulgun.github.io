using Microsoft.AspNetCore.Mvc;
using MVCUrunSatisSistemi.Models;
using System.Diagnostics;
using System.Reflection;

namespace MVCUrunSatisSistemi.Controllers
{
    //public class HomeController : Controller
    //{


    //    public IActionResult Index()
    //    {
    //        var products = new List<Shop>();
    //        using StreamReader reader = new StreamReader("App_Data/index.txt");
    //        var productsTxt = reader.ReadToEnd();
    //        if (!string.IsNullOrEmpty(productsTxt))
    //        {
    //            var productsList = productsTxt.Split('\n');
    //            foreach(var productLine in productsList)
    //            {
    //                var product = productLine.Split('|');
    //                products.Add(
    //                    new Shop
    //                    {
    //                        Name = product[0],
    //                        Price = double.Parse(product[1]),
    //                        Currency = product[2],
    //                        Stock = int.Parse(product[3]),
    //                        ImgUrl = product[4]
    //                    }
    //                    );
    //            }
    //        }
    //        return View(products);
    //    }
    //    [HttpPost]
    //    public IActionResult Index(int payment)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            ViewData["Hata"] = "Form eksik!!";
    //            return View("Index");
    //        }



    //        // Ödeme iþlemleri burada yapýlabilir
    //        // Örneðin, stok güncelleme, ödeme kaydetme vs.

    //        return Ok("Satýn alma iþlemi baþarýyla tamamlandý.");
    //    }


    //}
    // CheckoutController.cs
    public class CheckoutController : Controller
    {
        private List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 50 },
        new Product { Id = 2, Name = "Product 2", Price = 75 },
        new Product { Id = 3, Name = "Product 3", Price = 100 }
    };

        public IActionResult ProductSelection()
        {
            var model = new CheckoutViewModel
            {
                Products = products
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProcessPayment(int selectedProduct, decimal amount)
        {
            var selected = products.FirstOrDefault(p => p.Id == selectedProduct);
            if (selected != null && amount >= selected.Price)
            {
                return RedirectToAction("PaymentSuccess");
            }
            else
            {
                var model = new CheckoutViewModel
                {
                    Products = products,
                    PaymentError = "Payment amount is less than the product price. Please try again."
                };
                return View("ProductSelection", model);
            }
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }
    }

}
