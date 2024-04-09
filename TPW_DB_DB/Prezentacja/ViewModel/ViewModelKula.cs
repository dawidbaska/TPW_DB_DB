using Prezentacja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Prezentacja.ViewModel
{
    internal class ViewModelKula : INotifyPropertyChanged
    {

        private DispatcherTimer timer;

        public Button Button { get; set; }
        public ObservableCollection<Dane.Kula> KulePositions { get; set; }

        public ViewModelKula()
        {
            KulePositions = new ObservableCollection<Dane.Kula>();
            this.Button = new Button(this);
        }


        public ModelKula ModelKula = new ModelKula();

        public int iKul
        {
            get
            {
                return ModelKula.Ile;
            }
            set
            {
                ModelKula.Ile = value;
                OnPropertyChanged(nameof(iKul));
                
            }
        }

        public void Mess()
        {
            ModelKula.tworzenie(); 
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


        public event PropertyChangedEventHandler? PropertyChanged;

        
    }
}
