using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class KuleAPI
    {
        public abstract void LosujNowaPozycja(int x1, int x2, int y1, int y2, int i);
        public abstract void LosujStart(int x1, int x2, int y1, int y2, int i);
        public abstract void DodajKula();
        public abstract Dane.Kula GetKula(int i);
        public abstract int ListaGetSize();
        public abstract void ListaClear();
        public static KuleAPI Create(DaneAPI dataApi = default!)
        {
            return new Kule(dataApi);
        }
    }
}
