using MapProgressionSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine
{
    public class Validator
    {
        public bool IsFullyReachable(HashSet<string> visited, List<Room> allRooms)
        {
            return allRooms.All(r => visited.Contains(r.Id));
        }
    }
}
