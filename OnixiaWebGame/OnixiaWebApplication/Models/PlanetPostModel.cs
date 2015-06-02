using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnixiaWebApplication.Models
{
    public class PlanetPostModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characters long!", MinimumLength = 3)]
        public string Name { get; set; }
        
    }
}