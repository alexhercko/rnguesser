using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels
{
    public class RNGuessControlViewModel : ObservableObject, IViewModel
    {
        public RNGuessModel RNGuess { get; set; }

        public RelayCommand SetGuessResultCommand { get; set; }

        public RelayCommand PlayAgainCommand { get; set; }

        private bool canPlayAgain = false;

        public RNGuessControlViewModel(int low, int high, int attempts)
        {
            RNGuess = new RNGuessModel(low, high, attempts);
            SetGuessResultCommand = new RelayCommand(SetGuessResult, o => !canPlayAgain);
            PlayAgainCommand = new RelayCommand(PlayAgain, o => canPlayAgain);
        }

        private void SetGuessResult(object param)
        {
            GuessResult guessResult = (GuessResult)param;

            if (RNGuess.CurrentAttempts == RNGuess.MaxAttempts)
            {
                canPlayAgain = true;
                return;
            }

            if (guessResult == GuessResult.Equal)
            {
                canPlayAgain = true;
            }

            RNGuess.SetGuess(guessResult);
        }

        private void PlayAgain(object param)
        {
            RNGuess.ResetGame();
            canPlayAgain = false;
        }
    }
}
