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


        public virtual BuildingTemplate BuildingTemplate { get; set; }

        [ForeignKey("BuildingTemplate")]
        [Required]
        public int BuildingTemplateId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartedOn { get; set; }

        [Required]
        [ForeignKey("Planet")]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
        
        public ResourceBank CalculateCost()
        {
            ResourceBank neededResourses = new ResourceBank();
            neededResourses.Crystal = this.BuildingTemplate.ResourceRequirements.Crystal * (this.BuildingLevel + 1);
            neededResourses.Metal = this.BuildingTemplate.ResourceRequirements.Metal * (this.BuildingLevel + 1);
            neededResourses.Gas = this.BuildingTemplate.ResourceRequirements.Gas * (this.BuildingLevel + 1);
            neededResourses.Energy = this.BuildingTemplate.ResourceRequirements.Energy * (this.BuildingLevel + 1);
            return neededResourses;
        }

        public int CalculateIncome()
        {
            return this.BuildingTemplate.Income * (this.BuildingLevel + 1);
        }
    }
}
