using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onixia.Models.ObjectTemplates;
using Onixia.Models.PlayerAssets;
using Onixia.Models.Requirements;

namespace OnixiaWebApplication.Models
{
    public class AllBuildingsModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BuildingRequirement> BuildingRequirements { get; set; }

        public ResourceBank ResourceRequirements { get; set; }

        public int CurrentLevel { get; set; }

        public TimeSpan BuildTime { get; set; }
    }
}