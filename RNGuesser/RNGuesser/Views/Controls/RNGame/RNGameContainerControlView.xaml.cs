using RNGuesser.ViewModels.RNGame;
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

namespace RNGuesser.Views.Controls.RNGame
{
    /// <summary>
    /// Interaction logic for RNGameControlView.xaml
    /// </summary>
    public partial class RNGameContainerControlView : UserControl
    {
        public RNGameContainerControlView()
        {
            InitializeComponent();
            DataContext = new RNGameContainerViewModel();
        }
    }
}
