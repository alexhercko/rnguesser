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
    public class RNGuessControlViewModel : ObservableObject, IViewModel
    {
        public RNGuessModel RNGuess { get; set; }

        public RelayCommand SetGuessResultCommand { get; set; }

        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        public RNGuessControlViewModel(RNGuessModel rngGuess, RNGuessContainerControlViewModel rnguessContainerControlViewModel)
        {
            RNGuess = rngGuess;
            SetGuessResultCommand = new RelayCommand(SetGuessResult);

            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
        }

        private void SetGuessResult(object param)
        {
            GuessResult guessResult = (GuessResult)param;

            bool canShowResults = false;
            if (guessResult == GuessResult.Equal)
            {
                canShowResults = true;
            }

            RNGuess.SetGuess(guessResult);

            if (RNGuess.CurrentAttempts == RNGuess.MaxAttempts)
            {
                RNGuessLastAttemptControlViewModel nrguessLastAttemptVm = new RNGuessLastAttemptControlViewModel(RNGuess, rnguessContainerControlViewModel);
                rnguessContainerControlViewModel.CurrentViewModel = nrguessLastAttemptVm;
            } else if (canShowResults)
            {
                RNGuessResultControlViewModel rnguessResultVm = new RNGuessResultControlViewModel(RNGuess, rnguessContainerControlViewModel);
                rnguessContainerControlViewModel.CurrentViewModel = rnguessResultVm;
            }
        }

    }
}
