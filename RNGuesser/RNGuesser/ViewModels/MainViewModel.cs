using RNGuesser.Core;
using RNGuesser.ViewModels.Enums;
using RNGuesser.Views.Controls;
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
            CurrentControl = new RNGameControlView();
            ChangeViewCommand = new RelayCommand(ChangeView);   
        }

        private void ChangeView(object param)
        {
            MainControls control = (MainControls)param;

            switch (control)
            {
                case MainControls.RNGame:
                    CurrentControl = new RNGameControlView();
                    break;
                case MainControls.RNGuesser:
                    CurrentControl = new RNGuessControlView();
                    break;
            }
        }
    }
}
