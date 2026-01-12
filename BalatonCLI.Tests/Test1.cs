using System;
using BalatonCLI;

namespace BalatonCLI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            // Beállítjuk az adósávok értékeit minden teszt előtt
            // A: 800 Ft/m2, B: 600 Ft/m2, C: 100 Ft/m2
            Program.BeallitAdoSavokat(800, 600, 100);
        }

        [TestMethod]
        public void Ado_ASav_SzamolasHelyes()
        {
            // A sáv: 800 Ft/m2, 150 m2 = 120000 Ft
            int eredmeny = Program.Ado("A", 150);
            Assert.AreEqual(120000, eredmeny, "A sávba eső adó számítása helytelen.");
        }

        [TestMethod]
        public void Ado_BSav_SzamolasHelyes()
        {
            // B sáv: 600 Ft/m2, 100 m2 = 60000 Ft
            int eredmeny = Program.Ado("B", 100);
            Assert.AreEqual(60000, eredmeny, "B sávba eső adó számítása helytelen.");
        }

        [TestMethod]
        public void Ado_CSav_SzamolasHelyes()
        {
            // C sáv: 100 Ft/m2, 200 m2 = 20000 Ft
            int eredmeny = Program.Ado("C", 200);
            Assert.AreEqual(20000, eredmeny, "C sávba eső adó számítása helytelen.");
        }

        [TestMethod]
        public void Ado_MinimumAlatt_NullaAdot()
        {
            // C sáv: 100 Ft/m2, 50 m2 = 5000 Ft -> 0 Ft (nem éri el a 10000 Ft-ot)
            int eredmeny = Program.Ado("C", 50);
            Assert.AreEqual(0, eredmeny, "10000 Ft alatti adó esetén 0-t kell visszaadni.");
        }

        [TestMethod]
        public void Ado_MinimumHatar_TizEzerFt()
        {
            // C sáv: 100 Ft/m2, 100 m2 = 10000 Ft (pontosan a határ)
            int eredmeny = Program.Ado("C", 100);
            Assert.AreEqual(10000, eredmeny, "10000 Ft-os adó esetén 10000-et kell visszaadni.");
        }

        [TestMethod]
        public void Ado_NagyTerulet_ASav()
        {
            // A sáv: 800 Ft/m2, 500 m2 = 400000 Ft
            int eredmeny = Program.Ado("A", 500);
            Assert.AreEqual(400000, eredmeny, "Nagy területű A sávos ingatlan adója helytelen.");
        }
    }
}
