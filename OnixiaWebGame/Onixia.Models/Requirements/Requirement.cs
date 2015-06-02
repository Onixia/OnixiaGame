namespace Onixia.Models.Requirements
{
    using System.ComponentModel.DataAnnotations;

    public class Requirement
    {
        [Key]
        public int Id          { get; set; }

        public bool IsRequired { get; set; }
    }
}