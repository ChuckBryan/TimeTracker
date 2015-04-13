using System.Linq;
using System.Web.Mvc;
using TimeTracker.Web.Data;
using TimeTracker.Web.Infrastructure;
using Microsoft.Web.Mvc;
using TimeTracker.Web.Models.Home;

namespace TimeTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrentUser _currentUser;
        private readonly AppDbContext _database;

        public HomeController(ICurrentUser currentUser, AppDbContext database)
        {
            _currentUser = currentUser;
            _database = database;
        }

        public ActionResult Index()
        {
            var result = _database.EntryLogs.Select(x => new EntryLogViewModel
            {
                Id = x.EntryLogId,
                Duration = x.Duration,
                Description = x.Description,
                Project= x.Project,
                EntryDate = x.EntryDate


            }).ToArray();



            return View(result);
        }


        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}