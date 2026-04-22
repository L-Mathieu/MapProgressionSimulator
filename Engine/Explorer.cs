using MapProgressionSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine
{
    public class Explorer
    {
        public HashSet<string> Explore(List<Room> allRooms, PlayerState state)
        {
            var visited = new HashSet<string>();

            bool changed;

            do
            {
                changed = false;

                //Console.WriteLine("=== PASS ===");

                foreach (var room in allRooms)
                {
                    //Console.WriteLine($"Testing {room.Id}");
                    if (visited.Contains(room.Id))
                    {
                        //Console.WriteLine($"Is already visited {room.Id}");
                        continue;
                    }

                    if (CanReach(room, state))
                    {
                        visited.Add(room.Id);
                        //Console.WriteLine($"Visiting {room.Id}");
                        changed = true;

                        if (room.PowerGiven != null)
                        {
                            state.AddPower(room.PowerGiven);
                            //Console.WriteLine($"Powers: {string.Join(",", state.Powers)}");
                        }
                            
                    }
                }

            } while (changed);

            return visited;
        }

        private bool CanReach(Room room, PlayerState state)
        {
            bool isTrue = room.Connections.Any(c =>
                c.Condition == null || c.Condition.IsMet(state));
            return isTrue;
        }
    }
}
