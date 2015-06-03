namespace OnixiaWebApplication.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Microsoft.AspNet.Identity;

    using Onixia.Data.Contracts;
    using Onixia.Models;

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

            return base.BeginExecute(requestContext, callback, state);
        }

        protected IOnixiaData Data { get; set; }
    }
}