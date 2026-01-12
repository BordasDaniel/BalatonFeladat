using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonWPF
{
    public class Haz
    {
        public int TelekAdoSzam { get; set; }
        public string UtcaNeve { get; set; }
        public string Hazszam { get; set; }
        public string Adosav { get; set; }
        public int Terulet { get; set; }

        public Haz(int telekAdoSzam, string utcaNeve, string hazszam, string adosav, int terulet)
        {
            TelekAdoSzam = telekAdoSzam;
            UtcaNeve = utcaNeve;
            Hazszam = hazszam;
            Adosav = adosav;
            Terulet = terulet;
        }

        public Haz(string sor)
        {
            string[] adatok = sor.Split(' ');
            TelekAdoSzam = int.Parse(adatok[0]);
            UtcaNeve = adatok[1];
            Hazszam = adatok[2];
            Adosav = adatok[3];
            Terulet = int.Parse(adatok[4]);
        }
    }
}
