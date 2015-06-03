using Onixia.Models.PlayerAssets;

namespace Onixia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Onixia.Models.ObjectTemplates;

    /// <summary>
    /// This class tracks an order of a number of ships so that upon completion 
    /// they can be added to the player's ship dictionary, which should happen 
    /// in some sort of controller.
    /// </summary>
    public class ShipOrder
    {
        private ICollection<PlanetShip> shipsCount;
        public ShipOrder()
        {
            this.shipsCount = new HashSet<PlanetShip>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeCreated { get; set; }

        public virtual ICollection<PlanetShip> ShipsCount
        {
            get { return this.shipsCount; }
            set { this.shipsCount = value; }
        }

        public TimeSpan BuildTimeLength { get; set; }

        public virtual Planet TargetPlanet { get; set; }
    }
}
