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
        private int x = 0;
        private int y = 0;

        public int Ile { get => ilekul; set => ilekul = value; }
        public int Ilex { get => x; set => x = value; }
        public int Iley { get => y; set => y = value; }

        public ModelKula(LogikaAPI logika)
        {
            this.logika = logika;
        }

        public void tworzenie()
        {
            logika.ListaClear();
            for(int i=0; i<this.ilekul; i++) {
                this.logika.DodajKula();
                int przesuniecie = 20;
                this.logika.LosujStart(-286, 287, 0 - (przesuniecie * i), 273 - (przesuniecie * i), i);
            }
        }

        public void ruch()
        {
            for (int i = 0; i < this.ilekul; i++)
            {
                int przesuniecie = 20;
                this.logika.LosujNowaPozycja(-286, 287, 0 - (przesuniecie * i), 273 - (przesuniecie * i), i);
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
