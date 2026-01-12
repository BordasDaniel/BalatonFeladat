namespace BalatonCLI
{
    public class Program
    {
        static List<Haz> hazak = new();
        static int adoASav, adoBSav, adoCSav;

        static void Beolvas(string fajlNev)
        {
            try
            {
                using (StreamReader sr = new(fajlNev))
                {
                    string[] adoSavok = sr.ReadLine().Split(' ');
                    adoASav = int.Parse(adoSavok[0]);
                    adoBSav = int.Parse(adoSavok[1]);
                    adoCSav = int.Parse(adoSavok[2]);

                    // Házak beolvasása
                    while (!sr.EndOfStream)
                    {
                        hazak.Add(new(sr.ReadLine()));
                    }
                    Console.WriteLine("Sikeres beolvasás!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasásakor: {ex.Message}");
                return;
            }
        }

        static void Harmadik()
        {
            Console.Write("Egy tulajdonos adószáma: ");
            string adoSzam = Console.ReadLine();
            var talalatok = hazak.FindAll(h => h.TelekAdoSzam.ToString() == adoSzam);
            if (talalatok.Count > 0)
            {
                foreach (var haz in talalatok)
                {
                    Console.WriteLine($"{haz.UtcaNeve} utca {haz.Hazszam}");
                }
            }
            else
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }
        }
        
        public static int Ado(string adoSav, int alapTerulet)
        {
            int egysegAr = adoSav switch
            {
                "A" => adoASav,
                "B" => adoBSav,
                "C" => adoCSav,
                _ => 0
            };

            int osszeg = egysegAr * alapTerulet;
            return osszeg < 10000 ? 0 : osszeg;
        }

        public static void BeallitAdoSavokat(int a, int b, int c)
        {
            adoASav = a;
            adoBSav = b;
            adoCSav = c;
        }

        static void Otodik()
        {
            int aDb = 0, bDb = 0, cDb = 0;
            int aOsszeg = 0, bOsszeg = 0, cOsszeg = 0;

            foreach (var haz in hazak)
            {
                int fizetendo = Ado(haz.Adosav, haz.Terulet);
                
                switch (haz.Adosav)
                {
                    case "A":
                        aDb++;
                        aOsszeg += fizetendo;
                        break;
                    case "B":
                        bDb++;
                        bOsszeg += fizetendo;
                        break;
                    case "C":
                        cDb++;
                        cOsszeg += fizetendo;
                        break;
                }
            }

            Console.WriteLine("5. feladat");
            Console.WriteLine($"A sávba {aDb} telek esik, az adó {aOsszeg} Ft.");
            Console.WriteLine($"B sávba {bDb} telek esik, az adó {bOsszeg} Ft.");
            Console.WriteLine($"C sávba {cDb} telek esik, az adó {cOsszeg} Ft.");
        }

        static void Hatodik()
        {
            using (StreamWriter sw = new("teljes.txt"))
            {
                foreach (var haz in hazak)
                {
                    int fizetendo = Ado(haz.Adosav, haz.Terulet);
                    sw.WriteLine($"{haz.TelekAdoSzam} {haz.UtcaNeve} {haz.Hazszam} {haz.Adosav} {haz.Terulet} {fizetendo}");
                }
            }
            Console.WriteLine("6. feladat");
            Console.WriteLine("A teljes.txt fájl elkészült.");
        }

        static void Main(string[] args)
        {
            // 1. feladat
            Beolvas("utca.txt");

            // 2. feladat
            Console.WriteLine($"\n2. feladat\nAz állomány mérete: {hazak.Count}");

            // 3. feladat
            Console.WriteLine("\n3. feladat");
            Harmadik();

            // 5. feladat
            Console.WriteLine();
            Otodik();

            // 6. feladat
            Console.WriteLine();
            Hatodik();


            Console.ReadKey();
        }
    }
}
