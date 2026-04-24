using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Models.Dragéomite
{
    public class Case
    {
        public string Name { get; set; }

        public Dictionary<string, Case?> AdjacentCases { get; set; }
            = new Dictionary<string, Case?>()
            {
            { "Left", null },
            { "Right", null },
            { "Top", null },
            { "Bottom", null }
            };
    }
}
