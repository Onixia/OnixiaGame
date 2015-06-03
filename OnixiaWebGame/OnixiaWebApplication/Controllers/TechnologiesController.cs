using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnixiaWebApplication.Controllers
{
    public class TechnologiesController : Controller
    {
        // GET: Technologies
        public ActionResult Index()
        {
            bool canBuild = true;
            bool isBuilding = false;
            int shipsCount = 0;
            int buildingCount = 0;

            return View();
        }
    }
}