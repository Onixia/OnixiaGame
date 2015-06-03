using System;
using Onixia.Models;
using Onixia.Models.ObjectTemplates;
using Onixia.Models.PlayerAssets;

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
                int canBuildShipsCount = 0;

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

                    ResourceBank rb = userPlanet.PlanetResourceses;
                    while (rb.HasEnoughFor(ship.ShipCost))
                    {
                        rb -= ship.ShipCost;
                        canBuildShipsCount += 1;
                        if (canBuildShipsCount >= 500)
                        {
                            break;
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
                    ShipCost = ship.ShipCost,
                    BuildableAmount = canBuildShipsCount
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
        public ActionResult Create(string name, int count)
        {
            count += 1;
            var WantedShip = Data.ShipsTemplates.Find(s => s.Name == name).FirstOrDefault();
            var userPlanet = UserProfile.Planets.FirstOrDefault();
            if (WantedShip != null && userPlanet != null)
            {
                ShipOrder shipOrder = new ShipOrder()
                {
                    BuildTimeLength = WantedShip.BuildTime,
                    Ships = new List<PlanetShip>()
                    {
                        new PlanetShip()
                        {
                            ShipId = WantedShip.Id,
                            ShipCount = count
                        }
                    },
                    TargetPlanetId = userPlanet.Id,
                    TimeCreated = DateTime.Now
                };
                return new HttpStatusCodeResult(200);
            }

            return new HttpNotFoundResult();
        }
    }
}