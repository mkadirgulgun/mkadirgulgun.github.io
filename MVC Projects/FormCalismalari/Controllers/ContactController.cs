using FormCalismalari.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormCalismalari.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactModel model)  
        {
            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Form eksik!!";
                return View("Index");
            }

            return View("Kayit", model);
        }
    }
}
