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
            if(this.lista.ElementAt(i).Nadany_Wektor == false) {
                this.lista.ElementAt(i).Nadany_Wektor = true;
                this.lista.ElementAt(i).Wektor_X = rand.Next(-1, 2);
                this.lista.ElementAt(i).Wektor_Y = rand.Next(-1, 2);
            }
            while(this.lista.ElementAt(i).Wektor_Y == 0 && this.lista.ElementAt(i).Wektor_X == 0)
            {
                this.lista.ElementAt(i).Wektor_X = rand.Next(-1,2);
                this.lista.ElementAt(i).Wektor_Y = rand.Next(-1,2);
            }
            if (this.lista.ElementAt(i).X <= x1 || this.lista.ElementAt(i).X >= x2)
                this.lista.ElementAt(i).Wektor_X *= -1;
            if (this.lista.ElementAt(i).Y <= y1 || this.lista.ElementAt(i).Y >= y2)
                this.lista.ElementAt(i).Wektor_Y *= -1;
            float ruchx = this.lista.ElementAt(i).Wektor_X * this.lista.ElementAt(i).Predkosc / this.lista.ElementAt(i).Waga;
            float ruchy = this.lista.ElementAt(i).Wektor_Y * this.lista.ElementAt(i).Predkosc / this.lista.ElementAt(i).Waga;
            //this.lista.ElementAt(i).Y += ruchx;
            //this.lista.ElementAt(i).X += ruchy;
            this.lista.ElementAt(i).Y += ruchy;
            this.lista.ElementAt(i).X += ruchx;


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
