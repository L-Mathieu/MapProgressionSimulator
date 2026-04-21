using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Domain
{
    public class Room
    {
        public string Id { get; private set; }

        // Connexions vers d'autres rooms
        public List<Connection> Connections { get; set; } = new();

        // Optionnel : ce que la room donne au joueur
        public string? PowerGiven { get; set; }

        public Room(string id)
        {
            Id = id;
        }
    }
}
