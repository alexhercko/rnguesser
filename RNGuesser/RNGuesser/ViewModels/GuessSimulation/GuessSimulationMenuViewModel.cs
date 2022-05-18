﻿using RNGuesser.Core;
using RNGuesser.Models;
using System;
using System.Collections.Generic;
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
        }

        private async Task StartSimulationAsync(object parameter)
        {
            ButtonStatus = "Simulation running...";
            GuessSimulationModel guessSimulation = new GuessSimulationModel();
            ResultStatisticsModel resultStatistic = await guessSimulation.RunSimulation(Low, High, Attempts, Amount);

            containerViewModel.CurrentViewModel = new GuessSimulationResultsViewModel(resultStatistic);
        }
    }
}