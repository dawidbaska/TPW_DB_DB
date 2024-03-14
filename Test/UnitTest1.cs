using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;
using TPW_DB_DB.Model;


namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ModelLinearFunction function = new ModelLinearFunction();
            function.a = 1;
            function.b = 2;
            Assert.AreEqual(function.FindZero(), -2);
            function.a = 0;
            Assert.AreEqual(function.FindZero(), null);



        }
    }
}
