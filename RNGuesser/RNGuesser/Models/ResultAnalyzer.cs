using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class ResultAnalyzer
    {
        public List<ResultStatisticsModel> GetResultStatistics(List<RNGuessResultModel> rnguessResults)
        {
            var groupedResults = rnguessResults
                                    .GroupBy(result => new { result.Low, result.High, result.MaxAttempts, result.UsedCustomGuess, result.UsedRandomGuess });

            var resultStatistics = new List<ResultStatisticsModel>();
            foreach (var groupedResult in groupedResults)
            {
                var resultStatistic = new ResultStatisticsModel();
                resultStatistic.Low = groupedResult.Key.Low;
                resultStatistic.High = groupedResult.Key.High;
                resultStatistic.Attempts = groupedResult.Key.MaxAttempts;
                resultStatistic.UsedCustomGuess = groupedResult.Key.UsedCustomGuess;
                resultStatistic.UsedRandomGuess = groupedResult.Key.UsedRandomGuess;

                foreach (var result in groupedResult)
                {
                    resultStatistic.TotalGuesses++;
                    resultStatistic.SuccessfulGuesses += result.FinalGuessResult == Enums.GuessResult.Equal ? 1 : 0;
                }

                resultStatistic.SuccessRate = (float) resultStatistic.SuccessfulGuesses / resultStatistic.TotalGuesses * 100;
                resultStatistics.Add(resultStatistic);
            }

            return resultStatistics;
        }
    }
}
