namespace OnixiaWebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Models;
    using Models.ViewModels;
    using Onixia.Models.Contracts;
    using Onixia.Models.PlayerAssets;

    using AutoMapper.QueryableExtensions;

    [Authorize]
    public class BuildingsController : BaseController
    {
        public BuildingsController(IOnixiaData data)
            : base(data)
        {
        }


        // GET: Buildings
        public ActionResult Index()
        {
            var buildings = this.Data.BuildingsTemplates.All().Project().To<BuildingViewModel>().ToList();
            var userPlanet = this.UserProfile.Planets.FirstOrDefault();
            var userBuildings = userPlanet.PlanetBuildings;
            var buildingsList = new List<BuildingViewModel>();

            foreach (var building in buildings)
            {
                bool isValid = true;
                bool isBuilding = false;
                var wantedBuilding = userBuildings.FirstOrDefault(ub => ub.BuildingTemplateId == building.Id);
                string errorString = "";
                TimeSpan elapsedTime = new TimeSpan();
                if (wantedBuilding != null && wantedBuilding.StartedOn != null)
                {
                    elapsedTime = DateTime.Now - (DateTime)wantedBuilding.StartedOn;
                    if (elapsedTime < wantedBuilding.BuildingTemplate.BuildTime)
                    {
                        isBuilding = true;
                    }
                }

                foreach (var requirement in building.BuildingRequirements)
                {
                    var currentWantedUserBuilding = userBuildings.FirstOrDefault(ub => ub.BuildingTemplate.Id == requirement.Id);
                    if (currentWantedUserBuilding == null
                        || requirement.BuildingLevel > currentWantedUserBuilding.BuildingLevel)
                    {
                        isValid = false;
                        errorString = "Does not have requirement " + requirement.RequiredBuilding.Name;
                    }
                }
                if (!userPlanet.PlanetResourceses.HasEnoughFor(building.ResourceRequirements)
                   || isBuilding)
                {
                    isValid = false;
                    errorString = "Not Enough Resources";
                }

                int currentLevel = 0;

                var existingUserBuilding = userBuildings.FirstOrDefault(b => b.BuildingTemplate.Id == building.Id);
                if (userBuildings.Any())
                {
                    var buildingLevel = userBuildings.FirstOrDefault(b => b.BuildingTemplate.Id == building.Id);
                    currentLevel = (buildingLevel == null ? 0 : buildingLevel.BuildingLevel);
                }

                var remainingTime = TimeSpan.FromSeconds(building.BuildTime.TotalSeconds*(currentLevel + 1));

                var newBuilding = building;
                newBuilding.CurrentLevel = currentLevel;
                newBuilding.IsBuildable = isValid;
                newBuilding.IsBuilding = isBuilding;
                //newBuilding.BuildingType = building.BuildingType.ToString() + ".jpg";
                newBuilding.TimeLeft = isBuilding ? (remainingTime - elapsedTime) : remainingTime;
                newBuilding.ResourceRequirements = existingUserBuilding == null
                    ? building.ResourceRequirements
                    : existingUserBuilding.CalculateCost();
                newBuilding.ErrorMessage = errorString;

                //{
                //    Name = building.Name,
                //    Description = building.Description,
                //    BuildingRequirements = building.BuildingRequirements,
                //    CurrentLevel = currentLevel,
                //    IsBuildable = isValid,
                //    IsBuilding = isBuilding,
                //    BuildingType = building.BuildingType.ToString() + ".jpg",
                //    TimeLeft = isBuilding ? (remainingTime - elapsedTime) : remainingTime,
                //    ResourceRequirements = existingUserBuilding == null? building.ResourceRequirements : existingUserBuilding.CalculateCost(),
                //    ErrorMessage = errorString
                //};


                buildingsList.Add(newBuilding);
            }

            this.CheckAndUpdateBuildingStatus();
            this.ViewBag.Resources = this.Data.Users.GetResources(this.UserProfile, this.UserProfile.Id);

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

            var existingBuilding = userPlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.Id == buildingTemplate.Id);

            bool newBuilding = false;

            if (existingBuilding == null)
            {
                newBuilding = true;
                existingBuilding = new PlanetBuilding()
                {
                    BuildingLevel = 0,
                    BuildingTemplate = buildingTemplate,
                    BuildingTemplateId = buildingTemplate.Id,
                    PlanetId = userPlanet.Id,
                    Planet = userPlanet,
                    StartedOn = DateTime.Now
                };
            }

            userPlanet.PlanetResourceses -= existingBuilding.CalculateCost();
            if (!userPlanet.PlanetResourceses.HasEnoughFor(existingBuilding.CalculateCost()))
            {
                return new HttpNotFoundResult();
            }
            else if (newBuilding)
            {
                this.Data.PlanetBuildings.Add(existingBuilding);
            }
            else
            {
                existingBuilding.StartedOn = DateTime.Now;
                this.Data.PlanetBuildings.Update(existingBuilding);
                this.Data.Planets.Update(userPlanet);
            }

            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CancelBuilding(string name)
        {
            var building = this.Data.PlanetBuildings.Find(b => b.BuildingTemplate.Name == name).FirstOrDefault();
            building.StartedOn = null;

            var userPlanet = this.UserProfile.Planets.FirstOrDefault();
            userPlanet.PlanetResourceses += building.BuildingTemplate.ResourceRequirements;

            this.Data.PlanetBuildings.Update(building);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        private void CheckAndUpdateBuildingStatus()
        {
            var userPlanetBuildings = this.UserProfile.Planets.FirstOrDefault().PlanetBuildings;

            foreach (var b in userPlanetBuildings)
            {
                if (DateTime.Now > b.StartedOn + b.BuildingTemplate.BuildTime)
                {
                    b.BuildingLevel ++;
                    b.StartedOn = null;
                    this.Data.SaveChanges();
                }
            }
            
        }
    }
}