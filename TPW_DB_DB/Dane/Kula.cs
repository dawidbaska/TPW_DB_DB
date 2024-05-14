using System.ComponentModel;

namespace Dane
{
    public class Kula : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double predkosc;
        private int srednica;
        private double waga;
        private double wektor_x;
        private double wektor_y;
        private bool nadany_wektor = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
        public double Wektor_Y { get => wektor_y; set => wektor_y = value; }
        public double Wektor_X { get => wektor_x; set => wektor_x = value; }
        public bool Nadany_Wektor { get => nadany_wektor; set => nadany_wektor=value; }
        public double Predkosc { get => predkosc; set => predkosc = value; }
        public int Srednica { get => srednica; set => srednica = value; }
        public double Waga { get => waga; set => waga = value; }

        public Kula(double predkosc, int srednica, double waga)
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
