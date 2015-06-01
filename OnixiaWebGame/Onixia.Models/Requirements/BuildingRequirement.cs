namespace Onixia.Models.Requirements
{
    using System.ComponentModel.DataAnnotations;
    public class BuildingRequirement : Requirement
    {
        [Required]
        public Building RequiredBuilding { get; set; }
        
        [Required]
        public int BuildingLevel         { get; set; }

        public int CountRequired         { get; set; }        
    }
}
