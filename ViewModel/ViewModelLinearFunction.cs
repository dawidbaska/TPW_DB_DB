using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW_DB_DB.ViewModel
{
    using Model;
    using System.Windows.Input;

    public class ViewModelLinearFunction : INotifyPropertyChanged {
        private ModelLinearFunction funkcja = new ModelLinearFunction();

        public double wspA
        {
            get {
                return funkcja.a;
            }
            set {
                funkcja.a = value;
                OnPropertyChanged(nameof(wspA));
                OnPropertyChanged(nameof(wynik));
            }
        }

        public double wspB
        {
            get
            {
                return funkcja.b;
            }
            set
            {
                funkcja.b = value;
                OnPropertyChanged(nameof(wspB));
                OnPropertyChanged(nameof(wynik));
            }
        }

        public double wynik
        {
            get
            {
                return funkcja.FindZero();
            }

            set
            {
                
            }
        }


        public ViewModelLinearFunction()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) { 
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
