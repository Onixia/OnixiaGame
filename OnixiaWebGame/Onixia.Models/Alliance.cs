namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Alliance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characters long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {1} and {2} characters long!", MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public int Leader { get; set; }
    }
}