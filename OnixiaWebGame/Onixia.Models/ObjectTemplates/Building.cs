using System;
using System.ComponentModel.DataAnnotations.Schema;
using Onixia.Models.PlayerAssets;

namespace Onixia.Models.ObjectTemplates
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Onixia.Models.Requirements;
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
        }
        public int Id             { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Name        { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 5)]
        public int MaxLevel       { get; set; }

        public ResourceBank ResourceRequirements { get; set; } 

        public TimeSpan BuildTime { get; set; }

        [Required]
        public virtual ICollection<BuildingRequirement> BuildingRequirements { get; set; }
    }
}
