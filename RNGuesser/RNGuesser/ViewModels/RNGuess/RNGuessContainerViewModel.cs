﻿using RNGuesser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessContainerViewModel : ObservableObject, IViewModel
    {
        private IViewModel _currentViewModel;

        public IViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public RNGuessContainerViewModel()
        {
            CurrentViewModel = new RNGuessMenuViewModel(this);
        }
    }
}
