using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onixia.Models.PlayerAssets;
using Onixia.Models.Requirements;

namespace OnixiaWebApplication.Models
{
    public class BuildingViewModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BuildingRequirement> BuildingRequirements { get; set; }

        public ResourceBank ResourceRequirements { get; set; }

        public int? CurrentLevel { get; set; }

        public TimeSpan TimeLeft { get; set; }

        public bool IsBuildable { get; set; }

        public bool IsBuilding { get; set; }

        public string ErrorMessage { get; set; }
    }
}