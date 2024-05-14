using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDane
{
    [TestClass]
    public class PlanszaTest
    {
        [TestMethod]
        public void TestPlanszaSetGet()
        {
            Dane.Plansza plansza = new Dane.Plansza();
            plansza.W = 1;
            plansza.H = 2;
            plansza.BT = 3;

            Assert.AreEqual(1, plansza.W);
            Assert.AreEqual(2, plansza.H);
            Assert.AreEqual(3, plansza.BT);
        }
    }
}