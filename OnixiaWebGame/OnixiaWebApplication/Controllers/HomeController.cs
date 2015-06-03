namespace OnixiaWebApplication.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Onixia.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IOnixiaData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!UserProfile.Planets.Any())
                {
                    return RedirectToAction("Create", "Planet");
                }
                var time = new TimeSpan();
                return View();
            }
            return RedirectToAction("About");
        }

        public ActionResult Splash()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Onixia Web Game!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}