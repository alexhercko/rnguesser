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

        private string _resultDescription;

        public string ResultDescription
        {
            get { return _resultDescription; }
            set
            {
                _resultDescription = value;
                OnPropertyChanged();
            }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        public RNGuessResultControlViewModel(RNGuessModel rnguess, RNGuessContainerControlViewModel rnguessContainerControlViewModel)
        {
            RNGuess = rnguess;
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
            PlayAgainCommand = new RelayCommand(PlayAgain);

            SetResultDescription();
            SetResult();
        }

        private void SetResultDescription()
        {
            switch (RNGuess.FinalGuessResult)
            {
                case GuessResult.Loss:
                    ResultDescription = $"The number was not guessed in {RNGuess.CurrentAttempts} attempts.";
                    break;
                case GuessResult.Equal:
                    ResultDescription = $"The number was guessed in {RNGuess.CurrentAttempts} out of {RNGuess.MaxAttempts} attempts.";
                    break;
            }
        }

        private void SetResult()
        {
            if (RNGuess.CurrentLow == RNGuess.CurrentHigh)
            {
                Result = $"{RNGuess.CurrentLow}";
            } else
            {
                Result = $"[{RNGuess.CurrentLow}, ..., {RNGuess.CurrentHigh}]";
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
