namespace OnixiaWebApplication.Controllers
{
    using System;
    using System.Web.Mvc;

    using Models;
    using Onixia.Data.Contracts;
    using Onixia.Models;
    using Onixia.Models.PlayerAssets;

    public class PlanetController : BaseController
    {
        public PlanetController(IOnixiaData data)
            : base(data)
        {
        }

        // GET: Planet
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanetPostModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(postModel);
            }

            var planet = GeneratePlanet(postModel.Name);
            this.Data.Planets.Add(planet);
            this.UserProfile.Planets.Add(planet);
            this.Data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private Planet GeneratePlanet(string name)
        {
            var planet = new Planet();
            planet.UserId = this.UserProfile.Id;
            planet.PlanetResourceses = new ResourceBank(500, 500, 50, 10);
            planet.Name = name;
            planet.IsBuilding = false;
            planet.IsMainPlanet = true;
            planet.LastUpdatedOn = DateTime.Now;
            return planet;
        }
    }
}