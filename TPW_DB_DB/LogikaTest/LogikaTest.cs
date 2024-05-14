namespace LogikaTest
{
    [TestClass]
    public class LogikaTest
    {
        
        [TestMethod]
        public void TestDodajKula()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.DodajKula(1,1,1);
            Assert.AreEqual(1,kule.ListaGetSize());
        }

        [TestMethod]
        public void TestLosujStar()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.DodajKula(1,1,1);
            kule.LosujStart(0, 100, 0, 100, 0);
            Dane.Kula test = kule.GetKula(0);
            Assert.IsTrue(test.X >= 0 && test.X <= 100);
            Assert.IsTrue(test.Y >= 0 && test.Y <= 100);
        }
        [TestMethod]
        public void TestLosujNowaPozycja()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.DodajKula(1, 1, 1);
            kule.LosujStart(0, 100, 0, 100, 0);
            Dane.Kula test = kule.GetKula(0);
            kule.LosujNowaPozycja(0, 100, 0, 100, 0);
            Dane.Kula test1 = kule.GetKula(0);
            double dX = test1.X - test.X;
            double dY = test1.Y - test.Y;
            Assert.IsTrue(dX >= -1 && dX <= 1);
            Assert.IsTrue(dY >= -1 && dY <= 1);
        }

        [TestMethod]
        public void TestListaClear()
        {
            Logika.LogikaAPI kule = new Logika.Logika(Dane.DaneAPI.Stworz());
            kule.DodajKula(1,1,1);
            Assert.AreEqual(1, kule.ListaGetSize());
            kule.ListaClear();
            Assert.AreEqual(0, kule.ListaGetSize());
        }
        
    }
}