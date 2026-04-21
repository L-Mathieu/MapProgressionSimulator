using MapProgressionSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Engine
{
    public class SoftLockDetector
    {
        public List<string> FindSoftLocks(List<Room> allRooms, HashSet<string> reachableRooms)
        {
            var lockedRooms = new List<string>();

            foreach (var room in allRooms)
            {
                if (!reachableRooms.Contains(room.Id))
                {
                    lockedRooms.Add(room.Id);
                }
            }

            return lockedRooms;
        }
    }
}
