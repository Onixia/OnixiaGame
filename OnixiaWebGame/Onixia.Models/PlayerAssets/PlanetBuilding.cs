using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onixia.Models.ObjectTemplates;

namespace Onixia.Models.PlayerAssets
{
    public class PlanetBuilding
    {
        public PlanetBuilding()
        {
            StartedOn = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int BuildingLevel { get; set; }

        public virtual Building Building { get; set; }

        [ForeignKey("Building")]
        [Required]
        public int BuildingId { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime StartedOn { get; set; }
        
    }
}
