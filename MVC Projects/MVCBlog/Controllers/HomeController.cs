using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCBlog.Models;
using System.Diagnostics;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            var posts = new List<Post>();
            using StreamReader reader = new StreamReader("AppData/posts/index.txt");
            var postsTxt = reader.ReadToEnd();
            var postsLines = postsTxt.Split('\n');
            foreach (var postLine in postsLines)
            {
                var postParts = postLine.Split('|');
                posts.Add(
                    new Post()
                    {
                        Title = postParts[0],
                        Summary = postParts[1],
                        Slug = postParts[2]
                    }
                );
            }
            return View(posts);
        }

        public IActionResult Iletisim()
        {
            
           
            return View();
        }
            
        public IActionResult Detay(string id)
        {
            using StreamReader reader = new StreamReader($"AppData/posts/{id}.txt");
            var postContent = reader.ReadToEnd();

            var postDetail = new Post();
            postDetail.Title = "Kadir Blog";
            postDetail.Content = postContent;


            return View(postDetail);
        }
        public IActionResult Hakkimda()
        {
            return View();
        }
    }
}
