namespace Dane
{
    public class Kula 
    {
        private int x;
        private int y;
        private float predkosc;
        private int srednica;
        private float waga;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public float Predkosc { get => predkosc; set => predkosc = value; }
        public int Srednica { get => srednica; set => srednica = value; }
        public float Waga { get => waga; set => waga = value; }

        public Kula(float predkosc, int srednica, float waga)
        {
            this.predkosc = predkosc;
            this.srednica = srednica;
            this.waga = waga;
        }
    }

}
