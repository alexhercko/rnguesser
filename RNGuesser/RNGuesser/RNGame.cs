using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNGuesser.Enums;

namespace RNGuesser
{
    public class RNGame
    {
        public int Low { get; }
        public int CurrentLow { get; set; }
        public int High { get; }
        public int CurrentHigh { get; set; }
        public int MaxAttempts { get; }
        public int CurrentAttempts { get; set; }
        public int GeneratedNumber { get; set; }

        private Random random;
        private const int StartingAttempt = 1;

        public RNGame(int low, int high, int maxAttempts)
        {
            Low = low;
            CurrentLow = low;
            High = high;
            CurrentHigh = high;
            MaxAttempts = maxAttempts;
            CurrentAttempts = StartingAttempt;

            random = new Random();
            GeneratedNumber = random.Next(Low, High);
        }

        public GuessResult Play(int guess)
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
            CurrentAttempts = StartingAttempt;
            GeneratedNumber = random.Next(Low, High);
        }
    }
}
