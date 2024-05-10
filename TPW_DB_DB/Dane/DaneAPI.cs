using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DaneAPI
    {
        public static DaneAPI Stworz()
        {
            return new DaneImplementacja();
        }
        public abstract Kula KulaStworz(float predkosc, int srednica, float waga);

        public abstract Plansza PlanszaStworz();
    }
    
}
