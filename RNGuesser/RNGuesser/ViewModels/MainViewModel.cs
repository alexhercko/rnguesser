using RNGuesser.Core;
using RNGuesser.ViewModels.Enums;
using RNGuesser.Views.Controls.GuessSimulation;
using RNGuesser.Views.Controls.ResultStatistics;
using RNGuesser.Views.Controls.RNGame;
using RNGuesser.Views.Controls.RNGuess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RNGuesser.ViewModels
{
    public class MainViewModel : ObservableObject, IViewModel
    {
        private UserControl _currentControl;

        public UserControl CurrentControl
        {
            get { return _currentControl; }
            set
            {
                _currentControl = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ChangeViewCommand { get; set; }

        public MainViewModel()
        {
            CurrentControl = new RNGameContainerControlView();
            ChangeViewCommand = new RelayCommand(ChangeView);   
        }

        private void ChangeView(object param)
        {
            ViewModel control = (ViewModel)param;

            switch (control)
            {
                case ViewModel.RNGame:
                    CurrentControl = new RNGameContainerControlView();
                    break;
                case ViewModel.RNGuess:
                    CurrentControl = new RNGuessContainerControlView();
                    break;
                case ViewModel.ResultStatistics:
                    CurrentControl = new ResultStatisticsContainerControlView();
                    break;
                case ViewModel.GuessSimulation:
                    CurrentControl = new GuessSimulationContainerControlView();
                    break;
            }
        }
    }
}
