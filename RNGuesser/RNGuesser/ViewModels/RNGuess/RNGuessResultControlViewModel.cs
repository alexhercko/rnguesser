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
        public RNGuessResultModel RNGuessResult { get; set; }

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
        private readonly RNGuessModel rnguess;

        public RNGuessResultControlViewModel(RNGuessResultModel rnguessResult, RNGuessContainerControlViewModel rnguessContainerControlViewModel, RNGuessModel rnguess)
        {
            RNGuessResult = rnguessResult;
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
            this.rnguess = rnguess;
            PlayAgainCommand = new RelayCommand(PlayAgain);

            SetResultDescription();
            SetResult();
        }

        private void SetResultDescription()
        {
            switch (RNGuessResult.FinalResult)
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
            if (RNGuessResult.FinalLow == RNGuessResult.FinalHigh)
            {
                Result = $"{RNGuessResult.FinalLow}";
            } else
            {
                Result = $"between <{RNGuessResult.FinalLow} and {RNGuessResult.FinalHigh}>";
            }
        }

        private void PlayAgain(object param)
        {
            rnguess.ResetGame();
            //RNGuessModel rnguess = new RNGuessModel(RNGuessResult.Low, RNGuessResult.High, RNGuessResult.MaxAttempts);
            RNGuessControlViewModel rnguessPlayVm = new RNGuessControlViewModel(rnguess, rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessPlayVm;
        }
    }
}
