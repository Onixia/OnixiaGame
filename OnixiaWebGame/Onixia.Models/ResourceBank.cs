using System;
using System.Runtime.CompilerServices;

namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ResourceBank
    {
        #region Constructors
        public ResourceBank()
        {
            this.Metal      = 0;
            this.Crystal    = 0;
            this.Gas        = 0;
            this.Energy     = 0;
        }
        public ResourceBank(float metal = 0, float crystal = 0, float gas = 0, float energy = 0)
        {
            this.Metal      = metal;
            this.Crystal    = crystal;
            this.Gas        = gas;
            this.Energy     = energy;
        }
        #endregion

        #region Properties
        public float Metal   { get; set; }

        public float Crystal { get; set; }

        public float Gas     { get; set; }

        public float Energy  { get; set; }
        #endregion

        #region Operators and Methods
        public static ResourceBank operator -(ResourceBank a, ResourceBank b)
        {
            a.Crystal   -= b.Crystal;
            a.Energy    -= b.Energy;
            a.Gas       -= b.Gas;
            a.Metal     -= b.Metal;

            return a;
        }
        public static ResourceBank operator +(ResourceBank a, ResourceBank b)
        {
            a.Crystal   += b.Crystal;
            a.Energy    += b.Energy;
            a.Gas       += b.Gas;
            a.Metal     += b.Metal;

            return a;
        }

        public bool HasEnoughFor(ResourceBank b)
        {
            if (this.Crystal > b.Crystal &&
                this.Energy  > b.Energy &&
                this.Metal   > b.Metal &&
                this.Gas     > b.Gas)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}