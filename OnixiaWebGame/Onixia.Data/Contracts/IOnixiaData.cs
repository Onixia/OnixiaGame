namespace Onixia.Models.Contracts
{
    using Models;
    using Models.ObjectTemplates;
    using Models.PlayerAssets;
    using Models.Requirements;

    public interface IOnixiaData
    {
        IRepository<User> Users { get; }

            
        IRepository<Planet> Planets { get; }

        IRepository<ShipTemplate> ShipsTemplates { get; }

        IRepository<Asteroid> Asteroids { get; }

        IRepository<BuildingTemplate> BuildingsTemplates { get; }

        IRepository<BuildingRequirement> BuildingRequirements { get; }

        IRepository<ShipRequirement> ShipRequirements { get; }

        IRepository<PlanetBuilding> PlanetBuildings { get; } 

        int SaveChanges();
    }
}