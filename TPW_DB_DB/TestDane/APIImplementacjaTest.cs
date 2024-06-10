namespace TestDane
{
    [TestClass]
    public class APIImplementacjaTest
    {
        [TestMethod]
        public void TestKulaStworz()
        {
            Dane.DaneAPI daneAPI = new Dane.DaneImplementacja();
            Dane.Kula kula1 = daneAPI.KulaStworz(10,10,10);
            Dane.Plansza plansza1 = daneAPI.PlanszaStworz();
            Assert.IsNotNull(kula1);
            Assert.IsNotNull(plansza1);
        }
    }

}