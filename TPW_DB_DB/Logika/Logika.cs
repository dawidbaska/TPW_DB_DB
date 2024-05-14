using Dane;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;

namespace Logika
{
    public class Logika : LogikaAPI
    {
        private List<Dane.Kula> lista = new List<Dane.Kula> { };
        private Dane.DaneAPI daneapi;
        private Barrier barrier;

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
            double ruchx = this.lista.ElementAt(i).Wektor_X * this.lista.ElementAt(i).Predkosc / this.lista.ElementAt(i).Waga;
            double ruchy = this.lista.ElementAt(i).Wektor_Y * this.lista.ElementAt(i).Predkosc / this.lista.ElementAt(i).Waga;
            if (this.lista.ElementAt(i).Y + ruchy < y1)
                this.lista.ElementAt(i).Y = 0;
            else if(this.lista.ElementAt(i).Y + ruchy > y2)
                this.lista.ElementAt(i).Y = y2;
            else
                this.lista.ElementAt(i).Y += ruchy;
            if (this.lista.ElementAt(i).X + ruchx < x1)
                this.lista.ElementAt(i).X = 0;
            else if (this.lista.ElementAt(i).X + ruchx > x2)
                this.lista.ElementAt(i).X = x2;
            else
                this.lista.ElementAt(i).X += ruchx;
            SprawdzKolizje(i, this.lista);

        }

        public override void SprawdzKolizje(int i, List<Dane.Kula> lista)
        {
            barrier.SignalAndWait();
            lock (lista)
            {
                for(int j = 0; j < lista.Count; j++)
                {
                    if(j == i)
                    {
                        continue;
                    }
                    else
                    {
                      if(Math.Abs(lista.ElementAt(i).X - lista.ElementAt(j).X) <= lista.ElementAt(i).Srednica && Math.Abs(lista.ElementAt(i).Y - lista.ElementAt(j).Y) <= lista.ElementAt(i).Srednica)
                        {
                            double Va = Math.Sqrt((lista.ElementAt(i).Wektor_X * lista.ElementAt(i).Wektor_X) + (lista.ElementAt(i).Wektor_Y*lista.ElementAt(i).Wektor_Y));
                            double Vb = Math.Sqrt((lista.ElementAt(j).Wektor_X * lista.ElementAt(j).Wektor_X) + (lista.ElementAt(j).Wektor_Y * lista.ElementAt(j).Wektor_Y));
                            double sinA = lista.ElementAt(i).Wektor_Y / Va;
                            double cosA = lista.ElementAt(i).Wektor_X / Va;
                            double nowy_wX = (Va * (lista.ElementAt(i).Waga - lista.ElementAt(j).Waga) + 2 * lista.ElementAt(j).Waga * Vb * cosA) / (lista.ElementAt(i).Waga + lista.ElementAt(j).Waga);
                            double nowy_wY = (2 * (lista.ElementAt(i).Waga + lista.ElementAt(j).Waga) * Va * sinA) / (lista.ElementAt(i).Waga + lista.ElementAt(j).Waga);

                       
                            Debug.WriteLine(nowy_wX);
                            Debug.WriteLine(nowy_wY);


                            lista.ElementAt(i).Wektor_X = nowy_wX;
                            lista.ElementAt(i).Wektor_Y = nowy_wY;
                        }
                    }
                }
            }
            barrier.SignalAndWait();
        }

        public override void LosujStart(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            this.lista.ElementAt(i).X = rand.Next(x1,x2);
            this.lista.ElementAt(i).Y = rand.Next(y1, y2);
        }

        public override void DodajKula(double predkosc, int srednica, double waga)
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

        public override void initBarier(int i)
        {
            this.barrier = new Barrier(i);
        }
    }
}
