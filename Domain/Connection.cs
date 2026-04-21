using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapProgressionSimulator.Domain.Conditions;

namespace MapProgressionSimulator.Domain
{
    public class Connection
    {
        public Room Target { get; set; }

        public ICondition? Condition { get; set; }

        public Connection(Room target, ICondition? condition = null)
        {
            Target = target;
            Condition = condition;
        }
    }
}
