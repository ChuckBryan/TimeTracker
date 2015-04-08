using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Web.Data;
using TimeTracker.Web.Infrastructure;

namespace TimeTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrentUser _currentUser;

        public HomeController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;

           
        }

        public ActionResult Index()
        {
            ViewBag.Message = string.Format("Hello, {0}!", _currentUser.UserName);
            return View();
        }


        public ActionResult SetName()
        {
            return View();
        }

        public ActionResult SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Error = "You must specify a name!";
                return View();
            }

            _currentUser.SetName(name);

            return RedirectToAction("Index");
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