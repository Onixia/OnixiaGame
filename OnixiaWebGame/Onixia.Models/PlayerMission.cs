using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onixia.Models
{
    class PlayerMission : Mission
    {
        [Required]
        public DateTime StartTime  { get; set; }
        public Mission MissionType { get; set; }
        public virtual User Player { get; set; }
    }
}
