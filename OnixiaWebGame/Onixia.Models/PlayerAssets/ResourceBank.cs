
namespace Onixia.Models.PlayerAssets
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
            ResourceBank c = new ResourceBank(a.Metal,
                                              a.Crystal,
                                              a.Gas,
                                              a.Energy);
            c.Crystal -= b.Crystal;
            c.Energy  -= b.Energy;
            c.Gas     -= b.Gas;
            c.Metal   -= b.Metal;

            return c;
        }
        public static ResourceBank operator +(ResourceBank a, ResourceBank b)
        {
            ResourceBank c = new ResourceBank(a.Metal,
                                              a.Crystal,
                                              a.Gas,
                                              a.Energy);
            c.Crystal   += b.Crystal;
            c.Energy    += b.Energy;
            c.Gas       += b.Gas;
            c.Metal     += b.Metal;

            return c;
        }

        public bool HasEnoughFor(ResourceBank b)
        {
            if (this.Crystal >= b.Crystal &&
                this.Energy  >= b.Energy &&
                this.Metal   >= b.Metal &&
                this.Gas     >= b.Gas)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}