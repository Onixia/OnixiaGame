namespace Onixia.Models.ObjectTemplates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlayerAssets;

    using Requirements;

    /*
     * Template class for the buildings
     * It contains every type of building 
     * available for the players to build
     */

    public class Building
    {
        public Building()
        {
            this.BuildingRequirements = new HashSet<BuildingRequirement>();
            this.Income = 0;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [Range(1, 30)]
        public int MaxLevel { get; set; }

        public ResourceBank ResourceRequirements { get; set; }

        public int Income { get; set; }

        public TimeSpan BuildTime { get; set; }

        public virtual ICollection<BuildingRequirement> BuildingRequirements { get; set; }

        public BuildingType BuildingType { get; set; }
    }

    public enum BuildingType
    {
        Metal,
        Crystal,
        Gas,
        SolarPanels,
        GasTank,
        MetalWarehouse,
        CrystalWareHouse,
        TradeCenter,
        Spaceport,
        ScienceFacility,
        Other
    }
}