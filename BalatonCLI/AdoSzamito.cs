using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class AdoSzamito
    {
        public int AdoASav { get; set; }
        public int AdoBSav { get; set; }
        public int AdoCSav { get; set; }

        public AdoSzamito(int adoASav, int adoBSav, int adoCSav)
        {
            AdoASav = adoASav;
            AdoBSav = adoBSav;
            AdoCSav = adoCSav;
        }

        public int Ado(string adoSav, int alapTerulet)
        {
            int egysegAr = adoSav switch
            {
                "A" => AdoASav,
                "B" => AdoBSav,
                "C" => AdoCSav,
                _ => 0
            };

            int osszeg = egysegAr * alapTerulet;
            return osszeg < 10000 ? 0 : osszeg;
        }
    }
}
