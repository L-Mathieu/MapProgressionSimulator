using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Domain.Conditions
{
    public class HasPowerCondition : ICondition
    {
        public string RequiredPower;

        public HasPowerCondition(string requiredPower)
        {
            RequiredPower = requiredPower;
        }

        public bool IsMet(PlayerState state)
        {
            return state.HasPower(RequiredPower);
        }
    }
}
