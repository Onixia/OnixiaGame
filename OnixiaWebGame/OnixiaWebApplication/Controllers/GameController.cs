namespace OnixiaWebApplication.Controllers
{
    using System.Web.Mvc;

    using Onixia.Data.Contracts;

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