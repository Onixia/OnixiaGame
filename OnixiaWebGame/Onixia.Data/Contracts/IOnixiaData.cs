namespace Onixia.Data.Contracts
{
    using Models;
    using Models.ObjectTemplates;
    using Models.PlayerAssets;
    using Models.Requirements;

    public interface IOnixiaData
    {
        IRepository<User> Users { get; }

            
        IRepository<Planet> Planets { get; }

        IRepository<Ship> Ships { get; }

        IRepository<Asteroid> Asteroids { get; }

        IRepository<Building> Buildings { get; }

        IRepository<BuildingRequirement> BuildingRequirements { get; }

        IRepository<ShipRequirement> ShipRequirements { get; }

        int SaveChanges();
    }
}