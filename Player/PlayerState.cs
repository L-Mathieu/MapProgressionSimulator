using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProgressionSimulator.Domain
{
    public class PlayerState
    {
        public HashSet<string> Powers { get; private set; } = new();

        public void AddPower(string power)
        {
            Powers.Add(power);
        }

        public bool HasPower(string power)
        {
            return Powers.Contains(power);
        }

        public void ShowPower()
        {
            foreach (var power in Powers)
            {
                Console.WriteLine(power);
            }
        }
    }
}
