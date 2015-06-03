namespace Onixia.Models.ObjectTemplates
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Onixia.Models.PlayerAssets;

    public class Technology
    {
        public Technology()
        {
            this.BuildingRequirements   = new Dictionary<BuildingTemplate, bool>();
            this.TechnologyRequirements = new Dictionary<Technology, bool>();
            this.ResourceCost           = new ResourceBank();
        }

        [Key]
        public int Id                                              { get; set; }

        [Required(ErrorMessage = "Technology Must have a name")]
        public string Name                                         { get; set; }

        public string Description                                  { get; set; }

        public Dictionary<Technology, bool> TechnologyRequirements { get; set; }

        public Dictionary<BuildingTemplate, bool> BuildingRequirements     { get; set; }

        public ResourceBank ResourceCost                           { get; set; } 
    }
}