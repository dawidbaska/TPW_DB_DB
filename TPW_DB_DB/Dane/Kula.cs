namespace Dane
{
    public class Kula 
    {
        private int x;
        private int y;
        private float predkosc;
        private int srednica;
        private float waga;
        private int wektor_x;
        private int wektor_y;
        private bool nadany_wektor = false;


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Wektor_Y { get => wektor_y; set => wektor_y = value; }
        public int Wektor_X { get => wektor_x; set => wektor_x = value; }
        public bool Nadany_Wektor { get => nadany_wektor; set => nadany_wektor=value; }
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
