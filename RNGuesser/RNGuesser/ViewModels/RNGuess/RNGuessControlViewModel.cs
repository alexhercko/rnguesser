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
    public class RNGuessControlViewModel : ObservableObject, IViewModel
    {
        public RNGuessModel RNGuess { get; set; }

        public RelayCommand SetGuessResultCommand { get; set; }

        public RelayCommand GuessRandomlyCommand { get; set; }

        public RelayCommand SetGuessInputCommand { get; set; }

        public int GuessInput { get; set; }

        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        private Visibility _lastAttemptVisibility = Visibility.Hidden;

        public Visibility LastAttemptVisibility
        {
            get { return _lastAttemptVisibility; }
            set
            {
                _lastAttemptVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool usedRandomGuess = false;
        private bool usedCustomGuess = false;

        public RNGuessControlViewModel(RNGuessModel rngGuess, RNGuessContainerControlViewModel rnguessContainerControlViewModel)
        {
            RNGuess = rngGuess;
            SetGuessResultCommand = new RelayCommand(SetGuessResult);

            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;

            GuessRandomlyCommand = new RelayCommand(GuessRandomly, o => LastAttemptVisibility == Visibility.Visible);
            SetGuessInputCommand = new RelayCommand(SetGuessInput, o => LastAttemptVisibility == Visibility.Visible &&
                                                                        GuessInput >= RNGuess.CurrentLow && GuessInput <= RNGuess.CurrentHigh);
        }

        private void SetGuessResult(object param)
        {
            GuessResult guessResult = (GuessResult)param;

            bool canShowResults = guessResult == GuessResult.Equal || RNGuess.CurrentAttempts == RNGuess.MaxAttempts;

            RNGuess.SetGuess(guessResult);

            if (canShowResults)
            {
                RNGuessResultModel rnguessResult = new RNGuessResultModel(RNGuess, usedCustomGuess, usedRandomGuess);
                RNGuessResultControlViewModel rnguessResultVm = new RNGuessResultControlViewModel(rnguessResult, rnguessContainerControlViewModel, RNGuess);
                rnguessContainerControlViewModel.CurrentViewModel = rnguessResultVm;
            }

            if (RNGuess.CurrentAttempts == RNGuess.MaxAttempts)
            {
                LastAttemptVisibility = Visibility.Visible;
            }

        }

        private void GuessRandomly(object param)
        {
            Random random = new Random();
            RNGuess.GuessedNumber = random.Next(RNGuess.CurrentLow, RNGuess.CurrentHigh + 1);
            usedRandomGuess = true;
            usedCustomGuess = false;
        }

        private void SetGuessInput(object param)
        {
            RNGuess.GuessedNumber = GuessInput;
            usedCustomGuess = true;
            usedRandomGuess = false;
        }
    }
}
