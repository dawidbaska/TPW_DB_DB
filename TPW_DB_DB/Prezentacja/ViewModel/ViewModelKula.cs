using Dane;
using Prezentacja.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace Prezentacja.ViewModel
{
    internal class ViewModelKula : INotifyPropertyChanged
    {
        public Start Button { get; set; }
        public Stop Button2 { get; set; }
        public ObservableCollection<Dane.Kula> KulePositions { get; set; }
        public ModelKula ModelKula = new ModelKula(Logika.LogikaAPI.Stworz(Dane.DaneAPI.Stworz()));
        public Dane.Plansza plansza;

        public ViewModelKula()
        {
            KulePositions = new ObservableCollection<Dane.Kula>();
            Button = new Start(this);
            Button2 = new Stop(this);
        }

        public int iKul
        {
            get { return ModelKula.Ile; }
            set
            {
                ModelKula.Ile = value;
                OnPropertyChanged(nameof(iKul));
            }
        }

        public int Width
        {
            get { return ModelKula.Width; }
            set
            {
                ModelKula.Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get { return ModelKula.Height; }
            set
            {
                ModelKula.Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public int BorderT
        {
            get { return ModelKula.BorderThickness; }
            set
            {
                ModelKula.BorderThickness = value;
                OnPropertyChanged(nameof(BorderT));
            }
        }

        public async void StartGry()
        {
            KulePositions.Clear();
            ModelKula.tworzenie(this.KulePositions);
        }

        public async void Stop()
        {
            this.KulePositions.Clear();
            ModelKula.ZabijWszystkieWatki();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
