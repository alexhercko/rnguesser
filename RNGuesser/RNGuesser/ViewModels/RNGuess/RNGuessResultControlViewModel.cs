using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessResultControlViewModel : ObservableObject, IViewModel
    {
        public RNGuessModel RNGuess { get; set; }

        public RelayCommand PlayAgainCommand { get; set; }

        private string _resultString;

        public string ResultString
        {
            get { return _resultString; }
            set
            {
                _resultString = value;
                OnPropertyChanged();
            }
        }


        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        public RNGuessResultControlViewModel(RNGuessModel rnguess, RNGuessContainerControlViewModel rnguessContainerControlViewModel)
        {
            RNGuess = rnguess;
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
            PlayAgainCommand = new RelayCommand(PlayAgain);

            SetResultString();
        }

        private void SetResultString()
        {
            switch (RNGuess.FinalGuessResult)
            {
                case GuessResult.Loss:
                    ResultString = $"The number was not guessed in {RNGuess.CurrentAttempts} attempts.";
                    break;
                case GuessResult.Equal:
                    ResultString = $"The number was guessed in {RNGuess.CurrentAttempts} out of {RNGuess.MaxAttempts} attempts.";
                    break;
            }
        }

        private void PlayAgain(object param)
        {
            RNGuess.ResetGame();
            RNGuessControlViewModel rnguessPlayVm = new RNGuessControlViewModel(RNGuess, rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessPlayVm;
        }
    }
}
