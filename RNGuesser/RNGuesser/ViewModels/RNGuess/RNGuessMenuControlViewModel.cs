﻿using RNGuesser.Core;
using RNGuesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessMenuControlViewModel : IViewModel
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }

        public RelayCommand StartPlayingCommand { get; set; }
        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        public RNGuessMenuControlViewModel(RNGuessContainerControlViewModel rnguessContainerControlViewModel)
        {
            StartPlayingCommand = new RelayCommand(StartPlaying);
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
        }

        private void StartPlaying(object param)
        {
            RNGuessControlViewModel rnguessVm = new RNGuessControlViewModel(new RNGuessModel(Low, High, Attempts), rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessVm;
        }
    }
}