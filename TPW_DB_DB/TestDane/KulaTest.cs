namespace TestDane
{
    [TestClass]
    public class KulaTest
    {
        [TestMethod]
        public void TestKulaSetGet()
        {
            Dane.Kula kula = new Dane.Kula(10,20,5);
            
            kula.X = 1;
            kula.Y = 2;
            kula.Wektor_X = 0;
            kula.Wektor_Y = 1;
            kula.Nadany_Wektor = true;

            Assert.AreEqual(1, kula.X);
            Assert.AreEqual(2, kula.Y);
            Assert.AreEqual(0, kula.Wektor_X);
            Assert.AreEqual(1, kula.Wektor_Y);
            Assert.AreEqual(true, kula.Nadany_Wektor);
            Assert.AreEqual(10, kula.Predkosc);
            Assert.AreEqual(20, kula.Srednica);
            Assert.AreEqual(5, kula.Waga);
        }


        [TestMethod]
        public void PropertyChangeTest()
        {
            Dane.Kula kula = new Dane.Kula(10, 20, 5);
            bool flagax = false;
            bool flagay = false;
            kula.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Dane.Kula.X))
                    flagax = true;
            };

            kula.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Dane.Kula.Y))
                    flagay = true;
            };

            kula.X = 1;
            kula.Y = 1;

            Assert.AreEqual(true, flagax);
            Assert.AreEqual(true, flagay);

        }
    }
}