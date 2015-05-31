using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onixia.Data.Migrations
{
    class OnixiaDbMigrationConfig : DbMigrationsConfiguration<OnixiaDbContext>
    {
        public OnixiaDbMigrationConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
