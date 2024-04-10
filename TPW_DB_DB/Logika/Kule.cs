using System.Diagnostics;

namespace Logika
{
    public class Kule 
    {
        private List<Dane.Kula> lista = new List<Dane.Kula> { };

        public void LosujNowaPozycja(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            int x = 0;
            int y = 0;
            int orgX = 0;
            int orgY = 0;
            do
            {
                x = rand.Next(-1, 2);
                y = rand.Next(-1, 2);
                orgX = this.lista.ElementAt(i).X;
                orgY = this.lista.ElementAt(i).Y;
            } while ((orgX - x >= x2 || orgX - x < x1) || (orgY - y >= y2 || orgY - y < y1));
                this.lista.ElementAt(i).X -= x;
            this.lista.ElementAt(i).Y -= y;
        }

        public void LosujStart(int x1, int x2, int y1, int y2, int i)
        {
            var rand = new Random();
            this.lista.ElementAt(i).X = rand.Next(x1,x2);
            this.lista.ElementAt(i).Y = rand.Next(y1, y2);
        }

        public void DodajKula()
        {
            this.lista.Add(new Dane.Kula());
        }

        public Dane.Kula GetKula(int i)
        {
            Dane.Kula copy = this.lista.ElementAt(i);
            return copy;
        }

        public int ListaGetSize()
        {
            return this.lista.Count;
        }

        public void ListaClear()
        {
            this.lista.Clear();
        }
    }
}
