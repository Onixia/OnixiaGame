using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onixia.Models.ObjectTemplates;
using Onixia.Models.PlayerAssets;

namespace OnixiaWebApplication.Models
{
    public class CombinedBuildingsViewModel
    {
        public CombinedBuildingsViewModel(ICollection<BuildingViewModel> allBuildings)
        {
            this.AllBuildings = allBuildings;
        }

        public CombinedBuildingsViewModel()
        {
            this.AllBuildings = new HashSet<BuildingViewModel>();
        }
        public ICollection<BuildingViewModel> AllBuildings { get; set; }
    }
}