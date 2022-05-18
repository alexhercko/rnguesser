using RNGuesser.Core;
using RNGuesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.ResultStatistics
{
    public class ResultStatisticsMenuViewModel : ObservableObject, IViewModel
    {
        private string _buttonStatus = "Load statistics";

        public string ButtonStatus
        {
            get { return _buttonStatus; }
            set
            {
                _buttonStatus = value;
                OnPropertyChanged();
            }
        }

        public RelayCommandAsync ShowStatisticsCommandAsync { get; set; }

        private readonly ResultStatisticsContainerViewModel containerViewModel;

        public ResultStatisticsMenuViewModel(ResultStatisticsContainerViewModel resultStatisticsContainerViewModel)
        {
            // TODO: consider this naming convention for all view models
            containerViewModel = resultStatisticsContainerViewModel;
            ShowStatisticsCommandAsync = new RelayCommandAsync(ShowStatistics, o => !ShowStatisticsCommandAsync.RunningTasks.Any());
        }

        private async Task ShowStatistics(object param)
        {
            ButtonStatus = "Loading...";

            RNGuessResultSerializer guessResultSaving = new RNGuessResultSerializer();
            List<RNGuessResultModel> guessResults = await guessResultSaving.LoadResults();


            ResultAnalyzer resultAnalyzer = new ResultAnalyzer();
            var resultStatistics = (await resultAnalyzer.GetResultStatistics(guessResults))
                                    .OrderByDescending(statistic => statistic.SuccessRate)
                                    .ToList();

            containerViewModel.CurrentViewModel = new ResultStatisticsViewModel(resultStatistics);
        }
    }
}
