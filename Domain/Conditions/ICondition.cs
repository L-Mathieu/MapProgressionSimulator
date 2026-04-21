using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Domain.Conditions
{
    public interface ICondition
    {
        bool IsMet(PlayerState state);
    }
}
