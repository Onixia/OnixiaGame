using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onixia.Data.Contracts;

namespace OnixiaWebApplication.Controllers
{
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
                return View();
            }
            else
            {
                return RedirectToAction("Splash");
            }
        }

        public ActionResult Splash()
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