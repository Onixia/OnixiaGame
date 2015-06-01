namespace Onixia.Models.Requirements
{
    using Onixia.Models.ObjectTemplates;
    using System.ComponentModel.DataAnnotations;
    class ShipRequirement : Requirement
    {
        [Required]
        public Ship RequiredShip { get; set; }

        [Required]
        public int RequiredCount { get; set; }
        
    }
}
