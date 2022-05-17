using RNGuesser.Core;
using RNGuesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessMenuViewModel : IViewModel
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }

        public RelayCommand StartPlayingCommand { get; set; }
        private readonly RNGuessContainerViewModel rnguessContainerControlViewModel;

        private bool canStartPlaying => Low < High && Attempts > 0;

        public RNGuessMenuViewModel(RNGuessContainerViewModel rnguessContainerControlViewModel)
        {
            StartPlayingCommand = new RelayCommand(StartPlaying, o => canStartPlaying);
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
        }

        private void StartPlaying(object param)
        {
            RNGuessViewModel rnguessVm = new RNGuessViewModel(new RNGuessModel(Low, High, Attempts), rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessVm;
        }
    }
}
