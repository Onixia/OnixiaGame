using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onixia.Models.ObjectTemplates;

namespace Onixia.Models.Requirements
{
    class TechnologyRequirement
    {
        [Key]
        public int Id { get; set; }
        public Technology Technology { get; set; }
    }
}
