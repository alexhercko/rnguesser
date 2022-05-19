using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.GuessMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessMenuViewModel : IViewModel
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }

        public bool SaveResultAutomatically { get; set; }

        public ObservableCollection<GuessMethod> GuessMethods { get; set; }

        public GuessMethod SelectedGuessMethod { get; set; } = GuessMethod.BinarySearch;

        public RelayCommand StartPlayingCommand { get; set; }

        private readonly RNGuessContainerViewModel rnguessContainerControlViewModel;

        private bool canStartPlaying => Low < High && Attempts > 0;

        public RNGuessMenuViewModel(RNGuessContainerViewModel rnguessContainerControlViewModel)
        {
            StartPlayingCommand = new RelayCommand(StartPlaying, o => canStartPlaying);
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;

            GuessMethods = new ObservableCollection<GuessMethod>(
                Enum.GetValues(typeof(GuessMethod))
                    .Cast<GuessMethod>()
            );
        }


        private void StartPlaying(object param)
        {
            GuessMethodPicker guessMethodPicker = new GuessMethodPicker();
            IGuessMethod guessMethod = guessMethodPicker.GetGuessMethod(SelectedGuessMethod);

            RNGuessViewModel rnguessVm = new RNGuessViewModel(new RNGuessModel(Low, High, Attempts, guessMethod), SaveResultAutomatically, rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessVm;
        }
    }
}
