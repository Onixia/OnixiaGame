using Onixia.Data.Migrations;

namespace Onixia.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class OnixiaDbContext : IdentityDbContext<User>
    {
        public OnixiaDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer<OnixiaDbContext>(new MigrateDatabaseToLatestVersion<OnixiaDbContext,OnixiaDbMigrationConfig>());
        }

        public static OnixiaDbContext Create()
        {
            return new OnixiaDbContext();
        }

        public IDbSet<Asteroid> Asteroids { get; set; }

        public IDbSet<Building> Buildings { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<Ship> Ships { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}