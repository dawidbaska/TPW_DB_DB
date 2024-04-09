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
        private int ilekul = 11;
        private Logika.Kule logika = new Logika.Kule();

        public int Ile { get => ilekul; set => ilekul = value; }

        public void tworzenie()
        {
            logika.ListaClear();
            for(int i=0; i<this.ilekul; i++) {
                this.logika.DodajKula();
                this.logika.LosujStart(10, 200, 25, 50, i);
            }
            Debug.WriteLine(logika.ListaGetSize());
        }

        public void ruch(int j)
        {
            for (int i = 0; i < this.ilekul; i++)
            {
                this.logika.LosujNowaPozycja(j);
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
