using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCMagaza.Models;
using System.Diagnostics;

namespace MVCMagaza.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            var products = GetAllProduct();
            var bannerPosts = GetBanner();

            var model = new ViewModel
            {
                Products = products,
                Banner = bannerPosts
            };

            return View(model);
        }

       

        public List<Shop> GetBanner()
        {
            var posts = new List<Shop>();
            using StreamReader reader = new StreamReader("AppData/products/banner.txt");
            var postsTxt = reader.ReadToEnd();
            var postsLines = postsTxt.Split('\n');
            foreach (var postLine in postsLines)
            {
                var postParts = postLine.Split('|');
                posts.Add(
                    new Shop()
                    {
                        Product = postParts[0],
                        Price = int.Parse(postParts[1]),
                        Currency = postParts[2],
                        ImgUrl = postParts[3],
                    }
                );
            }
            return posts;
        }
        public List<Shop> GetAllProduct()
        {
            var posts = new List<Shop>();   
            using StreamReader reader = new StreamReader("AppData/products/index.txt");
            var postsTxt = reader.ReadToEnd();
            var postsLines = postsTxt.Split('\n');
            foreach (var postLine in postsLines)
            {
                var postParts = postLine.Split('|');
                posts.Add(
                    new Shop()
                    {
                        Product = postParts[0],
                        Price = int.Parse(postParts[1]),
                        Currency = postParts[2],
                        ImgUrl = postParts[3],
                        Slug = postParts[4]
                    }
                );
            }
            return posts;
        }
    }
}
