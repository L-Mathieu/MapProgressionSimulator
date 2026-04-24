using MapProgressionSimulator.Models.Dragéomite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine.Dragéomite
{
    public class MapPrinter
    {
        public void Print(Dictionary<string, Case> rooms, Case start)
        {
            var visited = new HashSet<Case>();
            var queue = new Queue<Case>();

            queue.Enqueue(start);
            visited.Add(start);

            Console.WriteLine("=== MAP ===");

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                Console.Write($"[{current.Name}] -> ");

                List<string> connections = new List<string>();

                foreach (var kvp in current.AdjacentCases)
                {
                    if (kvp.Value != null)
                    {
                        connections.Add(kvp.Key + ":" + kvp.Value.Name);

                        if (!visited.Contains(kvp.Value))
                        {
                            visited.Add(kvp.Value);
                            queue.Enqueue(kvp.Value);
                        }
                    }
                }

                if (connections.Count == 0)
                    Console.Write("Dead End");

                else
                    Console.Write(string.Join(", ", connections));

                Console.WriteLine();
            }

            // 🔴 salles isolées
            var isolated = rooms.Values.Where(r => !visited.Contains(r));

            if (isolated.Any())
            {
                Console.WriteLine("\n=== ISOLATED ROOMS ===");
                foreach (var room in isolated)
                {
                    Console.WriteLine($"[{room.Name}]");
                }
            }
        }
    }
}
