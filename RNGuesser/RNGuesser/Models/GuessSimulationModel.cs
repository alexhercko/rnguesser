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

            resultStatistic.SuccessRate = (float)resultStatistic.SuccessfulGuesses / resultStatistic.TotalGuesses * 100;
            return resultStatistic;
        });
    }
}
