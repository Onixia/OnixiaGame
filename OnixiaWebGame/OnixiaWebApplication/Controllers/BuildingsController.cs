namespace OnixiaWebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Models;

    using Onixia.Data.Contracts;
    using Onixia.Models.PlayerAssets;

    public class BuildingsController : BaseController
    {
        public BuildingsController(IOnixiaData data)
            : base(data)
        {
        }


        // GET: Buildings
        public ActionResult Index()
        {
            var buildings = this.Data.BuildingsTemplates.All();
            var userPlanet = this.UserProfile.Planets.FirstOrDefault();
            var userBuildings = userPlanet.PlanetBuildings;
            var buildingsList = new List<BuildingViewModel>();

            foreach (var building in buildings)
            {
                bool isValid = true;
                bool isBuilding = false;
                var wantedBuilding = userBuildings.FirstOrDefault(ub => ub.Id == building.Id);
                TimeSpan elapsedTime = new TimeSpan();
                if (wantedBuilding != null)
                {
                    elapsedTime = DateTime.Now - wantedBuilding.StartedOn;
                    if (elapsedTime < wantedBuilding.BuildingTemplate.BuildTime)
                    {
                        isBuilding = true;
                    }
                }

                foreach (var requirement in building.BuildingRequirements)
                {
                    var currentWantedUserBuilding = userBuildings.FirstOrDefault(ub => ub.BuildingTemplate.Id == requirement.Id);
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
                    var buildingLevel = userBuildings.FirstOrDefault(b => b.Id == building.Id);

                    currentLevel = (buildingLevel == null ? 0 : buildingLevel.BuildingLevel);
                }

                BuildingViewModel newBuilding = new BuildingViewModel
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

        public ActionResult CreateBuilding(string name)
        {
            var buildingTemplate = this.Data.BuildingsTemplates.Find(b => b.Name == name).FirstOrDefault();
            if (buildingTemplate == null)
            {
                return HttpNotFound();
            }

            var userPlanetBuildings = this.UserProfile.GetPlanetBuildings();
            var userPlanet = this.UserProfile.Planets.FirstOrDefault();
            var newPlanetBuilding = new PlanetBuilding();

            var existingBuilding = userPlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.Id == buildingTemplate.Id);
            int playerBuildingLevel = 0;
            if (existingBuilding != null)
            {
                playerBuildingLevel = existingBuilding.BuildingLevel;

            }

            var neededResourses = new ResourceBank();
            neededResourses.Crystal = buildingTemplate.ResourceRequirements.Crystal * (playerBuildingLevel + 1);
            neededResourses.Metal = buildingTemplate.ResourceRequirements.Metal * (playerBuildingLevel + 1);
            neededResourses.Gas = buildingTemplate.ResourceRequirements.Gas * (playerBuildingLevel + 1);
            neededResourses.Energy = buildingTemplate.ResourceRequirements.Energy * (playerBuildingLevel + 1);

            if (userPlanet.PlanetResourceses.HasEnoughFor(neededResourses))
            {
                newPlanetBuilding.BuildingLevel = playerBuildingLevel;
                newPlanetBuilding.BuildingTemplateId = buildingTemplate.Id;
                newPlanetBuilding.StartedOn = DateTime.Now;
                newPlanetBuilding.PlanetId = userPlanet.Id;
                userPlanet.PlanetResourceses -= neededResourses;

                this.Data.PlanetBuildings.Add(newPlanetBuilding);
                this.Data.SaveChanges();
            }



            return RedirectToAction("Index");
        }
    }
}