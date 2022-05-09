using RNGuesser.Core;
using RNGuesser.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RNGuesser.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private UserControl _currentContent;

        public UserControl CurrentContent
        {
            get { return _currentContent; }
            set {
                _currentContent = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentContent = new RNGameControlView();
        }

    }
}
