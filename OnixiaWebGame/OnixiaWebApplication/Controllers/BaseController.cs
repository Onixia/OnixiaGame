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
            refreshResources();
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

        protected void refreshResources()
        {
            if (this.UserProfile != null)
            {
                var buildings = this.Data.Buildings.All();
                var userPlanet = this.UserProfile.Planets.FirstOrDefault();

                var currentTime = DateTime.Now;

                //if (userPlanet.LastUpdatedOn <= currentTime.AddMinutes(-1))
                //{
                var metalMineLevel = userPlanet.Buildings.FirstOrDefault(b => b.Building.BuildingType == BuildingType.Metal).BuildingLevel;
                var crystalMineLevel = userPlanet.Buildings.FirstOrDefault(b => b.Building.BuildingType == BuildingType.Crystal).BuildingLevel;
                var gasMineLevel = userPlanet.Buildings.FirstOrDefault(b => b.Building.BuildingType == BuildingType.Gas).BuildingLevel;
                var solarPanelsLevel = userPlanet.Buildings.FirstOrDefault(b => b.Building.BuildingType == BuildingType.SolarPanels).BuildingLevel;

                var metalIncome = metalMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Metal).Income.Metal;
                var crystalIncome = metalMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Metal).Income.Metal;
                var gasIncome = metalMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Metal).Income.Metal;
                var energyIncome = metalMineLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Metal).Income.Metal;

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