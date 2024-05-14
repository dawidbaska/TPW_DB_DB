using Dane;
using Logika;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.Model
{
    internal class ModelKula 
    {
        private int ilekul = 1;
        private Logika.LogikaAPI logika;
        private Dane.Plansza plansza;
       

        public int Ile { get => ilekul; set => ilekul = value; }
        public int Width { get => plansza.W; set => plansza.W = value; }
        public int Height { get => plansza.H; set => plansza.H = value; }
        public int BorderThickness { get => plansza.BT; set => plansza.BT = value; }
       



        public ModelKula(LogikaAPI logika)
        {
            this.logika = logika;
            this.plansza = this.logika.StworzPlansze(600, 300, 4);

        }

        public void tworzenie(ObservableCollection<Dane.Kula> KulePositions)
        {
            var rand = new Random();
            float predkosc = 1;
            int srednica = 20;
            logika.ListaClear();
            logika.initBarier(this.ilekul);
            for(int i=0; i<this.ilekul; i++) {
                float waga = 1;
                this.logika.DodajKula(predkosc, srednica, waga);
                KulePositions.Add(this.logika.GetKula(i));
                int r = this.logika.GetKula(i).Srednica;
                this.logika.LosujStart(0, plansza.W - r - 2 * this.BorderThickness + 1, 0, plansza.H - r - 2 * this.BorderThickness + 1, i);
                int numer = i;
                Task task = Task.Run(async () =>
                {
                    while (true)
                    {
                        this.ruch(numer);
                        await Task.Delay(50);  
                    }
                });
            }
        }

        public void ruch(int i)
        {
            int r = this.logika.GetKula(i).Srednica;
            this.logika.LosujNowaPozycja(0, plansza.W - r - 2 * this.BorderThickness + 1, 0, plansza.H - r - 2 * this.BorderThickness + 1, i);
        }

        public int listaSize()
        {
            return this.logika.ListaGetSize();
        }

        public Dane.Kula getKula(int i)
        {
            Dane.Kula kula = this.logika.GetKula(i);
            return kula;
        }
    }

   
}
