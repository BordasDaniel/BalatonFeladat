using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Haz
    {
        public int TelekAdoSzam {  get; private set; }
        public string UtcaNeve {  get; private set; }
        public string Hazszam {  get; private set; }
        public string Adosav { get; private set; }
        public int Terulet { get; private set; }

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
