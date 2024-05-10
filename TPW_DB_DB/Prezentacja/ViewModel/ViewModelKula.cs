﻿using Dane;
using Prezentacja.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Prezentacja.ViewModel
{
    internal class ViewModelKula : INotifyPropertyChanged
    {
        public Start Button { get; set; }
        public ObservableCollection<Dane.Kula> KulePositions { get; set; }
        public ModelKula ModelKula = new ModelKula(Logika.LogikaAPI.Stworz(Dane.DaneAPI.Stworz()));
        public Dane.Plansza plansza;

        public ViewModelKula()
        {
            KulePositions = new ObservableCollection<Dane.Kula>();
            Button = new Start(this);
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
            ModelKula.tworzenie();
            while (true)
            {
                await Task.Delay(50);
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
