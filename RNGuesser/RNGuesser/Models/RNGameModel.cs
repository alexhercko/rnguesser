using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class RNGameModel
    {
        public int Low { get; }
        public int High { get; }

        public int CurrentLow { get; set; }
        public int CurrentHigh { get; set; }

        public int MaxAttempts { get; }
        public int CurrentAttempts { get; set; }

        public int GeneratedNumber { get; set; }

        private readonly Random random;
        private const int startingAttempt = 1;

        public RNGameModel(int low, int high, int maxAttempts)
        {
            Low = low;
            High = high;

            CurrentLow = low;
            CurrentHigh = high;

            MaxAttempts = maxAttempts;
            CurrentAttempts = startingAttempt;

            random = new Random();
            GeneratedNumber = random.Next(Low, High);
        }

        public GuessResult GetNextResult(int guess)
        {
            if (GeneratedNumber == guess)
            {
                return GuessResult.Equal;
            }
            else if (CurrentAttempts == MaxAttempts)
            {
                return GuessResult.Loss;
            }

            CurrentAttempts++;

            if (GeneratedNumber < guess)
            {
                CurrentHigh = guess;
                return GuessResult.Less;
            }
            else
            {
                CurrentLow = guess;
                return GuessResult.Greater;
            }
        }

        public void ResetGame()
        {
            CurrentAttempts = startingAttempt;
            GeneratedNumber = random.Next(Low, High);
        }
    }
}
