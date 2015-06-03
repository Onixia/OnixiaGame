namespace Onixia.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models.ObjectTemplates;
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
                new Ship { Name}
            }
        }

//        INSERT INTO `ships` (`id`, `name`, `strength`, `structure`, `weapon`, `armor`, `speed`, `consumation`, `engine`, `cargo`, `metal`, `crystal`, `gas`, `time_need`, `class`, `b_requirements`, `s_requirements`) VALUES
//(1, 'scout', 350, 4000, 'laser', 'light', 0, 100, '', 50, 3000, 1000, 0, 300, 1, '', ''),
//(2, 'fighter', 900, 10000, 'plasma', 'light', 0, 200, '', 300, 6000, 4000, 0, 480, 1, '', ''),
//(3, 'guardian', 2500, 27000, 'ion', 'medium', 0, 300, '', 800, 20000, 7000, 0, 1800, 1, '', ''),
//(4, 'battleship', 6000, 60000, 'plasma', 'medium', 0, 800, '', 1500, 40000, 20000, 0, 3600, 1, '', ''),
//(5, 'bomber', 7000, 85000, 'laser', 'heavy', 0, 700, '', 500, 50000, 25000, 10000, 5400, 1, '', ''),
//(6, 'destroyer', 12500, 125000, 'plasma', 'heavy', 0, 1000, '', 2000, 60000, 50000, 15000, 7200, 1, '', ''),
//(7, 'spy_probe', 1, 1000, 'laser', 'light', 0, 1, '', 1, 0, 1000, 0, 60, 2, '', ''),
//(8, 'colonizer', 400, 30000, 'laser', 'heavy', 0, 1000, '', 7500, 10000, 20000, 1000, 5400, 2, '', ''),
//(9, 'raptor', 500, 0, 'ion', 'medium', 0, 0, '', 0, 0, 0, 0, 2400, 2, '', ''),
//(10, 'recycler', 5, 20000, 'laser', 'medium', 0, 100, '', 20000, 10000, 8000, 2000, 3000, 2, '', ''),
//(11, 'transporter', 5, 4000, 'laser', 'light', 0, 50, '', 5000, 2000, 2000, 0, 600, 2, '', ''),
//(12, 'tanker', 5, 12000, 'laser', 'heavy', 0, 200, '', 15000, 6000, 6000, 0, 1800, 2, '', ''),
//(13, 'solar_station', 0, 3000, '', 'light', 0, 0, '', 0, 1000, 2000, 1000, 600, 2, '', '');

        private void CreateBuildings(OnixiaDbContext context)
        {
            var buildings = new List<Building>
            {
                new Building {Name = "Metal Mine", Description = "Main source for extraction of metal", MaxLevel = 30},
                new Building {Name = "Crystal Mine", Description = "Main source for extracting crystals", MaxLevel = 30},
                new Building {Name = "Gas Mine", Description = "Main source for extracting gas", MaxLevel = 30},
                new Building
                {
                    Name = "Solar Panel",
                    Description = "Converts solar rays into energy suitable for your needs",
                    MaxLevel = 30
                },
                new Building {Name = "Robot Factory", MaxLevel = 14},
                new Building
                {
                    Name = "Science Facility",
                    Description = "Facility where your scientiests invent and develop new technologies",
                    MaxLevel = 15
                },
                new Building
                {
                    Name = "Spaceport",
                    Description = "Here you can build new spaceships, shuttles and satellites",
                    MaxLevel = 15,
                    BuildingRequirements = new List<BuildingRequirement>
                    {
                        new BuildingRequirement {BuildingLevel = 2, RequiredBuildingId = 5}
                    }
                },
                new Building
                {
                    Name = "Trade Center",
                    Description = "Inter-planet trade hub for trading with all foreign merchants",
                    MaxLevel = 10
                },
                new Building
                {
                    Name = "Metal Warehouse",
                    Description = "Provides additional highly secured depot for storing your extracted metal",
                    MaxLevel = 20
                },
                new Building
                {
                    Name = "Crystal Warehouse",
                    Description = "Provides additional highly secured depot for storing your extracted crystals",
                    MaxLevel = 20
                },
                new Building
                {
                    Name = "Gas Tank",
                    Description = "Provides additional highly secured depot for storing your extracted gas",
                    MaxLevel = 20
                }
            };

            buildings.ForEach(b => context.Buildings.Add(b));
            context.SaveChanges();
        }
    }
}