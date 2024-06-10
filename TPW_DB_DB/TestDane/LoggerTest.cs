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
            string wiadomosc = "2024-05-29 10:00:00.000: abcd";
            logger.DodajLogi(wiadomosc);
            logger.zapiszLogi();
            logger.koniecZapisow();

            string logContent = File.ReadAllText(cala);
            Assert.IsTrue(logContent.Contains("\"timestamp\":\"2024-05-29 10:00:00.000\""));
            Assert.IsTrue(logContent.Contains("\"message\":\"abcd\""));

            File.Delete(cala);
            Assert.IsFalse(File.Exists(cala));

        }
    }
}