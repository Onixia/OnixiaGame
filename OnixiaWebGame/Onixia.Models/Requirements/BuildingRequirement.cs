namespace Onixia.Models.Requirements
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Onixia.Models.ObjectTemplates;

    public class BuildingRequirement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequiredBuilding")]
        public int RequiredBuildingId { get; set; }

        [Required]
        public virtual Building RequiredBuilding { get; set; }
        
        [Required]
        public int BuildingLevel         { get; set; }

        public int CountRequired         { get; set; }        
    }
}
