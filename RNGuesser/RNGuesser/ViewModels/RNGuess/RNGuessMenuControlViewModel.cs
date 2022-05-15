using RNGuesser.Core;
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
        private readonly RNGuessContainerControlViewModel rnguessControlViewModel;

        public RNGuessMenuControlViewModel(RNGuessContainerControlViewModel rnguessControlViewModel)
        {
            StartPlayingCommand = new RelayCommand(StartPlaying);
            this.rnguessControlViewModel = rnguessControlViewModel;
        }

        private void StartPlaying(object param)
        {
            RNGuessControlViewModel rnguessPlayVm = new RNGuessControlViewModel(Low, High, Attempts);
            rnguessControlViewModel.CurrentViewModel = rnguessPlayVm;
        }
    }
}
