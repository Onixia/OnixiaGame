using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onixia.Models.ObjectTemplates;
using Onixia.Models.PlayerAssets;

namespace OnixiaWebApplication.Models
{
    public class ShipsModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ArmorType ArmorType { get; set; }

        public WeaponType WeaponType { get; set; }

        public float Shield { get; set; }

        public float Damage { get; set; }

        public ResourceBank ShipCost { get; set; }

        public float Speed { get; set; }

        public int GasConsumption { get; set; }

        public TimeSpan BuildTime { get; set; }

        public bool IsBuilt { get; set; }

        public bool IsBuilding { get; set; }

        public bool CanBuild { get; set; }

        public int InProduction { get; set; }

        public int AvailableAmount { get; set; }
    }
}