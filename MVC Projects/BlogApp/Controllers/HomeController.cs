using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            ViewData["title"] = "Anasayfa";
            var posts = new List<Post>();
            posts.Add(
                new Post()
                {
                    Title = "Baþlýk",
                    Summary = "Özet",
                    ImgUrl = "https://source.unsplash.com/collection/1346951/1000x500?sig=1"
                }
            );

            posts.Add(
                new Post()
                {
                    Title = "Diðer Baþlýk",
                    Summary = "Diðer Özet",
                    ImgUrl = "https://source.unsplash.com/collection/1346951/1000x500?sig=1"
                }
            );
            return View(posts);
        }

        public IActionResult Hakkimda()
        {
            ViewData["title"] = "Hakkýmda";
            return View(150);
        }

        public IActionResult Detay()
        {
            var postDetail = new Post();
            postDetail.Title = "deneme";
            postDetail.Content = "<p class=\"pb-3\">uzun bir içerik</p>";
            postDetail.ImgUrl = "https://source.unsplash.com/collection/1346951/1000x500?sig=1";
            ViewData["title"] = "Gönderi Detay";

            return View(postDetail);
        }
        
    }
}
