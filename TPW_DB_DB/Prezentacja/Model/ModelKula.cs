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
        

        public int Ile { get => ilekul; set => ilekul = value; }
        

        public ModelKula(LogikaAPI logika)
        {
            this.logika = logika;
        }

        public void tworzenie()
        {
            logika.ListaClear();
            for(int i=0; i<this.ilekul; i++) {
                this.logika.DodajKula();
                this.logika.LosujStart(20, 580, 20, 280, i);
            }
        }

        public void ruch()
        {
            for (int i = 0; i < this.ilekul; i++)
            {
                int przesuniecie = 20;
                this.logika.LosujNowaPozycja(20, 580, 20,280, i);
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
