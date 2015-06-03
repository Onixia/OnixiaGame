namespace OnixiaWebApplication.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlanetPostModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characters long!", MinimumLength = 3)]
        [Display(Name = "Planet Name")]
        public string Name { get; set; }
    }
}