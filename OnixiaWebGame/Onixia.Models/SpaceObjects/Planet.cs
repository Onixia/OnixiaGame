

namespace Onixia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Onixia.Models.ObjectTemplates;
    using Onixia.Models.PlayerAssets;

    public class Planet : SpaceObject
    {
        private ICollection<Building> buildings;
        private ICollection<Ship> ships;
 
        public Planet()
        {
            this.buildings = new HashSet<Building>();
            this.ships = new HashSet<Ship>();
        }
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public ResourceBank PlanetResourceses { get; set; }

        [Required]
        public int Fields { get; set; }

        public virtual ICollection<Building> Buildings 
        {
            get { return this.buildings; }
            set { this.buildings = value; }
        }

        public virtual ICollection<Ship> Ships 
        {
            get { return this.ships; }
            set { this.ships = value; }
        }

        public DateTime? LastUpdatedOn { get; set; }

        public bool IsMainPlanet { get; set; }
    }
}