namespace Onixia.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;
    using Models.ObjectTemplates;

    public interface IOnixiaDbContext
    {
        IDbSet<User> Users { get; set; } 

        IDbSet<Asteroid> Asteroids { get; set; }

        IDbSet<Building> Buildings { get; set; }

        IDbSet<Planet> Planets { get; set; }

        IDbSet<Ship> Ships { get; set; } 

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}