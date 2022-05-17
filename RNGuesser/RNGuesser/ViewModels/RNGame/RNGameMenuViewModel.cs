using RNGuesser.Core;
using RNGuesser.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGame
{
    public class RNGameMenuViewModel : ObservableObject, IViewModel
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }

        public RelayCommand StartPlayingCommand { get; set; }
        private readonly RNGameContainerViewModel rngameControlViewModel;

        private bool canStartPlaying => Low < High && Attempts > 0;

        public RNGameMenuViewModel(RNGameContainerViewModel rngameControlViewModel)
        {
            StartPlayingCommand = new RelayCommand(StartPlaying, o => canStartPlaying);
            this.rngameControlViewModel = rngameControlViewModel;
        }

        private void StartPlaying(object param)
        {
            RNGamePlayViewModel rngGamePlayVm = new RNGamePlayViewModel(Low, High, Attempts);
            rngameControlViewModel.CurrentViewModel = rngGamePlayVm;
        }
    }
}
