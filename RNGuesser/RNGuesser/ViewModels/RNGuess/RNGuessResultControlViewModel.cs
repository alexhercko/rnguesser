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

        // TODO: should be moved to RNGuessResultModel
        private bool _usedRandomGuess;

        public bool UsedRandomGuess
        {
            get { return _usedRandomGuess; }
            set
            {
                _usedRandomGuess = value;
                OnPropertyChanged();
            }
        }

        private bool _usedCustomGuess;

        public bool UsedCustomGuess
        {
            get { return _usedCustomGuess; }
            set
            {
                _usedCustomGuess = value;
                OnPropertyChanged();
            }
        }

        private readonly RNGuessContainerControlViewModel rnguessContainerControlViewModel;

        // TODO: ctor should take RNGuessResultModel in the future
        public RNGuessResultControlViewModel(RNGuessModel rnguess, RNGuessContainerControlViewModel rnguessContainerControlViewModel, bool usedCustomGuess, bool usedRandomGuess)
        {
            RNGuess = rnguess;
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
            PlayAgainCommand = new RelayCommand(PlayAgain);

            UsedRandomGuess = usedRandomGuess;
            UsedCustomGuess = usedCustomGuess;

            SetResultDescription();
            SetResult();
        }

        private void SetResultDescription()
        {
            switch (RNGuess.FinalGuessResult)
            {
                case GuessResult.Loss:
                    ResultDescription = "The number was not guessed.";
                    break;
                case GuessResult.Equal:
                    ResultDescription = "The number was sucessfully guessed.";
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
                Result = $"between <{RNGuess.CurrentLow} and {RNGuess.CurrentHigh}>";
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
