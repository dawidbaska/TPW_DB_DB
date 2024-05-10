using Dane;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Logika
{
    public class Logika : LogikaAPI
    {
        private List<Dane.Kula> lista = new List<Dane.Kula> { };
        private Dane.DaneAPI daneapi;

        public Logika(DaneAPI daneapi)
        {
            this.daneapi = daneapi;
        }

        


        public override void LosujNowaPozycja(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            int x = 0;
            int y = 0;
            int orgX = 0;
            int orgY = 0;

            int xwektor = -1;
            int ywektor = 1;

            orgX = this.lista.ElementAt(i).X;
            orgY = this.lista.ElementAt(i).Y;
            x = orgX + xwektor;
            y = orgY + ywektor;
            Debug.WriteLine(x1);
            Debug.WriteLine("x");
            Debug.WriteLine(x);

            if (x == x1 || x == x2)
                xwektor = xwektor * (-1);

            if (y == y1 || y == y2)
                xwektor = ywektor * (-1);
            this.lista.ElementAt(i).X = x;
            this.lista.ElementAt(i).Y = y;
     
        }

        public override void LosujStart(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            this.lista.ElementAt(i).X = rand.Next(x1,x2);
            this.lista.ElementAt(i).Y = rand.Next(y1, y2);
        }

        public override void DodajKula(float predkosc, int srednica, float waga)
        {
            this.lista.Add(daneapi.KulaStworz(predkosc, srednica, waga));
        }

        public override Dane.Kula GetKula(int i)
        {
            Dane.Kula kula = this.lista.ElementAt(i);
            return kula;
        }

        public override int ListaGetSize()
        {
            return this.lista.Count;
        }

        public override void ListaClear()
        {
            this.lista.Clear();
        }

        public override Plansza StworzPlansze(int w, int h, int bt)
        {
            Dane.Plansza plansza = new Dane.Plansza();
            plansza.W = w;
            plansza.H = h;
            plansza.BT = bt;
            return plansza;
        }
    }
}
