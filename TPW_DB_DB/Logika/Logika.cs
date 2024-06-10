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
        private Timer timer;

        public Logika(DaneAPI daneapi)
        {
            this.daneapi = daneapi;
            this.timer = new Timer(ZapiszLogi, null, 10000, 5000);
        }

        public override void LosujNowaPozycja(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            int x = 0;
            int y = 0;
            int orgX = 0;
            int orgY = 0;
            if (this.lista.ElementAt(i).Nadany_Wektor == false)
            {
                this.lista.ElementAt(i).Nadany_Wektor = true;
                this.lista.ElementAt(i).Wektor_X = rand.Next(-1, 2);
                this.lista.ElementAt(i).Wektor_Y = rand.Next(-1, 2);
            }
            while (this.lista.ElementAt(i).Wektor_Y == 0 && this.lista.ElementAt(i).Wektor_X == 0)
            {
                this.lista.ElementAt(i).Wektor_X = rand.Next(-1, 2);
                this.lista.ElementAt(i).Wektor_Y = rand.Next(-1, 2);
            }
            if (this.lista.ElementAt(i).X <= x1 || this.lista.ElementAt(i).X >= x2)
                this.lista.ElementAt(i).Wektor_X *= -1;
            if (this.lista.ElementAt(i).Y <= y1 || this.lista.ElementAt(i).Y >= y2)
                this.lista.ElementAt(i).Wektor_Y *= -1;
            double ruchx = this.lista.ElementAt(i).Wektor_X * this.lista.ElementAt(i).Predkosc / this.lista.ElementAt(i).Waga;
            double ruchy = this.lista.ElementAt(i).Wektor_Y * this.lista.ElementAt(i).Predkosc / this.lista.ElementAt(i).Waga;
            if (this.lista.ElementAt(i).Y + ruchy < y1)
                this.lista.ElementAt(i).Y = 0;
            else if (this.lista.ElementAt(i).Y + ruchy > y2)
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
            lock (lista)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    else
                    {

                        if (Math.Abs(this.lista.ElementAt(i).X - lista.ElementAt(j).X) <= this.lista.ElementAt(i).Srednica && Math.Abs(this.lista.ElementAt(i).Y - lista.ElementAt(j).Y) <= this.lista.ElementAt(i).Srednica)
                        {
                            double dx = lista.ElementAt(j).X - lista.ElementAt(i).X;
                            double dy = lista.ElementAt(j).Y - lista.ElementAt(i).Y;
                            double d = Math.Sqrt(dx * dx + dy * dy);
                            // wektor prostopadly do powierzchnni kolizji 
                            double w_p_X = dx / d;
                            double w_p_Y = dy / d;

                            // liczymy miare rownoleglosci wektorow kuli a b i wektora prostopadlego i sprawdzamy czy kule sa na kursie kolizyjnym >0 tak <0 nie
                            double miara_rowno = (lista.ElementAt(i).Wektor_X - lista.ElementAt(j).Wektor_X) * w_p_X + (lista.ElementAt(i).Wektor_Y - lista.ElementAt(j).Wektor_Y) * w_p_Y;
                            if (miara_rowno > 0)
                            {
                                double zmiana_predkosci = 2 * miara_rowno / (lista.ElementAt(i).Waga + lista.ElementAt(j).Waga);
                                double nowyX = zmiana_predkosci * w_p_X;
                                double nowyY = zmiana_predkosci * w_p_Y;

                                this.lista.ElementAt(i).Wektor_X -= nowyX;
                                this.lista.ElementAt(i).Wektor_Y -= nowyY;
                                this.lista.ElementAt(j).Wektor_X += nowyX;
                                this.lista.ElementAt(j).Wektor_Y += nowyY;
                             
                            }
                        }
                    }
                }
            }
        }

        public override void LosujStart(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            bool flaga = false;
            while (flaga == false)
            {
                flaga = true;
                this.lista.ElementAt(i).X = rand.Next(x1, x2);
                this.lista.ElementAt(i).Y = rand.Next(y1, y2);
                for (int j = 0; j < this.lista.Count; j++)
                {
                    if (i != j)
                    {
                        if (Math.Abs(this.lista.ElementAt(i).X - this.lista.ElementAt(j).X) < 2 * this.lista.ElementAt(i).Srednica && Math.Abs(this.lista.ElementAt(i).Y - this.lista.ElementAt(j).Y) < 2 * this.lista.ElementAt(i).Srednica)
                        {
                            flaga = false;
                        }
                    }
                }
            }
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



        public override void stworzLogger(string filePath)
        {
            this.daneapi.LoggerStworz(filePath);
        }


        public override void ZapiszLogi(object? state)
        {
            DateTime data_czas = DateTime.Now;
            string wiadomosc="";
            string data_czas_string = data_czas.ToString("yyyy-MM-dd_HH-mm-ss");
            for (int i =0; i< this.lista.Count; i++) {
                wiadomosc = $"Kula {i} ruszyla sie na pozycje {this.lista.ElementAt(i).X}; {this.lista.ElementAt(i).Y}";
                this.daneapi.ZapiszLogi(data_czas_string, wiadomosc);
            }
        }

    }
}