namespace Logika
{
    public class Kule 
    {
        private List<Dane.Kula> lista = new List<Dane.Kula> { };

        public void LosujNowaPozycja(int i)
        {
            var rand = new Random();
            int x1 = rand.Next(-1, 1);
            int y1 = rand.Next(-1, 1);
            int orgX = this.lista.ElementAt(i).X;
            int orgY = this.lista.ElementAt(i).Y;
            this.lista.ElementAt(i).X = orgX - x1;
            this.lista.ElementAt(i).Y = orgY - y1;

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
