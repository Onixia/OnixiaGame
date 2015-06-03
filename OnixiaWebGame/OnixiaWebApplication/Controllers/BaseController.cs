namespace OnixiaWebApplication.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Onixia.Data.Contracts;
    using Onixia.Models;
    using Onixia.Models.ObjectTemplates;

    public abstract class BaseController : Controller
    {
        protected BaseController(IOnixiaData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected BaseController(IOnixiaData data)
        {
            this.Data = data;
            RefreshResources();
        }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = requestContext.HttpContext.User.Identity.GetUserId();
                var user = this.Data.Users.GetById(userId);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }

        protected IOnixiaData Data { get; set; }

        protected void RefreshResources()
        {
            if (this.UserProfile != null)
            {
                var buildings = this.Data.BuildingsTemplates.All();
                var userPlanet = this.UserProfile.Planets.FirstOrDefault();

                var currentTime = DateTime.Now;

                //if (userPlanet.LastUpdatedOn <= currentTime.AddMinutes(-1))
                //{
                var metalMineLevel = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.Metal).BuildingLevel;
                var crystalMineLevel = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.Crystal).BuildingLevel;
                var gasMineLevel = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.Gas).BuildingLevel;
                var solarPanelsLevel = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.SolarPanels).BuildingLevel;

                var metalIncome = metalMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Metal).Income;
                var crystalIncome = crystalMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Crystal).Income;
                var gasIncome = gasMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Gas).Income;
                var energyIncome = solarPanelsLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.SolarPanels).Income;

                userPlanet.PlanetResourceses.Metal += metalIncome;
                userPlanet.PlanetResourceses.Crystal += crystalIncome;
                userPlanet.PlanetResourceses.Gas += gasIncome;
                userPlanet.PlanetResourceses.Energy += energyIncome;
                this.Data.SaveChanges();
                //}
            }
        }
    }
}