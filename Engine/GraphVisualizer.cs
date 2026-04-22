using MapProgressionSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine
{
    public class GraphVisualizer
    {
        public void Print(List<Room> allRooms, PlayerState state, HashSet<string> visited)
        {
            Console.WriteLine("=== GRAPH VIEW ===");

            foreach (var room in allRooms)
            {
                string roomStatus = visited.Contains(room.Id) ? "[ACCESSIBLE]" : "[LOCKED]";
                Console.WriteLine($"{roomStatus} Room {room.Id}");

                foreach (var connection in room.Connections)
                {
                    bool conditionOk = connection.Condition == null || connection.Condition.IsMet(state);

                    string arrow = conditionOk ? "---->" : "-X->";
                    string targetStatus = visited.Contains(connection.Target.Id) ? "(OK)" : "(LOCKED)";
                    string conditionText = connection.Condition == null
                        ? ""
                        : $"[{connection.Condition.GetType().Name}]";

                    Console.WriteLine($"   {arrow} {connection.Target.Id} {targetStatus} {conditionText}");
                }

                Console.WriteLine();
            }
        }
    }
}
