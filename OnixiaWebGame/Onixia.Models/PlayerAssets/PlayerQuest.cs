namespace Onixia.Models.PlayerAssets
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Onixia.Models.ObjectTemplates;

    public class PlayerQuest
    {
        [Key]
        public int Id              { get; set; }

        public DateTime StartTime  { get; set; }
        
        public Quest Quest         { get; set; }
        
        public virtual User Player { get; set; }
    }
}
