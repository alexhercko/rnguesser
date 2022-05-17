using Newtonsoft.Json;
using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RNGuesser.ViewModels.RNGuess
{
    public class RNGuessResultViewModel : ObservableObject, IViewModel
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

        private readonly RNGuessContainerViewModel rnguessContainerControlViewModel;
        private readonly RNGuessModel rnguess;

        public RNGuessResultViewModel(RNGuessModel rnguess, bool usedCustomGuess, bool usedRandomGuess,RNGuessContainerViewModel rnguessContainerControlViewModel)
        {
            this.rnguessContainerControlViewModel = rnguessContainerControlViewModel;
            this.rnguess = rnguess;

            RNGuessResult = new RNGuessResultModel() {
                Low = rnguess.Low,
                High = rnguess.High,
                FinalLow = rnguess.CurrentLow,
                FinalHigh = rnguess.CurrentHigh,
                MaxAttempts = rnguess.MaxAttempts,
                FinalAttempts = rnguess.CurrentAttempts,
                FinalGuessResult = rnguess.FinalGuessResult,
                UsedCustomGuess = usedCustomGuess,
                UsedRandomGuess = usedRandomGuess
            };

            PlayAgainCommand = new RelayCommand(PlayAgain);

            SetResultDescription();
            SetResult();

            RNGuessResultSaving rnguessResultSaving = new RNGuessResultSaving();
            rnguessResultSaving.SaveResult(RNGuessResult);
        }

        private void SetResultDescription()
        {
            switch (RNGuessResult.FinalGuessResult)
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
            RNGuessViewModel rnguessPlayVm = new RNGuessViewModel(rnguess, rnguessContainerControlViewModel);
            rnguessContainerControlViewModel.CurrentViewModel = rnguessPlayVm;
        }
    }
}
