namespace TestDane
{
    [TestClass]
    public class KulaTest
    {
        [TestMethod]
        public void TestKulaSetGet()
        {
            Dane.Kula kula = new Dane.Kula();
            
            kula.X = 1;
            kula.Y = 2;

            Assert.AreEqual(1, kula.X);
            Assert.AreEqual(2, kula.Y);
        }
    }
}