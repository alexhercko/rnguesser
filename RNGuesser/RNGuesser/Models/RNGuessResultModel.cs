using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class RNGuessResultModel
    {
        public int Low { get; set; }
        public int High { get; set; }

        public int FinalLow { get; set; }
        public int FinalHigh { get; set; }

        public int MaxAttempts { get; set; }
        public int FinalAttempts { get; set; }

        public GuessResult FinalResult { get; set; }

        public bool UsedCustomGuess { get; set; }
        public bool UsedRandomGuess { get; set; }

        public RNGuessResultModel(RNGuessModel rnguess, bool usedCustomGuess, bool usedRandomGuess)
        {
            Low = rnguess.Low;
            High = rnguess.High;
            FinalLow = rnguess.CurrentLow;
            FinalHigh = rnguess.CurrentHigh;
            MaxAttempts = rnguess.MaxAttempts;
            FinalAttempts = rnguess.CurrentAttempts;
            FinalResult = rnguess.FinalGuessResult;

            UsedCustomGuess = usedCustomGuess;
            UsedRandomGuess = usedRandomGuess;
        }
    }
}
