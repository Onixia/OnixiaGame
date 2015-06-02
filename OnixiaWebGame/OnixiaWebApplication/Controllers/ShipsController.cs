using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onixia.Data.Contracts;

namespace OnixiaWebApplication.Controllers
{
    public class ShipsController : BaseController
    {
        public ShipsController(IOnixiaData data)
            : base(data)
        {
        }
        // GET: Ships
        public ActionResult Index()
        {
            return View();
        }

        
    }
}