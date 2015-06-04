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

            RefreshResources();

            return base.BeginExecute(requestContext, callback, state);
        }

        protected IOnixiaData Data { get; set; }

        protected void RefreshResources()
        {
            if (this.UserProfile != null)
            {
                var buildings = this.Data.BuildingsTemplates.All();
                var userPlanet = this.UserProfile.Planets.FirstOrDefault();

                if (userPlanet != null)
                {
                    var currentTime = DateTime.Now;

                    TimeSpan incomeTimeSpan = (TimeSpan)(DateTime.Now - userPlanet.LastUpdatedOn);

                    var metalMine = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.Metal);
                    var crystalMine = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.Crystal);
                    var gasMine = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.Gas);
                    var solarPanels = userPlanet.PlanetBuildings.FirstOrDefault(b => b.BuildingTemplate.BuildingType == BuildingType.SolarPanels);

                    if (metalMine != null)
                    {
                        var metalIncome = metalMine.BuildingLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Metal).Income;
                        userPlanet.PlanetResourceses.Metal += (int)(metalIncome * (double)(incomeTimeSpan.TotalSeconds / 60));
                    }

                    if (crystalMine != null)
                    {
                        var crystalIncome = crystalMine.BuildingLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Crystal).Income;
                        userPlanet.PlanetResourceses.Crystal += (int)(crystalIncome * (double)(incomeTimeSpan.TotalSeconds / 60));
                    }

                    if (gasMine != null)
                    {
                        var gasIncome = gasMine.BuildingLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.Gas).Income;
                        userPlanet.PlanetResourceses.Gas += (int)(gasIncome * (double)(incomeTimeSpan.TotalSeconds / 60));
                    }

                    if (solarPanels != null)
                    {
                        var energyIncome = solarPanels.BuildingLevel * buildings.FirstOrDefault(b => b.BuildingType == BuildingType.SolarPanels).Income;
                        userPlanet.PlanetResourceses.Energy += (int)(energyIncome * (double)(incomeTimeSpan.TotalSeconds / 60));
                    }

                    userPlanet.LastUpdatedOn = DateTime.Now;

                    this.Data.SaveChanges();
                }
            }
        }
    }
}