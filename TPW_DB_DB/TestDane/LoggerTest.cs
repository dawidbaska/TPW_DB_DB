using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestDane
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void testMetod()
        {
            string folder = Directory.GetCurrentDirectory();
            string wzgledna = @"..\..\..\..\Logi\";
            string cala = Path.Combine(folder, wzgledna, "test_log2.json");

            if (File.Exists(cala))
            {
                File.Delete(cala);
            }

            Dane.Logger logger = new Dane.Logger("test_log2.json");

            logger.zapiszLogi("2024-06-10_13-24-43", "abcd");


            string logContent = File.ReadAllText(cala);
            Assert.IsTrue(logContent.Contains("\"timestamp\":\"2024-06-10_13-24-43\""));
            Assert.IsTrue(logContent.Contains("\"message\":\"abcd\""));

            File.Delete(cala);
            Assert.IsFalse(File.Exists(cala));

        }
    }
}