using RNGuesser.Core;
using RNGuesser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.ResultStatistics
{
    public class ResultStatisticsViewModel : ObservableObject, IViewModel
    {
        public List<ResultStatisticsModel> ResultStatistics { get; set; }

        public ResultStatisticsViewModel(List<ResultStatisticsModel> resultStatistics)
        {
            ResultStatistics = resultStatistics;
        }
    }
}
