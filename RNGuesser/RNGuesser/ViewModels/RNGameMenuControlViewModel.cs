using RNGuesser.Core;
using RNGuesser.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels
{
    public class RNGameMenuControlViewModel : ObservableObject, IViewModel
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }

        public RelayCommand StartPlayingCommand { get; set; }
        private readonly RNGameControlViewModel rngameControlViewModel;

        public RNGameMenuControlViewModel(RNGameControlViewModel rngameControlViewModel)
        {
            StartPlayingCommand = new RelayCommand(StartPlaying);
            this.rngameControlViewModel = rngameControlViewModel;
        }

        private void StartPlaying(object param)
        {
            RNGamePlayControlViewModel rngGamePlayVm = new RNGamePlayControlViewModel(Low, High, Attempts);
            rngameControlViewModel.CurrentViewModel = rngGamePlayVm;
        }
    }
}
