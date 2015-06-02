using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Onixia.Data.Contracts;
using Onixia.Models;
using OnixiaWebApplication.Models;

namespace OnixiaWebApplication.Controllers
{
    public class BuildingsController : BaseController
    {
        public BuildingsController(IOnixiaData data)
            : base(data)
        {
        }



        // GET: Buildings
        public ActionResult Index()
        {
            
            var buildings     = this.Data.Buildings.All();
            var userPlanet    = this.UserProfile.Planets.FirstOrDefault();
            var userBuildings = userPlanet.Buildings;
            var buildingsList = new List<BuildingViewModel>();

            foreach (var building in buildings)
            {
                bool isValid       = true;
                bool isBuilding    = false;
                var wantedBuilding = userBuildings.FirstOrDefault(ub => ub.Id == building.Id);
                TimeSpan elapsedTime = new TimeSpan();
                if (wantedBuilding != null)
                {
                    elapsedTime = DateTime.Now - wantedBuilding.StartedOn;
                    if (elapsedTime < wantedBuilding.Building.BuildTime)
                    {
                        isBuilding = true;
                    }
                }

                foreach (var requirement in building.BuildingRequirements)
                {
                    var currentWantedUserBuilding = userBuildings.FirstOrDefault(ub => ub.Building.Id == requirement.Id);
                    if (currentWantedUserBuilding == null
                        || requirement.BuildingLevel > currentWantedUserBuilding.BuildingLevel
                        || !userPlanet.PlanetResourceses.HasEnoughFor(requirement.RequiredBuilding.ResourceRequirements)
                        || isBuilding)
                    {
                        isValid = false;
                    }
                    
                }

                int currentLevel = 0;

                if (userBuildings.Any())
                {
                    var buildingLevel = userBuildings.FirstOrDefault(b => b.Id == building.Id).BuildingLevel;

                    currentLevel = (buildingLevel == null ? 0 : buildingLevel);
                }

                BuildingViewModel newBuilding = new BuildingViewModel()
                {
                    Name = building.Name,
                    Description = building.Description,
                    BuildingRequirements = building.BuildingRequirements,
                    CurrentLevel = currentLevel,
                    IsBuildable = isValid,
                    IsBuilding = isBuilding,
                    TimeLeft = building.BuildTime - elapsedTime,
                    ResourceRequirements = building.ResourceRequirements

                };


                buildingsList.Add(newBuilding);
            }
            return View(new CombinedBuildingsViewModel(buildingsList));
        }

        

        
    }
}