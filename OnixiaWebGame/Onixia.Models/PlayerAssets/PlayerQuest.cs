

namespace Onixia.Models.PlayerAssets
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Onixia.Models.ObjectTemplates;

    public class PlayerQuest
    {
        [Key]
        public int Id              { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartTime { get; set; }
        
        public Quest Quest         { get; set; }
        
        public virtual User Player { get; set; }
    }
}
