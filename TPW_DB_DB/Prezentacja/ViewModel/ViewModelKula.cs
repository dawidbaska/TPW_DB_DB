using Prezentacja.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Prezentacja.ViewModel
{
    internal class ViewModelKula : INotifyPropertyChanged
    {

        public Button Button { get; set; }
        public ViewModelKula() { 
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
            Debug.WriteLine(this.ModelKula.Ile);
            this.ModelKula.tworzenie();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        
    }
}
