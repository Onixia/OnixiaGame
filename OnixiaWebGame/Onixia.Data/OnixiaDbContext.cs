
﻿namespace Onixia.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;

    using Models;

    using Onixia.Data.Migrations;
    using Onixia.Models.ObjectTemplates;
    using Models.ObjectTemplates;
    using Models.PlayerAssets;
    using Models.Requirements;

    public class OnixiaDbContext : IdentityDbContext<User>
    {
        public OnixiaDbContext()
            : base("OnixiaGame", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnixiaDbContext, OnixiaDbMigrationConfig>());
        }

        public static OnixiaDbContext Create()
        {
            return new OnixiaDbContext();
        }

        public IDbSet<Asteroid> Asteroids { get; set; }

        public IDbSet<Building> Buildings { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<Quest> Quests { get; set; }

        public IDbSet<Ship> Ships { get; set; }

        public IDbSet<BuildingRequirement> BuildingRequirements { get; set; }

        public IDbSet<ShipRequirement> ShipRequirements { get; set; }
        
        public IDbSet<PlayerQuest> PlayerMissions { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}