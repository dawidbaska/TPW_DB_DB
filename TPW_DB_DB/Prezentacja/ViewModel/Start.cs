﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prezentacja.ViewModel
{
    internal class Start : ICommand
    {   
        public ViewModelKula ViewModelKula { get; set; }

        public Start(ViewModelKula viewmodel) { 
            this.ViewModelKula = viewmodel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModelKula.StartGry();
        }
    }
}
