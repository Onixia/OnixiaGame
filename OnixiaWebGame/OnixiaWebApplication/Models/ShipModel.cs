namespace OnixiaWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using Onixia.Models.ObjectTemplates;
    using Onixia.Models.PlayerAssets;

    public class ShipViewModel
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

        public string ErrorMessage { get; set; }
    }

    public class ShipsModel
    {
        public ShipsModel()
        {
            this.Ships = new List<ShipViewModel>();
        }
        public ICollection<ShipViewModel> Ships { get; set; }
        
    }

    public class ShipPostModel
    {
        public int ShipId { get; set; }

        public int ShipCount { get; set; }
    }
}