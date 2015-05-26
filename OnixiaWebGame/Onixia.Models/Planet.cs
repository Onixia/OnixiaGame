namespace Onixia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Planet
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
        public Resource Resources { get; set; }

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

        [Required]
        [Range(1, 5)]
        public int GalaxyCoordinate { get; set; }

        [Required]
        [Range(1, 500)]
        public int SolarSystemCoordinate { get; set; }

        [Required]
        [Range(1, 15)]
        public int PlanetCoordinate { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public bool IsMainPlanet { get; set; }
    }
}