using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class GuessSimulationModel
    {
        public Task<ResultStatisticsModel> RunSimulation(int low, int high, int attempts, int amount) => Task.Run(() =>
        {
            RNGameModel RNGame = new RNGameModel(low, high, attempts);
            RNGuessModel RNGuess = new RNGuessModel(low, high, attempts);

            ResultStatisticsModel resultStatistic = new ResultStatisticsModel()
            {
                Low = low,
                High = high,
                Attempts = attempts,
                UsedCustomGuess = false,
                UsedRandomGuess = false
            };

            for (int i = 0; i < amount; i++)
            {
                GuessResult currentGuessResult;

                do
                {
                    int guess = RNGuess.GuessedNumber;

                    currentGuessResult = RNGame.GetNextResult(guess);

                    RNGuess.SetGuess(currentGuessResult);
                }
                while (currentGuessResult != GuessResult.Equal && currentGuessResult != GuessResult.Loss);

                resultStatistic.TotalGuesses++;
                resultStatistic.SuccessfulGuesses += RNGuess.FinalGuessResult == GuessResult.Equal ? 1 : 0;

                RNGame.ResetGame();
                RNGuess.ResetGuess();
            }

            return resultStatistic;
        });

        public async Task<ResultStatisticsModel> RunParallelSimulations(int low, int high, int attempts, int amount, int tasks)
        {
            int amountPerTask = amount / tasks;

            List<Task<ResultStatisticsModel>> simulationTasks = new List<Task<ResultStatisticsModel>>();

            for (int task = 0; task < tasks; task++)
            {
                if (task == tasks - 1)
                {
                    amountPerTask = amount;
                }

                Task<ResultStatisticsModel> currentTask = RunSimulation(low, high, attempts, amountPerTask);
                simulationTasks.Add(currentTask);
                amount -= amountPerTask;
            }

            List<ResultStatisticsModel> resultStatistics = (await Task.WhenAll(simulationTasks)).ToList();

            ResultStatisticsModel finalStatistic = new ResultStatisticsModel()
            {
                Low = low,
                High = high,
                Attempts = attempts,
                UsedCustomGuess = false,
                UsedRandomGuess = false
            };

            foreach (ResultStatisticsModel resultStatistic in resultStatistics)
            {
                finalStatistic.TotalGuesses += resultStatistic.TotalGuesses;
                finalStatistic.SuccessfulGuesses += resultStatistic.SuccessfulGuesses;
            }

            finalStatistic.SuccessRate = (float)finalStatistic.SuccessfulGuesses / finalStatistic.TotalGuesses * 100;

            return finalStatistic;
        }
    }
}
