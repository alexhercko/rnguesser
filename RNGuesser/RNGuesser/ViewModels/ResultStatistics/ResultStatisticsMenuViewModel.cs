using RNGuesser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.ResultStatistics
{
    public class ResultStatisticsMenuViewModel : ObservableObject, IViewModel
    {
        public RelayCommand ShowStatisticsCommand { get; set; }

        private readonly ResultStatisticsContainerViewModel containerViewModel;

        public ResultStatisticsMenuViewModel(ResultStatisticsContainerViewModel resultStatisticsContainerViewModel)
        {
            // TODO: consider this naming convention for all view models
            containerViewModel = resultStatisticsContainerViewModel;
            ShowStatisticsCommand = new RelayCommand(ShowStatistics);
        }

        private void ShowStatistics(object param)
        {
            containerViewModel.CurrentViewModel = new ResultStatisticsViewModel();
        }
    }
}
