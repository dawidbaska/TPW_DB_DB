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
        Logika.Kule logika = new Logika.Kule();

        public int Ile { get => ilekul; set => ilekul = value; }

        public void tworzenie()
        {
            logika.ListaClear();
            for(int i=0; i<this.ilekul; i++) {
                this.logika.DodajKula();
            }
            Debug.WriteLine(logika.ListaGetSize());
        }


    }

   
}
