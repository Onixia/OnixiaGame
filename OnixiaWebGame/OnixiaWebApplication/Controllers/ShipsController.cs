namespace OnixiaWebApplication.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Models;

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
            var ships = this.Data.ShipsTemplates.All();
            var userPlanet = this.UserProfile.Planets.FirstOrDefault();
            var userShips = userPlanet.Ships;
            var shipsList = new List<ShipViewModel>();

            foreach (var ship in ships)
            {
                bool canBuild = true;
                bool isBuilding = false;
                int shipsCount = 0;
                int buildingCount = 0;

                var wantedShip = userShips.FirstOrDefault(s => s.Ship.Id == ship.Id);
                var currentBuildList = userPlanet.CurrentOrder;
                var userBuildings = userPlanet.PlanetBuildings;
                var userTechnologies = userPlanet.User.Technologies;

                if (wantedShip != null)
                {
                    shipsCount = wantedShip.ShipCount;
                }

                if (currentBuildList != null)
                {
                    if (currentBuildList.Ships.Any(s => s.ShipId == ship.Id))
                    {
                        isBuilding = true;
                        buildingCount = currentBuildList.Ships.First(s => s.ShipId == ship.Id).ShipCount;
                    }
                }

                foreach (var requirement in ship.BuildingRequirements)
                {
                    var currentWantedUserBuilding = userBuildings.FirstOrDefault(ub => ub.BuildingTemplate.Id == requirement.Id);
                    if (currentWantedUserBuilding == null
                        || requirement.BuildingLevel > currentWantedUserBuilding.BuildingLevel
                        || !userPlanet.PlanetResourceses.HasEnoughFor(ship.ShipCost)
                        || isBuilding)
                    {
                        canBuild = false;
                    }
                }
                if (canBuild)
                {
                    foreach (var requirement in ship.TechnologyRequirements)
                    {
                        var currentWantedUserTechnology =
                            userTechnologies.FirstOrDefault(ut => ut.Id == requirement.Technology.Id);
                        if (currentWantedUserTechnology == null)
                        {
                            canBuild = false;
                        }
                    }
                }

                ShipViewModel newShip = new ShipViewModel
                {
                    Name = ship.Name,
                    ArmorType = ship.ArmorType,
                    Description = ship.Description,
                    AvailableAmount = shipsCount,
                    BuildTime = ship.BuildTime,
                    Damage = ship.Damage,
                    GasConsumption = ship.GasConsumption,
                    IsBuilding = isBuilding,
                    IsBuilt = shipsCount > 0,
                    Shield = ship.Shield,
                    WeaponType = ship.WeaponType,
                    InProduction = buildingCount,
                    CanBuild = canBuild,
                    ShipCost = ship.ShipCost
                };

                shipsList.Add(newShip);
            }

            this.ViewBag.Resources = this.Data.Users.GetResources(this.UserProfile, this.UserProfile.Id);

            return View(new ShipsModel(){Ships = shipsList});
        }

        //[HttpPost]
        //public ActionResult OrderShips(ShipsModel model)
        //{

        //}

        //[Authorize]
        //[HttpPost]
        //public ActionResult CreateShip()
        //{

        //}
        public ActionResult Create()
        {
            throw new System.NotImplementedException();
        }
    }
}