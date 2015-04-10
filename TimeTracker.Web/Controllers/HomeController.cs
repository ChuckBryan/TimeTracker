using System.Web.Mvc;
using TimeTracker.Web.Infrastructure;
using Microsoft.Web.Mvc;

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