using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbutAndFight.Models
{
    public class Oyuncu
    {
        public Oyuncu()
        {
            Bakiye = 400;
        }

        public int Bakiye { get; set; }

        public Random Zari { get; set; }

        public string ZarSonucuGoster()
        {
            Zari = new Random();
            return Zari.Next(1,7).ToString();
        }
    }
}
