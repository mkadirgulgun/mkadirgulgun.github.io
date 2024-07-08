using BlogGrup.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace BlogGrup.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var connectionString = "Server=104.247.162.242\\MSSQLSERVER2019;Initial Catalog=mehmetiy_bloggrup;User Id=mehmetiy_blogdbgrup;Password=938&9pOam;TrustServerCertificate=True";

            // Connect to the database 
            using var connection = new SqlConnection(connectionString);

            var sql = "SELECT * FROM bloggrup";
            var posts = connection.Query<Post>(sql).ToList();

            return View(posts);
        }

        public IActionResult Detay(int id)
        {
            var connectionString = "Server=104.247.162.242\\MSSQLSERVER2019;Initial Catalog=mehmetiy_bloggrup;User Id=mehmetiy_blogdbgrup;Password=938&9pOam;TrustServerCertificate=True";

            // Connect to the database 
            using var connection = new SqlConnection(connectionString);

            var sql = "SELECT * FROM bloggrup WHERE id = @id";
            var post = connection.QuerySingle<Post>(sql, new { id = id });

            return View(post);
        }
    }
}
