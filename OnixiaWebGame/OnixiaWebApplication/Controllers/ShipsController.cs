﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onixia.Data.Contracts;
using Onixia.Models.PlayerAssets;
using OnixiaWebApplication.Models;

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
            var ships = this.Data.Ships.All();
            var userPlanet = this.UserProfile.Planets.FirstOrDefault();
            var userShips = userPlanet.Ships;
            var buildingsList = new List<ShipsModel>();

            foreach (var ship in ships)
            {
                bool isValid = true;
                var wantedShip = userShips.FirstOrDefault(s => s.Ship.Id == ship.Id);
                int shipsCount = 0;
                if (wantedShip != null)
                {
                    shipsCount = wantedShip.ShipCount;
                }

                var currentBuildList = userPlanet.CurrentOrder;


                //foreach (var requirement in ship.BuildingRequirements)
                //{
                //    var currentWantedUserBuilding = userBuildings.FirstOrDefault(ub => ub.Building.Id == requirement.Id);
                //    if (currentWantedUserBuilding == null
                //        || requirement.BuildingLevel > currentWantedUserBuilding.BuildingLevel
                //        || !userPlanet.PlanetResourceses.HasEnoughFor(requirement.RequiredBuilding.ResourceRequirements)
                //        || isBuilding)
                //    {
                //        isValid = false;
                //    }

                //}

                //int currentLevel = 0;

                //if (userBuildings.Any())
                //{
                //    var buildingLevel = userBuildings.FirstOrDefault(b => b.Id == ship.Id).BuildingLevel;

                //    currentLevel = (buildingLevel == null ? 0 : buildingLevel);
                //}

                //ShipsModel newShip = new ShipsModel()
                //{
                //    Name = "",
                //};
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