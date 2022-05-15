using RNGuesser.Core;
using RNGuesser.ViewModels.Enums;
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
            MainControls control = (MainControls)param;

            switch (control)
            {
                case MainControls.RNGame:
                    CurrentControl = new RNGameContainerControlView();
                    break;
                case MainControls.RNGuess:
                    CurrentControl = new RNGuessContainerControlView();
                    break;
            }
        }
    }
}
