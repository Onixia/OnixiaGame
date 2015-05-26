namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Asteroid
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int GalaxyCoordinate { get; set; }

        [Required]
        [Range(1, 500)]
        public int SolarSystemCoordinate { get; set; }

        [Required]
        [Range(1, 15)]
        public int PlanetCoordinate { get; set; }

        [Required]
        public int Speed { get; set; }

        public bool IsMoved { get; set; }
    }
}