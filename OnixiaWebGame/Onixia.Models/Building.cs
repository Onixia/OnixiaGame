using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Building
    {
  //        `id` tinyint(11) NOT NULL,
  //`name` varchar(20) NOT NULL,
  //`description` text NOT NULL,
  //`max_level` tinyint(4) NOT NULL,
  //`b_requirements` text NOT NULL,
  //`s_requirements` text NOT NULL

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {1} and {2} characteres long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 5)]
        public int MaxLevel { get; set; }

        [Required]
        public string BuildingRequirements { get; set; }

        [Required]
        public string ShipRequirements { get; set; }

        public bool IsConstructed { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ConstructedOn { get; set; }
    }
}
