namespace Onixia.Models.PlayerAssets
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Onixia.Models.ObjectTemplates;
    class PlayerMission
    {
        [Required]
        public DateTime StartTime  { get; set; }
        
        public Mission Mission     { get; set; }
        
        public virtual User Player { get; set; }
    }
}
