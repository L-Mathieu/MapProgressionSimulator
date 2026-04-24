using MapProgressionSimulator.Models.Dragéomite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine.Dragéomite
{
    public class MapPrinter2D
    {
        const int CELL_SIZE = 5;
        public void Print(Dictionary<string, Case> rooms, Case start)
        {
            Dictionary<Case, (int x, int y)> positions = new();
            Queue<Case> queue = new();

            positions[start] = (0, 0);
            queue.Enqueue(start);

            // 🔥 1. BFS pour positionner les salles
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var (x, y) = positions[current];
                Console.WriteLine(current.Name + " " + (x, y));

                foreach (var kvp in current.AdjacentCases)
                {
                    var neighbor = kvp.Value;
                    if (neighbor == null) continue;
                    if (positions.ContainsKey(neighbor)) continue;

                    var (dx, dy) = GetOffset(kvp.Key);

                    positions[neighbor] = (x + dx * 2, y + dy * 2);
                    queue.Enqueue(neighbor);
                }
            }

            PrintWithConnections(positions);
        }

        private (int dx, int dy) GetOffset(string dir)
        {
            return dir switch
            {
                "Right" => (1, 0),
                "Left" => (-1, 0),
                "Top" => (0, 1),
                "Bottom" => (0, -1),
                _ => (0, 0)
            };
        }

        private void PrintWithConnections(Dictionary<Case, (int x, int y)> positions)
        {
            int minX = positions.Values.Min(p => p.x);
            int maxX = positions.Values.Max(p => p.x);
            int minY = positions.Values.Min(p => p.y);
            int maxY = positions.Values.Max(p => p.y);

            Dictionary<(int x, int y), string> grid = new();

            // 🔹 1. placer les rooms
            foreach (var kvp in positions)
            {
                var room = kvp.Key;
                var (x, y) = kvp.Value;

                grid[(x, y)] = $"[{room.Name}]";
            }

            // 🔥 2. ajouter les connexions
            foreach (var kvp in positions)
            {
                var room = kvp.Key;
                var (x, y) = kvp.Value;

                foreach (var link in room.AdjacentCases)
                {
                    if (link.Value == null) continue;

                    var (dx, dy) = GetOffset(link.Key);

                    int cx = x + dx;
                    int cy = y + dy;

                    string connector = GetConnector(link.Key);

                    grid[(cx, cy)] = connector;
                }
            }

            // 🔥 3. affichage
            Console.WriteLine("\n=== MAP DUNGEON ===\n");

            for (int y = maxY; y >= minY; y--)
            {
                string line = "";

                for (int x = minX; x <= maxX; x++)
                {
                    if (grid.TryGetValue((x, y), out var value))
                        line += Pad(grid[(x, y)], CELL_SIZE);
                    else
                        line += Pad("", CELL_SIZE);
                }

                Console.WriteLine(line);
            }
        }

        private string GetConnector(string dir)
        {
            return dir switch
            {
                "Right" => "---",
                "Left" => "---",
                "Top" => "  |  ",
                "Bottom" => "  |  ",
                _ => "   "
            };
        }

        private string Pad(string value, int size)
        {
            if (value.Length > size)
                return value.Substring(0, size);

            return value.PadRight(size);
        }
    }
}
