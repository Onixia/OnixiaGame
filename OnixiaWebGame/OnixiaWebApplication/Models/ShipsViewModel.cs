using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onixia.Models.PlayerAssets;

namespace OnixiaWebApplication.Models
{
    public class ShipsModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Armor { get; set; }

        public float Shield { get; set; }

        public float Damage { get; set; }

        public ResourceBank ShipCost { get; set; }

        public float Speed { get; set; }

        public float Range { get; set; }

        public TimeSpan BuildTime { get; set; }

        public bool IsBuilt { get; set; }

        public int Amount { get; set; }
    }
}