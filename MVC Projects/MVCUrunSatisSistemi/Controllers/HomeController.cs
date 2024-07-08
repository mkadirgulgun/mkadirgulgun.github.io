using Microsoft.AspNetCore.Mvc;
using MVCUrunSatisSistemi.Models;
using System.Diagnostics;

namespace MVCUrunSatisSistemi.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Urun model)
        {
            
            return View("Basarili", model);
        }
    }
}
