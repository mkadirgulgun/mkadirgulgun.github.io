using HaberlerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HaberlerApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var news = new List<Haber>();
            using StreamReader reader = new StreamReader("App_Data/haberler.txt");
            var newsTxt = reader.ReadToEnd();

            if (!string.IsNullOrEmpty(newsTxt))
            {
                var newsLines = newsTxt.Split('\n');
                foreach (var line in newsLines)
                {
                    var lineParts = line.Split('|');
                    news.Add(
                        new Haber()
                        {
                            Baslik = lineParts[0],
                            Detay = lineParts[1]
                        });
                }
            }
            return View(news);
        }
    }
}
