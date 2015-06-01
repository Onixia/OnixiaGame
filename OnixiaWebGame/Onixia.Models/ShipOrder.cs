namespace Onixia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Onixia.Models.ObjectTemplates;

    /// <summary>
    /// This class tracks an order of a number of ships so that upon completion 
    /// they can be added to the player's ship dictionary, which should happen 
    /// in some sort of controller.
    /// </summary>
    public class ShipOrder
    {
        public ShipOrder()
        {
            this.ShipsCount = new Dictionary<Ship, int>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime OrderMade { get; set; }

        public Dictionary<Ship, int> ShipsCount { get; set; }

        public Planet TargetPlanet { get; set; }
    }
}
