namespace LogikaTest
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void TestStworzLogikaAPI()
        {
            Logika.LogikaAPI logikaAPI = Logika.LogikaAPI.Stworz();
            Assert.IsNotNull(logikaAPI);
        }
    }

}
