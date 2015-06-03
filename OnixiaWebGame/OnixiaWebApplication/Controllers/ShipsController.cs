namespace OnixiaWebApplication.Controllers
{
    using System.Web.Mvc;

    using Onixia.Data.Contracts;

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