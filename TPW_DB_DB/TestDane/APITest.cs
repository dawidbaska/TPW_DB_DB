namespace TestDane
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void TestStworzDaneAPI()
        {
            Dane.DaneAPI daneAPI = Dane.DaneAPI.Stworz();
            Assert.IsNotNull(daneAPI);
        }
    }
    
}