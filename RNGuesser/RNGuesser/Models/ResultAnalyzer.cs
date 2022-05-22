using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class ResultAnalyzer
    {
        public Task<List<ResultStatisticsModel>> GetResultStatistics(List<RNGuessResultModel> rnguessResults) => Task.Run(() =>
        {
            var groupedResults = rnguessResults
                                    .GroupBy(result => new { result.Low, result.High, result.MaxAttempts, result.UsedCustomGuess, result.UsedRandomGuess });

            var resultStatistics = new List<ResultStatisticsModel>();
            foreach (var groupedResult in groupedResults)
            {
                var resultStatistic = new ResultStatisticsModel()
                {
                    Low = groupedResult.Key.Low,
                    High = groupedResult.Key.High,
                    Attempts = groupedResult.Key.MaxAttempts,
                    UsedCustomGuess = groupedResult.Key.UsedCustomGuess,
                    UsedRandomGuess = groupedResult.Key.UsedRandomGuess
                };

                int attemptTotal = 0;
                int attemptCount = 0;

                foreach (RNGuessResultModel result in groupedResult)
                {
                    resultStatistic.TotalGuesses++;
                    resultStatistic.SuccessfulGuesses += result.ResultGuessed ? 1 : 0;

                    attemptTotal += result.FinalAttempts;
                    attemptCount++;
                }

                resultStatistic.SuccessRate = (float)resultStatistic.SuccessfulGuesses / resultStatistic.TotalGuesses * 100;
                resultStatistic.AverageAttempt = (float)attemptTotal / attemptCount;
                resultStatistics.Add(resultStatistic);
            }

            return resultStatistics;
        });
    }
}
