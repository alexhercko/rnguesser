using RNGuesser.ViewModels.RNGuess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RNGuesser.Views.Controls.RNGuess
{
    /// <summary>
    /// Interaction logic for RNGuessContainerControlView.xaml
    /// </summary>
    public partial class RNGuessContainerControlView : UserControl
    {
        public RNGuessContainerControlView()
        {
            InitializeComponent();
            DataContext = new RNGuessContainerViewModel();
        }
    }
}
