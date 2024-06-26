﻿using Dane;
using Logika;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.Model
{
    internal class ModelKula 
    {
        private int ilekul = 1;
        private Logika.LogikaAPI logika;
        private Dane.Plansza plansza;
        private CancellationTokenSource cancellationTokenSource;

        public int Ile { get => ilekul; set => ilekul = value; }
        public int Width { get => plansza.W; set => plansza.W = value; }
        public int Height { get => plansza.H; set => plansza.H = value; }
        public int BorderThickness { get => plansza.BT; set => plansza.BT = value; }
       



        public ModelKula(LogikaAPI logika)
        {
            this.logika = logika;
            this.plansza = this.logika.StworzPlansze(600, 300, 4);
        }

        public void logger_start()
        {
            DateTime data_czas = DateTime.Now;
            string data_czas_string = data_czas.ToString("yyyy-MM-dd_HH-mm-ss");
            string nazwaPliku = $"{data_czas_string}.json";
            this.logika.stworzLogger(nazwaPliku);
        }

        public void tworzenie(ObservableCollection<Dane.Kula> KulePositions)
        {
            logger_start();
            this.cancellationTokenSource = new CancellationTokenSource();
            var rand = new Random();
            int srednica = 20;
            logika.ListaClear();
            for(int i=0; i<this.ilekul; i++) {
                double predkosc = rand.Next(4,6);
                double waga = 1;
                this.logika.DodajKula(predkosc, srednica, waga);
                KulePositions.Add(this.logika.GetKula(i));
                int r = this.logika.GetKula(i).Srednica;
                this.logika.LosujStart(0, plansza.W - r - 2 * this.BorderThickness + 1, 0, plansza.H - r - 2 * this.BorderThickness + 1, i);
                int numer = i;
                Task task = Task.Run(async () =>
                {
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        this.ruch(numer);
                        await Task.Delay(50);  
                    }
                });
            }
        }

        public void ruch(int i)
        {
            int r = this.logika.GetKula(i).Srednica;
            this.logika.LosujNowaPozycja(0, plansza.W - r - 2 * this.BorderThickness + 1, 0, plansza.H - r - 2 * this.BorderThickness + 1, i);
        }

        public int listaSize()
        {
            return this.logika.ListaGetSize();
        }

        public Dane.Kula getKula(int i)
        {
            Dane.Kula kula = this.logika.GetKula(i);
            return kula;
        }

        public async Task ZabijWszystkieWatki()
        {
            cancellationTokenSource.Cancel();
        }
    }

   
}
