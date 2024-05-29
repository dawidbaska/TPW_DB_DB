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
        public abstract Kula KulaStworz(double predkosc, int srednica, double waga);

        public abstract Plansza PlanszaStworz();
        public abstract void LoggerStworz(string filePath);

        public abstract void ZapiszLogi();

        public abstract void DodajLogi(string wiadomosc);

        public abstract void KoniecZapisow();
    }

}
