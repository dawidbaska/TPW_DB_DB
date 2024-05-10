using Dane;
using System.Diagnostics;

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
   

            int xwektor = 0;
            int ywektor = 0;

            xwektor = rand.Next(-3, 4);
            if(xwektor == 0)
            {
                do
                {
                    ywektor = rand.Next(-3, 4);
                } while(ywektor != 0);
                
            } else
            ywektor = rand.Next(-3, 4);
            if (xwektor == ywektor)
            {
                xwektor = 1;
                ywektor = 1;
            }

            do
            {
                x = x + xwektor;
                y = y + ywektor;
                if (x == x1 || x == x2)
                    xwektor = xwektor * (-1);
                if (y == y1 || y == y2)
                    ywektor = ywektor * (-1);

            } while (x < x1 || x > x2 || y < y1 || y > y2);
        }

        public override void LosujStart(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            this.lista.ElementAt(i).X = rand.Next(x1,x2);
            this.lista.ElementAt(i).Y = rand.Next(y1, y2);
        }

        public override void DodajKula()
        {
            this.lista.Add(daneapi.KulaStworz());
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

        public override Plansza StworzPlansze(int w, int h)
        {
            Dane.Plansza plansza = new Dane.Plansza();
            plansza.W = w;
            plansza.H = h;
            return plansza;
        }
    }
}
