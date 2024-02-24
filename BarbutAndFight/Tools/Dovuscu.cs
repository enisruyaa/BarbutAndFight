using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbutAndFight.Tools
{
    public class Dovuscu
    {
        public Dovuscu()
        {
            Can = 100;
            Level = 0;
            OzelVurus = 20;
            OzelGucHak = 3;
            NormalVurus = new Random();
        }

        public int Can { get; set; }

        public Random NormalVurus { get; set; }

        public int OzelVurus { get; set; }

        public int Level { get; set; }

        public int OzelGucHak { get; set; }
    }
}
