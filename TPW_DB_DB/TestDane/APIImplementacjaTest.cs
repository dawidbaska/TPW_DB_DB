namespace TestDane
{
    [TestClass]
    public class APIImplementacjaTest
    {
        [TestMethod]
        public void TestKulaStworz()
        {
            Dane.DaneAPI daneAPI = new Dane.DaneImplementacja();
            Dane.Kula kula1 = daneAPI.KulaStworz();
            Assert.IsNotNull(kula1);
        }
    }

}