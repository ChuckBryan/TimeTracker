using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Web.Data;

namespace TimeTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _database;

        public HomeController(AppDbContext database)
        {
            _database = database;
        }

        public ActionResult Index()
        {
            return View();
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