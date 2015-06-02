namespace Onixia.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<User> ignoredUsers;
        public User()
        {
            this.ignoredUsers = new HashSet<User>();
        }

        public double? Points                { get; set; }

        public double? WarPoints             { get; set; }

        public int? Credits                  { get; set; }

        public int Rank                      { get; set; }

        public virtual ICollection<User> IgnoredUsers 
        {
            get { return this.ignoredUsers; }
            set { this.ignoredUsers = value; }
        }

        public DateTime RegistrationDate     { get; set; }

        public bool IsActive                 { get; set; }

        public bool IsResearching            { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}