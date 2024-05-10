using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class LogikaAPI
    {
        public abstract void LosujNowaPozycja(int x1, int x2, int y1, int y2, int i);
        public abstract void LosujStart(int x1, int x2, int y1, int y2, int i);
        public abstract void DodajKula(float predkosc, int srednica, float waga);
        public abstract Dane.Kula GetKula(int i);
        public abstract int ListaGetSize();
        public abstract void ListaClear();
        public static LogikaAPI Stworz(DaneAPI dataApi = default!)
        {
            return new Logika(dataApi);
        }
        public abstract Dane.Plansza StworzPlansze(int w, int h, int bt);
    }
}
