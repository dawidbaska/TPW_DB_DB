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
        [TestMethod]
        public void TestLogi()
        {
            string folder = Directory.GetCurrentDirectory();
            string wzgledna = @"..\..\..\..\Logi\";
            string cala = Path.Combine(folder, wzgledna, "test_log1.json");
            if (File.Exists(cala))
            {
                File.Delete(cala);
            }
            Dane.DaneAPI daneAPI = new Dane.DaneImplementacja();
            daneAPI.LoggerStworz(cala);
            Assert.IsTrue(File.Exists(cala));
            string wiadomosc = "2024-05-29 10:00:00.000: abcd";
            daneAPI.DodajLogi(wiadomosc);
            daneAPI.ZapiszLogi();
            daneAPI.KoniecZapisow();
            File.Delete(cala);
            Assert.IsFalse(File.Exists(cala));
        }
    }

}