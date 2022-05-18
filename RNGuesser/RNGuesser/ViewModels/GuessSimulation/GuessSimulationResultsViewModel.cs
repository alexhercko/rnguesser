using RNGuesser.Core;
using RNGuesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.GuessSimulation
{
    public class GuessSimulationResultsViewModel : ObservableObject, IViewModel
    {
        public List<ResultStatisticsModel> ResultStatistics { get; set; }


        public GuessSimulationResultsViewModel(ResultStatisticsModel resultStatistic)
        {
            ResultStatistics = new List<ResultStatisticsModel>() { resultStatistic };
        }
    }
}
