using Dapper;
using IsTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace IsTakip.Controllers
{
    public class AdminController : Controller
    {
        string connectionString = "TrustServerCertificate=True";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(JobModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MessageCssClass = "alert-danger";
                ViewBag.Message = "Eksik veya hatalı işlem yaptın";
                return View("Message");
            }
            using var connection = new SqlConnection(connectionString);
            var ilanlar = "INSERT INTO jobs (Person, JobTitle, JobDetail, StatusId) VALUES (@Person, @JobTitle, @JobDetail, @Status)";
            
            var data = new
            {
                model.Person,
                model.JobTitle,
                model.JobDetail,
                model.Status,
            };

            var rowsAffected = connection.Execute(ilanlar, data);
            
            ViewBag.MessageCssClass = "alert-success";
            ViewBag.Message = "Eklendi.";
            ViewBag.Return = "IlanEkle";
            return View("Message");
        }
    }
}
