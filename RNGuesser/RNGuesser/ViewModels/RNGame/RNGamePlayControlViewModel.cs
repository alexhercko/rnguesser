using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.RNGame
{
    public class RNGamePlayControlViewModel : ObservableObject, IViewModel
    {
        private string _guess = "";

        public string Guess
        {
            get { return _guess; }
            set
            {
                _guess = value;
                OnPropertyChanged();
            }
        }

        private string _resultMessage;

        public string ResultMessage
        {
            get { return _resultMessage; }
            set {
                _resultMessage = value;
                OnPropertyChanged();
            }
        }

        private string _resultSymbol;

        public string ResultSymbol
        {
            get { return _resultSymbol; }
            set
            {
                _resultSymbol = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand EnterCommand { get; set; }
        public RelayCommand PlayAgainCommand { get; set; }

        public RNGameModel RNGame { get; set; }

        private bool canPlayAgain = false;

        public RNGamePlayControlViewModel(int low, int high, int attempts)
        {
            EnterCommand = new RelayCommand(EnterGuess, o => !canPlayAgain);
            PlayAgainCommand = new RelayCommand(PlayAgain, o => canPlayAgain);

            RNGame = new RNGameModel(low, high, attempts);

            ResultMessage = "Start playing";
        }

        private void EnterGuess(object param)
        {
            if (!int.TryParse(Guess, out int guessNumber))
            {
                Guess = "";
                ResultMessage = "You must enter a number!";
                return;
            }

            Guess = "";
            GuessResult guessResult = RNGame.GetNextResult(guessNumber);

            switch (guessResult)
            {
                case GuessResult.MissedRange:
                    ResultMessage = $"Your guess cannot be outside of the range <{RNGame.CurrentLow}, {RNGame.CurrentHigh}>";
                    ResultSymbol = "!";
                    break;
                case GuessResult.Equal:
                    ResultMessage = $"Victory! The number was {RNGame.GeneratedNumber}.";
                    ResultSymbol = "✓";
                    canPlayAgain = true;
                    break;
                case GuessResult.Loss:
                    ResultMessage = $"You lose! The number was {RNGame.GeneratedNumber}.";
                    ResultSymbol = "⨯";
                    canPlayAgain = true;
                    break;
                case GuessResult.Less:
                    ResultMessage = $"The number is less than {guessNumber}!";
                    ResultSymbol = "<";
                    break;
                case GuessResult.Greater:
                    ResultMessage = $"The number is greater than {guessNumber}!";
                    ResultSymbol = ">";
                    break;
            }
        }

        private void PlayAgain(object param)
        {
            RNGame.ResetGame();
            canPlayAgain = false;
            Guess = "";
            ResultMessage = "Start playing";
        }
    }
}
