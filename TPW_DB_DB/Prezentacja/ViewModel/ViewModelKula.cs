using Dane;
using Prezentacja.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Prezentacja.ViewModel
{
    internal class ViewModelKula : INotifyPropertyChanged
    {
        private DispatcherTimer timer;
        
        public Start Button { get; set; }
        public ObservableCollection<Dane.Kula> KulePositions { get; set; }

        public ViewModelKula()
        {
            KulePositions = new ObservableCollection<Dane.Kula>();
            Button = new Start(this);
        }

        public ModelKula ModelKula = new ModelKula(Logika.LogikaAPI.Stworz(Dane.DaneAPI.Stworz()));

        public int iKul
        {
            get { return ModelKula.Ile; }
            set
            {
                ModelKula.Ile = value;
                OnPropertyChanged(nameof(iKul));
            }
        }


        public void StartGry()
        {
            ModelKula.tworzenie();
            KulePositions.Clear();
            for (int i = 0; i < iKul; i++)
            {
                Dane.Kula kula = ModelKula.getKula(i);
                KulePositions.Add(kula);
            }
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(50); 
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ModelKula.listaSize() == iKul)
            {
                RuchKul();
            }
        }

        public void RuchKul()
        {
            ModelKula.ruch();
            KulePositions.Clear();
            for (int i = 0; i < ModelKula.Ile; i++)
            {
                Dane.Kula kula = ModelKula.getKula(i);
                KulePositions.Add(kula);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
