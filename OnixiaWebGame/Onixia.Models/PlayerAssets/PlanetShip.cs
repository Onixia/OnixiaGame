using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Onixia.Models.PlayerAssets
{
    using Onixia.Models.ObjectTemplates;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlanetShip
    {
        [Required]
        [ForeignKey("Ship")]
        public int ShipId { get; set; }

        public virtual Ship Ship { get; set; }

        public int ShipCount { get; set; }

    }
}
