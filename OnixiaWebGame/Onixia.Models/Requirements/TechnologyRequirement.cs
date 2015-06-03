namespace Onixia.Models.Requirements
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ObjectTemplates;

    internal class TechnologyRequirement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }

        public virtual Technology Technology { get; set; }
    }
}