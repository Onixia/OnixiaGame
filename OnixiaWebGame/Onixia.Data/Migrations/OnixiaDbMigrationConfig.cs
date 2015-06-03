namespace Onixia.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            var ships = new List<Ship>
            {
                new Ship
                {
                    Name = "Scout",
                    ArmorType = ArmorType.Light,
                    WeaponType = WeaponType.Laser,
                    Speed = 0,
                    Shield = 4000,
                    GasConsumption = 100,
                    Damage = 350,
                    BuildTime = new TimeSpan(0, 0, 5),
                    ShipCost = new ResourceBank(3000, 1000, 0)
                },
                new Ship
                {
                    Name = "Fighter",
                    Damage = 900,
                    Shield = 10000,
                    WeaponType = WeaponType.Plasma,
                    ArmorType = ArmorType.Light,
                    Speed = 0,
                    GasConsumption = 200,
                    ShipCost = new ResourceBank(6000, 4000, 0),
                    BuildTime = new TimeSpan(0, 0, 8)
                },
                new Ship
                {
                    Name = "Guardian",
                    Damage = 2500,
                    Shield = 27000,
                    WeaponType = WeaponType.Ion,
                    ArmorType = ArmorType.Medium,
                    Speed = 0,
                    GasConsumption = 300,
                    ShipCost = new ResourceBank(20000, 7000, 0),
                    BuildTime = new TimeSpan(0, 0, 30)
                },
                new Ship
                {
                    Name = "Battleship",
                    Damage = 6000,
                    Shield = 60000,
                    WeaponType = WeaponType.Plasma,
                    ArmorType = ArmorType.Medium,
                    Speed = 0,
                    GasConsumption = 800,
                    ShipCost = new ResourceBank(40000, 20000, 0),
                    BuildTime = new TimeSpan(0, 1, 0)
                },
                new Ship
                {
                    Name = "Bomber",
                    Damage = 7000,
                    Shield = 85000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Heavy,
                    Speed = 0,
                    GasConsumption = 700,
                    ShipCost = new ResourceBank(50000, 25000, 10000),
                    BuildTime = new TimeSpan(0, 1, 30)
                },
                new Ship
                {
                    Name = "Destroyer",
                    Damage = 12500,
                    Shield = 125000,
                    WeaponType = WeaponType.Plasma,
                    ArmorType = ArmorType.Heavy,
                    Speed = 0,
                    GasConsumption = 1000,
                    ShipCost = new ResourceBank(60000, 50000, 15000),
                    BuildTime = new TimeSpan(0, 2, 0)
                },
                new Ship
                {
                    Name = "Spy Probe",
                    Damage = 1,
                    Shield = 1000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Light,
                    Speed = 0,
                    GasConsumption = 1,
                    ShipCost = new ResourceBank(1000, 0, 60),
                    BuildTime = new TimeSpan(0, 0, 1)
                },
                new Ship
                {
                    Name = "Colonizer",
                    Damage = 400,
                    Shield = 30000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Heavy,
                    Speed = 0,
                    GasConsumption = 1000,
                    ShipCost = new ResourceBank(10000, 20000, 1000),
                    BuildTime = new TimeSpan(0, 1, 30)
                },
                new Ship
                {
                    Name = "Raptor",
                    Damage = 500,
                    Shield = 0,
                    WeaponType = WeaponType.Ion,
                    ArmorType = ArmorType.Medium,
                    Speed = 0,
                    GasConsumption = 0,
                    ShipCost = new ResourceBank(),
                    BuildTime = new TimeSpan(0, 0, 40)
                },
                new Ship
                {
                    Name = "Recycler",
                    Damage = 5,
                    Shield = 20000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Medium,
                    Speed = 0,
                    GasConsumption = 100,
                    ShipCost = new ResourceBank(10000, 8000, 2000),
                    BuildTime = new TimeSpan(0, 0, 50)
                },
                new Ship
                {
                    Name = "Transporter",
                    Damage = 5,
                    Shield = 4000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Light,
                    Speed = 0,
                    GasConsumption = 50,
                    ShipCost = new ResourceBank(2000, 2000, 0),
                    BuildTime = new TimeSpan(0, 0, 10)
                },
                new Ship
                {
                    Name = "Tanker",
                    Damage = 5,
                    Shield = 12000,
                    WeaponType = WeaponType.Laser,
                    ArmorType = ArmorType.Heavy,
                    Speed = 0,
                    GasConsumption = 200,
                    ShipCost = new ResourceBank(6000, 6000, 0),
                    BuildTime = new TimeSpan(0, 0, 30)
                }
            };

            ships.ForEach(s => context.Ships.Add(s));
            context.SaveChanges();
        }

        private void CreateBuildings(OnixiaDbContext context)
        {
            var buildings = new List<Building>
            {
                new Building {Name = "Metal Mine", Description = "Main source for extraction of metal", MaxLevel = 30, BuildingType = BuildingType.Metal },
                new Building {Name = "Crystal Mine", Description = "Main source for extracting crystals", MaxLevel = 30, BuildingType = BuildingType.Crystal },
                new Building {Name = "Gas Mine", Description = "Main source for extracting gas", MaxLevel = 30, BuildingType = BuildingType.Gas },
                new Building
                {
                    Name = "Solar Panel",
                    Description = "Converts solar rays into energy suitable for your needs",
                    MaxLevel = 30,
                    BuildingType = BuildingType.SolarPanels
                },
                new Building {Name = "Robot Factory", MaxLevel = 14},
                new Building
                {
                    Name = "Science Facility",
                    Description = "Facility where your scientiests invent and develop new technologies",
                    MaxLevel = 15,
                    BuildingType = BuildingType.ScienceFacility
                },
                new Building
                {
                    Name = "Spaceport",
                    Description = "Here you can build new spaceships, shuttles and satellites",
                    MaxLevel = 15,
                    BuildingRequirements = new List<BuildingRequirement>
                    {
                        new BuildingRequirement {BuildingLevel = 2, RequiredBuildingId = 5}
                    },
                    BuildingType = BuildingType.Spaceport
                },
                new Building
                {
                    Name = "Trade Center",
                    Description = "Inter-planet trade hub for trading with all foreign merchants",
                    MaxLevel = 10,
                    BuildingType = BuildingType.TradeCenter
                },
                new Building
                {
                    Name = "Metal Warehouse",
                    Description = "Provides additional highly secured depot for storing your extracted metal",
                    MaxLevel = 20,
                    BuildingType = BuildingType.MetalWarehouse
                },
                new Building
                {
                    Name = "Crystal Warehouse",
                    Description = "Provides additional highly secured depot for storing your extracted crystals",
                    MaxLevel = 20,
                    BuildingType = BuildingType.CrystalWareHouse
                },
                new Building
                {
                    Name = "Gas Tank",
                    Description = "Provides additional highly secured depot for storing your extracted gas",
                    MaxLevel = 20,
                    BuildingType = BuildingType.GasTank
                }
            };

            buildings.ForEach(b => context.Buildings.Add(b));
            context.SaveChanges();
        }
    }
}