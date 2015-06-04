namespace OnixiaWebApplication.Models.ViewModels
{
    using System.Collections.Generic;

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