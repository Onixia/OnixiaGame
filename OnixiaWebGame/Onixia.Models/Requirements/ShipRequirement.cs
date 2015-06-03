namespace Onixia.Models.Requirements
{
    using Onixia.Models.ObjectTemplates;
    using System.ComponentModel.DataAnnotations;

    public class ShipRequirement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ShipTemplate RequiredShip { get; set; }

        [Required]
        public int RequiredCount { get; set; }
        
    }
}
