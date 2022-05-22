using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class ResultStatisticsModel
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Attempts { get; set; }
        public bool UsedCustomGuess { get; set; }
        public bool UsedRandomGuess { get; set; }

        public int TotalGuesses { get; set; }
        public int SuccessfulGuesses { get; set; }

        public float SuccessRate { get; set; }
        public float AverageAttempt { get; set; }
    }
}
