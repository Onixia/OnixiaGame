namespace Onixia.Models.PlayerAssets
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ObjectTemplates;

    public class PlanetShip
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Ship")]
        public int ShipId { get; set; }

        public virtual ShipTemplate Ship { get; set; }

        public int ShipCount { get; set; }
    }
}