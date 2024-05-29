using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class DaneImplementacja : DaneAPI
    {
        public override Kula KulaStworz(double predkosc, int srednica, double waga)
        {
            return new Kula(predkosc, srednica, waga);
        }

        public override Logger LoggerStworz(string filePath)
        {
            return new Logger(filePath);
        }

        public override Plansza PlanszaStworz()
        {
            return new Plansza();
        }

    }
}
