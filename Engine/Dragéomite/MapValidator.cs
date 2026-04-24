using MapProgressionSimulator.Models.Dragéomite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine.Dragéomite
{
    public class MapValidator
    {
        public bool IsMapValid(Dictionary<string, Case> rooms, Case start)
        {
            HashSet<Case> visited = new HashSet<Case>();
            Queue<Case> queue = new Queue<Case>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var neighbor in current.AdjacentCases.Values)
                {
                    if (neighbor != null && !visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visited.Count == rooms.Count;
        }
    }
}
