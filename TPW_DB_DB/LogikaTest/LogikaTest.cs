using Dane;
using Logika;
using System.Reflection;

namespace LogikaTest
{
    [TestClass]
    public class LogikaTest
    {

        [TestMethod]
        public void TestDodajKula()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.DodajKula(10, 10, 10);
            Assert.AreEqual(1, kule.ListaGetSize());
        }

        [TestMethod]
        public void TestLosujStar()
        {
            string folder = Directory.GetCurrentDirectory();
            string wzgledna = @"..\..\..\..\Logi\";
            string cala = Path.Combine(folder, wzgledna, "test3_log.json");

            if (File.Exists(cala))
            {
                File.Delete(cala);
            }
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.stworzLogger(cala);
            string wiadomosc = "2024-05-29 10:00:00.000: abcd";
            kule.DodajLogi(wiadomosc);
            kule.DodajKula(10, 10, 10);
            kule.LosujStart(0, 100, 0, 100, 0);
            Dane.Kula test = kule.GetKula(0);
            Assert.IsTrue(test.X >= 0 && test.X <= 100);
            Assert.IsTrue(test.Y >= 0 && test.Y <= 100);
            kule.ZapiszLogi();
            kule.KoniecZapisow();
            File.Delete(cala);
            Assert.IsFalse(File.Exists(cala));
        }

        [TestMethod]
        public void TestListaClear()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.DodajKula(10, 10, 10);
            Assert.AreEqual(1, kule.ListaGetSize());
            kule.ListaClear();
            Assert.AreEqual(0, kule.ListaGetSize());
        }

        [TestMethod]
        public void TestStworzPlansze()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            Dane.Plansza plansza = kule.StworzPlansze(1, 2, 3);
            Assert.AreEqual(1, plansza.W);
            Assert.AreEqual(2, plansza.H);
            Assert.AreEqual(3, plansza.BT);
        }


        [TestMethod]
        public void TestLosujNowaPozycja()
        {
            string folder = Directory.GetCurrentDirectory();
            string wzgledna = @"..\..\..\..\Logi\";
            string cala = Path.Combine(folder, wzgledna, "test4_log.json");

            if (File.Exists(cala))
            {
                File.Delete(cala);
            }
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.stworzLogger(cala);
            string wiadomosc = "2024-05-29 10:00:00.000: abcd";
            kule.DodajLogi(wiadomosc);
            kule.DodajKula(10, 10, 10);
            kule.LosujStart(0, 100, 0, 100, 0);
            Dane.Kula kula = kule.GetKula(0);
            kula.X = -1;
            kula.Y = -2;
            kule.LosujNowaPozycja(0, 100, 0, 100, 0);
            Dane.Kula kula1 = kule.GetKula(0);
            Assert.IsTrue(kula1.X >= 0 && kula1.X <= 100);
            Assert.IsTrue(kula1.Y >= 0 && kula1.Y <= 100);
            kule.ZapiszLogi();
            kule.KoniecZapisow();
            File.Delete(cala);
            Assert.IsFalse(File.Exists(cala));
        }
    }
}