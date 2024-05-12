using System.ComponentModel;

namespace Dane
{
    public class Kula : INotifyPropertyChanged
    {
        private float x;
        private float y;
        private float predkosc;
        private int srednica;
        private float waga;
        private int wektor_x;
        private int wektor_y;
        private bool nadany_wektor = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        public float X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }
        public float Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
