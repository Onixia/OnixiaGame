namespace OnixiaWebApplication.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Onixia.Logic.Mappings;
    using Onixia.Models.ObjectTemplates;
    using Onixia.Models.PlayerAssets;
    using Onixia.Models.Requirements;

    public class BuildingViewModel : IMapFrom<BuildingTemplate>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BuildingRequirement> BuildingRequirements { get; set; }

        public ResourceBank ResourceRequirements { get; set; }

        public int? CurrentLevel { get; set; }

        public TimeSpan TimeLeft { get; set; }

        public BuildingType BuildingType { get; set; }

        public TimeSpan BuildTime { get; set; }

        public bool IsBuildable { get; set; }

        public bool IsBuilding { get; set; }

        public string ErrorMessage { get; set; }
    }
}