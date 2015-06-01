using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onixia.Models
{
    public class SpaceObject
    {

        #region Properties
        [Required]
        public float PosX { get; set; }
        [Required]
        public float PosY { get; set; }
        #endregion

        #region Methods
        public float DistanceTo(SpaceObject other)
        {
            float distance = (float) Math.Sqrt(Math.Pow(this.PosX - other.PosX, 2)
                                             + Math.Pow(this.PosY - other.PosY, 2));
            return distance;
        }
        #endregion
    }
}
