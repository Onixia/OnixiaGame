using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onixia.Data.Contracts;

namespace OnixiaWebApplication.Controllers
{
    public class GameController : BaseController
    {
        public GameController(IOnixiaData data)
            : base(data)
        {
        }
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        
    }
}