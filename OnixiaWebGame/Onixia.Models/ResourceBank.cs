namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ResourceBank
    {
        public double Metal { get; set; }

        public double Crystal { get; set; }

        public double Gas { get; set; }

        public double Energy { get; set; }
    }
}