using RNGuesser.Core;
using RNGuesser.Models;
using RNGuesser.Models.GuessMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.ViewModels.GuessSimulation
{
    public class GuessSimulationMenuViewModel : ObservableObject, IViewModel
    {
        private string _buttonStatus = "Start simulation";

        public string ButtonStatus
        {
            get { return _buttonStatus; }
            set
            {
                _buttonStatus = value;
                OnPropertyChanged();
            }
        }

        private int _selectedTaskAmount = 1;

        public int SelectedTaskAmount
        {
            get { return _selectedTaskAmount; }
            set {
                _selectedTaskAmount = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GuessMethod> GuessMethods { get; set; }

        public GuessMethod SelectedGuessMethod { get; set; } = GuessMethod.BinarySearch;

        private readonly IEnumerable<int> _taskAmounts = Enumerable.Range(1, 10);
        public IEnumerable<int> TaskAmounts { get { return _taskAmounts; } }

        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }
        public int Amount { get; set; }

        public RelayCommandAsync StartSimulationCommandAsync { get; set; }

        private readonly GuessSimulationContainerViewModel containerViewModel;

        private bool inputValid => Low < High && Attempts > 0 && Amount > 0;

        public GuessSimulationMenuViewModel(GuessSimulationContainerViewModel containerViewModel)
        {
            this.containerViewModel = containerViewModel;

            StartSimulationCommandAsync = new RelayCommandAsync(StartSimulationAsync, o => inputValid && !StartSimulationCommandAsync.RunningTasks.Any());

            GuessMethods = new ObservableCollection<GuessMethod>(
                Enum.GetValues(typeof(GuessMethod))
                    .Cast<GuessMethod>()
            );
        }

        private async Task StartSimulationAsync(object parameter)
        {
            ButtonStatus = "Simulation running...";
            GuessSimulationModel guessSimulation = new GuessSimulationModel();

            GuessMethodPicker guessMethodPicker = new GuessMethodPicker();
            IGuessMethod guessMethod = guessMethodPicker.GetGuessMethod(SelectedGuessMethod);

            ResultStatisticsModel resultStatistic = await guessSimulation.RunParallelSimulations(Low, High, Attempts, Amount, SelectedTaskAmount, guessMethod);

            containerViewModel.CurrentViewModel = new GuessSimulationResultsViewModel(resultStatistic);
        }
    }
}
