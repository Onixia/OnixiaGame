namespace Onixia.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.ObjectTemplates;
    using Models.PlayerAssets;
    using Models.Requirements;

    public class OnixiaDbMigrationConfig : DbMigrationsConfiguration<OnixiaDbContext>
    {
        public OnixiaDbMigrationConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnixiaDbContext context)
        {
            if (!context.Buildings.Any())
            {
                this.CreateBuildings(context);
            }

            if (!context.Ships.Any())
            {
                this.CreateShips(context);
            }
        }

        private void CreateShips(OnixiaDbContext context)
        {
            var ships = new List<ShipTemplate>
            {
                new ShipTemplate
                {
                    Name = "Scout",
                    ArmorType = ArmorType.Light,
                    WeaponType = WeaponType.Laser,
                    Speed = 20,
                    Shield = 4000,
                    GasConsumption = 100,
                    Damage = 350,
                    BuildTime = new TimeSpan(0, 5, 0),
                    ShipCost = new ResourceBank(3000, 1000, 0)
                },
                new ShipTemplate
                {
                    Name = "Fighter",
                    Damage = 900,
                    Shield = 10000,
                    WeaponType = WeaponType.Plasma,
                    ArmorType = ArmorType.Light,
                    Speed = 20,
                    GasConsumption = 200,
                    ShipCost = new ResourceBank(6000, 4000, 0),
                    BuildTime = new TimeSpan(0, 8, 0)
                },
                new ShipTemplate
                {
                    Name = "Guardian",
                    Damage = 2500,
                    Shield = 27000,
                    WeaponType = WeaponType.Ion,
                    ArmorType = ArmorType.Medium,
                    Speed = 20,
                    GasConsumption = 300,
                    ShipCost = new ResourceBank(20000, 7000, 0),
                    BuildTime = new TimeSpan(0, 30, 0)
                },
                new ShipTemplate
                {
                    Name = "Battleship",
                    Damage = 6000,
                    Shield = 60000,
                    WeaponType = WeaponType.Plasma,
                    ArmorType = ArmorType.Medium,
                    Speed = 20,
                    GasConsumption = 800,
                    ShipCost = new ResourceBank(40000, 20000, 0),
                    BuildTime = new TimeSpan(1, 0, 0)
                },
                new ShipTemplate
                {
                    Name = "Bomber",
                    Damage = 7000,
                    Shield = 85000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Heavy,
                    Speed = 20,
                    GasConsumption = 700,
                    ShipCost = new ResourceBank(50000, 25000, 10000),
                    BuildTime = new TimeSpan(1, 30, 0)
                },
                new ShipTemplate
                {
                    Name = "Destroyer",
                    Damage = 12500,
                    Shield = 125000,
                    WeaponType = WeaponType.Plasma,
                    ArmorType = ArmorType.Heavy,
                    Speed = 20,
                    GasConsumption = 1000,
                    ShipCost = new ResourceBank(60000, 50000, 15000),
                    BuildTime = new TimeSpan(2, 0, 0)
                },
                new ShipTemplate
                {
                    Name = "Spy Probe",
                    Damage = 1,
                    Shield = 1000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Light,
                    Speed = 20,
                    GasConsumption = 1,
                    ShipCost = new ResourceBank(1000, 0, 60),
                    BuildTime = new TimeSpan(0, 1, 0)
                },
                new ShipTemplate
                {
                    Name = "Colonizer",
                    Damage = 400,
                    Shield = 30000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Heavy,
                    Speed = 20,
                    GasConsumption = 1000,
                    ShipCost = new ResourceBank(10000, 20000, 1000),
                    BuildTime = new TimeSpan(1, 30, 0)
                },
                new ShipTemplate
                {
                    Name = "Raptor",
                    Damage = 500,
                    Shield = 0,
                    WeaponType = WeaponType.Ion,
                    ArmorType = ArmorType.Medium,
                    Speed = 20,
                    GasConsumption = 0,
                    ShipCost = new ResourceBank(),
                    BuildTime = new TimeSpan(0, 40, 0)
                },
                new ShipTemplate
                {
                    Name = "Recycler",
                    Damage = 5,
                    Shield = 20000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Medium,
                    Speed = 20,
                    GasConsumption = 100,
                    ShipCost = new ResourceBank(10000, 8000, 2000),
                    BuildTime = new TimeSpan(0, 50, 0)
                },
                new ShipTemplate
                {
                    Name = "Transporter",
                    Damage = 5,
                    Shield = 4000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Light,
                    Speed = 20,
                    GasConsumption = 50,
                    ShipCost = new ResourceBank(2000, 2000, 0),
                    BuildTime = new TimeSpan(0, 10, 0)
                },
                new ShipTemplate
                {
                    Name = "Tanker",
                    Damage = 5,
                    Shield = 12000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Heavy,
                    Speed = 20,
                    GasConsumption = 200,
                    ShipCost = new ResourceBank(6000, 6000, 0),
                    BuildTime = new TimeSpan(0, 30, 0)
                }
            };

            ships.ForEach(s => context.Ships.Add(s));
            context.SaveChanges();
        }

        private void CreateBuildings(OnixiaDbContext context)
        {
            this.CreateUserRoles(context);

            var buildings = new List<BuildingTemplate>
            {
                new BuildingTemplate
                {
                    Name = "Metal Mine",
                    Description = "Main source for extraction of metal",
                    MaxLevel = 30,
                    BuildingType = BuildingType.Metal,
                    Income = 500,
                    BuildTime = new TimeSpan(0, 0, 10),
                    ResourceRequirements = new ResourceBank(60, 15, 0, 11)
                },
                new BuildingTemplate
                {
                    Name = "Crystal Mine",
                    Description = "Main source for extracting crystals",
                    MaxLevel = 30,
                    BuildingType = BuildingType.Crystal,
                    Income = 500,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(48, 24, 0, 11)
                },
                new BuildingTemplate
                {
                    Name = "Gas Mine",
                    Description = "Main source for extracting gas",
                    MaxLevel = 30,
                    BuildingType = BuildingType.Gas,
                    Income = 500,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(225, 75, 0, 22)
                },
                new BuildingTemplate
                {
                    Name = "Solar Panel",
                    Description = "Converts solar rays into energy suitable for your needs",
                    MaxLevel = 30,
                    BuildingType = BuildingType.SolarPanels,
                    Income = 500,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(75, 30, 0, 0)
                },
                new BuildingTemplate
                {
                    Name = "Robot Factory",
                    Description = "Robot Factory",
                    MaxLevel = 14,
                    BuildingType = BuildingType.Other,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(400, 120, 200, 0)
                },
                new BuildingTemplate
                {
                    Name = "Science Facility",
                    Description = "Facility where your scientiests invent and develop new technologies",
                    MaxLevel = 15,
                    BuildingType = BuildingType.ScienceFacility,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(200, 400, 200, 0)
                },
                new BuildingTemplate
                {
                    Name = "Spaceport",
                    Description = "Here you can build new spaceships, shuttles and satellites",
                    MaxLevel = 15,
                    BuildingRequirements = new List<BuildingRequirement>
                    {
                        new BuildingRequirement {BuildingLevel = 2, RequiredBuildingId = 5}
                    },
                    BuildingType = BuildingType.Spaceport,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(400, 200, 100, 0)
                },
                new BuildingTemplate
                {
                    Name = "Trade Center",
                    Description = "Inter-planet trade hub for trading with all foreign merchants",
                    MaxLevel = 10,
                    BuildingType = BuildingType.TradeCenter,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(3000, 2000, 1000, 0)
                },
                new BuildingTemplate
                {
                    Name = "Metal Warehouse",
                    Description = "Provides additional highly secured depot for storing your extracted metal",
                    MaxLevel = 20,
                    BuildingType = BuildingType.MetalWarehouse,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(2000, 0, 0, 0)
                },
                new BuildingTemplate
                {
                    Name = "Crystal Warehouse",
                    Description = "Provides additional highly secured depot for storing your extracted crystals",
                    MaxLevel = 20,
                    BuildingType = BuildingType.CrystalWareHouse,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(1500, 500, 0, 0)
                },
                new BuildingTemplate
                {
                    Name = "Gas Tank",
                    Description = "Provides additional highly secured depot for storing your extracted gas",
                    MaxLevel = 20,
                    BuildingType = BuildingType.GasTank,
                    BuildTime = new TimeSpan(0, 1, 0),
                    ResourceRequirements = new ResourceBank(1500, 250, 250, 0)
                }
            };

            try
            {
                buildings.ForEach(b => context.Buildings.Add(b));
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
        }

        private void CreateUserRoles(OnixiaDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            //roleManager.Create(new IdentityRole { Name = "Administrator" });
            //roleManager.Create(new IdentityRole { Name = "Normal" });

            var adminRole = new IdentityRole { Name = "Administrator", Id = Guid.NewGuid().ToString() };
            var userRole = new IdentityRole { Name = "Normal", Id = Guid.NewGuid().ToString() };
            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);

            context.SaveChanges();
        }
    }
}