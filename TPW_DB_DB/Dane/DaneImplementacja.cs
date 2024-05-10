using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class DaneImplementacja : DaneAPI
    {
        public override Kula KulaStworz(float predkosc, int srednica, float waga)
        {
            return new Kula(predkosc, srednica, waga);
        }

        public override Plansza PlanszaStworz()
        {
            return new Plansza();
        }
    }
}
