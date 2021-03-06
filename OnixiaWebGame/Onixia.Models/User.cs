﻿namespace Onixia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using ObjectTemplates;

    using PlayerAssets;

    public class User : IdentityUser
    {
        private ICollection<User> ignoredUsers;

        public User()
        {
            this.ignoredUsers = new HashSet<User>();
            this.Planets = new HashSet<Planet>();
            this.RegistrationDate = DateTime.Now;
        }

        public double? Points { get; set; }

        public double? WarPoints { get; set; }

        public int? Credits { get; set; }

        public int Rank { get; set; }

        public virtual ICollection<User> IgnoredUsers
        {
            get { return this.ignoredUsers; }
            set { this.ignoredUsers = value; }
        }

        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsResearching { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<PlanetBuilding> GetPlanetBuildings()
        {
            return this.Planets.FirstOrDefault().PlanetBuildings;
        }
    }
}