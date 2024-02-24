using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbutAndFight.Tools
{
    public class Bilgisayar
    {
        public Bilgisayar()
        {
            Can = 80;
            Level = 0;
            NormalVurus = new Random();
        }

        public int Can { get; set; }

        public Random NormalVurus { get; set; }

        public int Level { get; set; }
    }
}
