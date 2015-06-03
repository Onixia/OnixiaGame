namespace Onixia.Data.Contracts
{
    using Onixia.Models.ObjectTemplates;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IOnixiaDbContext
    {
        IDbSet<User> Users { get; set; } 

        IDbSet<Asteroid> Asteroids { get; set; }

        IDbSet<BuildingTemplate> Buildings { get; set; }

        IDbSet<Planet> Planets { get; set; }

        IDbSet<ShipTemplate> Ships { get; set; } 

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}