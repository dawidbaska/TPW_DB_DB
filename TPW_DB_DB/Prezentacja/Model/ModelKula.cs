using Dane;
using Logika;
using System;
using System.Collections.Generic;
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
        


        public ModelKula(LogikaAPI logika)
        {
            this.logika = logika;
            this.plansza = this.logika.StworzPlansze(200, 100);
        }

        public void tworzenie()
        {
            logika.ListaClear();
            for(int i=0; i<this.ilekul; i++) {
                int r = 20;
                this.logika.DodajKula();
                this.logika.LosujStart(r, plansza.W-r, r, plansza.H-r, i);
            }
        }

        public void ruch()
        {
            for (int i = 0; i < this.ilekul; i++)
            {
                int r = 20;
                this.logika.LosujNowaPozycja(r, plansza.W-r, r,plansza.H-r, i);
            }
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
