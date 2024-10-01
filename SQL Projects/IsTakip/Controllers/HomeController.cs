using Dapper;
using IsTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection;

namespace IsTakip.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = "TrustServerCertificate=True";

        public IActionResult Index()
        {
            using var connection = new SqlConnection(connectionString);
            var jobs = connection.Query<JobModel>("SELECT Person, SUM(CASE WHEN jobs.StatusId = 1 THEN 1 ELSE 0 END) as Active,SUM(CASE WHEN jobs.StatusId = 2 THEN 1 ELSE 0 END) as Completed, COUNT(Jobs.Id) as Total FROM status LEFT JOIN jobs ON status.Id = jobs.StatusId GROUP BY Person").ToList();

            return View(jobs);
        }

        public IActionResult ShowAllJobs()
        {
            using var connection = new SqlConnection(connectionString);
            var jobs = connection.Query<JobModel>("SELECT jobs.Id,Person,JobTitle,StatusId, Date, Status, SUM(CASE WHEN jobs.StatusId = 1 THEN 1 ELSE 0 END) as Active,SUM(CASE WHEN jobs.StatusId = 2 THEN 1 ELSE 0 END) as Completed, COUNT(Jobs.Id) as Total FROM jobs LEFT JOIN status ON status.Id = jobs.StatusId GROUP BY Person,JobTitle,StatusId, jobs.Id, Date, Status ORDER BY Status").ToList();

            return View(jobs);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT jobs.*, status.status FROM jobs LEFT JOIN status ON status.Id = jobs.StatusId WHERE jobs.Id = @Id";
                var post = connection.QuerySingleOrDefault<JobModel>(sql, new { Id = id });

                return View(post);
            }
        }

        public IActionResult Duzenle(int? id)
        {
            using var connection = new SqlConnection(connectionString);
            var edit = connection.QuerySingleOrDefault<JobModel>("SELECT * FROM jobs LEFT JOIN status ON status.Id = jobs.StatusId WHERE jobs.Id = @id", new { id = id });

            return View(edit);
        }
        [HttpPost]
        public IActionResult Duzenle(JobModel model)
        {
            using var connection = new SqlConnection(connectionString);

            var sql = "UPDATE jobs SET JobTitle=@JobTitle, JobDetail=@JobDetail, Person=@Person, Date = @Date WHERE jobs.Id = @Id";

            var parameters = new
            {
                model.JobTitle,
                model.JobDetail,
                Date = DateTime.Now,
                model.Person,
                model.Id,
            };
            var affectedRows = connection.Execute(sql, parameters);

            ViewBag.Message = "Güncellendi.";
            ViewBag.MessageCssClass = "alert-success";
            return View("Message");
        }

        public IActionResult Sil(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "DELETE FROM jobs WHERE Id = @Id";

            var rowsAffected = connection.Execute(sql, new { Id = id });

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id,JobModel model)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "UPDATE jobs SET StatusId = @StatusId WHERE jobs.Id = @Id";
            var parameters = new
            {
                model.StatusId,
                Id = id,
                
            };
            var affectedRows = connection.Execute(sql, parameters);
            ViewBag.Message = "Güncellendi.";
            ViewBag.MessageCssClass = "alert-success";
            return View("Message");
        }
    }
}
