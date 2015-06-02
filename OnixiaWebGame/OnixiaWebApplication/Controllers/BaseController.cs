using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Onixia.Data.Contracts;
using Onixia.Data.UnitOfWork;
using Onixia.Models;

namespace OnixiaWebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(IOnixiaData data, User userProfile) 
            :this(data)
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

        public IOnixiaData Data { get; set; }

    }
}