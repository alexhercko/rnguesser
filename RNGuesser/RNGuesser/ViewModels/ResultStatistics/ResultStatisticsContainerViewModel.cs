using RNGuesser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.ResultStatistics
{
    public class ResultStatisticsContainerViewModel : ObservableObject
    {
        private IViewModel _currentViewModel;

        public IViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ResultStatisticsContainerViewModel()
        {
            CurrentViewModel = new ResultStatisticsMenuViewModel(this);
        }
    }
}
