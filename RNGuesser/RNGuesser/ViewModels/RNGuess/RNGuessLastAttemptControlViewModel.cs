using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessLastAttemptControlViewModel : ObservableObject, IViewModel
    {
        public RNGuessModel RNGuess { get; set; }

        public int GuessInput { get; set; }

        public RelayCommand GuessRandomlyCommand { get; set; }

        public RelayCommand SetGuessInputCommand { get; set; }

        public RelayCommand SetGuessResultCommand { get; set; }

        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        private bool canGuess = true;

        public RNGuessLastAttemptControlViewModel(RNGuessModel rngGuess, RNGuessContainerControlViewModel rnguessContainerControlViewModel)
        {
            RNGuess = rngGuess;
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;

            GuessRandomlyCommand = new RelayCommand(GuessRandomly, o => canGuess);
            SetGuessInputCommand = new RelayCommand(SetGuessInput, o => canGuess);
            SetGuessResultCommand = new RelayCommand(SetGuessResult);
        }

        private void GuessRandomly(object param)
        {
            Random random = new Random();
            RNGuess.GuessedNumber = random.Next(RNGuess.CurrentLow, RNGuess.CurrentHigh + 1);
            canGuess = false;
        }

        private void SetGuessInput(object param)
        {
            RNGuess.GuessedNumber = GuessInput;
            canGuess = false;
        }

        private void SetGuessResult(object param)
        {
            GuessResult guessResult = (GuessResult)param;
            RNGuess.SetGuess(guessResult);

            RNGuessResultControlViewModel rnguessResultPlayVm = new RNGuessResultControlViewModel(RNGuess, rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessResultPlayVm;
        }
    }
}
