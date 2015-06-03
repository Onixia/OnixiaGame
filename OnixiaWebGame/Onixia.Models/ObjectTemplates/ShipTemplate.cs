using System.Collections.Generic;
using Onixia.Models.Requirements;

namespace Onixia.Models.ObjectTemplates
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Onixia.Models.PlayerAssets;
    /*
     * Ship class containing base template statistics for every ship buildable by the players.
     */
    public class ShipTemplate
    {
        public ShipTemplate()
        {
            this.BuildingRequirements = new HashSet<BuildingRequirement>();
            this.TechnologyRequirements = new HashSet<TechnologyRequirement>();
            this.ShipCost = new ResourceBank();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Description { get; set; }

        public WeaponType WeaponType { get; set; }

        [Required]
        public ArmorType ArmorType { get; set; }

        [Required]
        public float Shield { get; set; }

        public float Damage { get; set; }

        [Required]
        public ResourceBank ShipCost { get; set; }

        public int GasConsumption { get; set; }

        public float Speed { get; set; }

        public TimeSpan BuildTime { get; set; }

        public virtual ICollection<BuildingRequirement> BuildingRequirements { get; set; }
        public virtual ICollection<TechnologyRequirement> TechnologyRequirements { get; set; }
    }

        /*
         * Enumeration containing different weapon types. 
         * Can be used for creating more dynamic loginc behind space battles.
         */

    public enum WeaponType
    {
        Laser,
        Ion,
        Plasma
    }

    public enum ArmorType
    {
        Light,
        Medium,
        Heavy
    }
}   
