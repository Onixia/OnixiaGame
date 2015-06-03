namespace Onixia.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Contracts;

    using Models;
    using Models.ObjectTemplates;
    using Models.PlayerAssets;
    using Models.Requirements;

    using Repositories;

    public class OnixiaData : IOnixiaData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public OnixiaData()
            : this(new OnixiaDbContext())
        {
        }

        public OnixiaData(OnixiaDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Planet> Planets
        {
            get { return this.GetRepository<Planet>(); }
        }

        public IRepository<ShipTemplate> ShipsTemplates
        {
            get { return this.GetRepository<ShipTemplate>(); }
        }

        public IRepository<Asteroid> Asteroids
        {
            get { return this.GetRepository<Asteroid>(); }
        }

        public IRepository<BuildingTemplate> BuildingsTemplates
        {
            get { return this.GetRepository<BuildingTemplate>(); }
        }

        public IRepository<BuildingRequirement> BuildingRequirements
        {
            get { return this.GetRepository<BuildingRequirement>(); }
        }

        public IRepository<ShipRequirement> ShipRequirements
        {
            get { return this.GetRepository<ShipRequirement>(); }
        }

        public IRepository<Quest> Quests
        {
            get { return this.GetRepository<Quest>(); }
        }

        public IRepository<PlanetBuilding> PlanetBuildings
        {
            get { return this.GetRepository<PlanetBuilding>(); }
        }

        IRepository<User> IOnixiaData.Users
        {
            get { return this.GetRepository<User>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepo = typeof(GenericRepository<T>);
                //if (type.IsAssignableFrom(typeof(ApplicationUser)))
                //{
                //    typeOfRepo = typeof(UsersRepository);
                //}

                var repo = Activator.CreateInstance(typeOfRepo, this.context);
                this.repositories.Add(type, repo);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}