

namespace OnixiaWebApplication.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using OnixiaWebApplication.Models;
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
            var ships         = this.Data.Ships.All();
            var userPlanet    = this.UserProfile.Planets.FirstOrDefault();
            var userShips     = userPlanet.Ships;
            var shipsList     = new List<ShipsModel>();

            foreach (var ship in ships)
            {
                bool canBuild     = true;
                bool isBuilding   = false;
                int shipsCount    = 0;
                int buildingCount = 0;

                var wantedShip       = userShips.FirstOrDefault(s => s.Ship.Id == ship.Id);
                var currentBuildList = userPlanet.CurrentOrder;
                var userBuildings    = userPlanet.Buildings;
                var userTechnologies = userPlanet.User.Technologies;

                if (wantedShip != null)
                {
                    shipsCount = wantedShip.ShipCount;
                }
                
                if (currentBuildList.Ships.Any(s => s.ShipId == ship.Id))
                {
                    isBuilding = true;
                    buildingCount = currentBuildList.Ships.First(s => s.ShipId == ship.Id).ShipCount;
                }

                foreach (var requirement in ship.BuildingRequirements)
                {
                    var currentWantedUserBuilding = userBuildings.FirstOrDefault(ub => ub.Building.Id == requirement.Id);
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
                        var currentWantedUserTechnology = userTechnologies.FirstOrDefault(ut => ut.Id == requirement.Technology.Id);
                        if (currentWantedUserTechnology == null)
                        {
                            canBuild= false;
                        }

                    }     
                }
                
                ShipsModel newShip = new ShipsModel()
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
                    CanBuild = canBuild
                };

                shipsList.Add(newShip);
            }
            return View();
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
    }
}