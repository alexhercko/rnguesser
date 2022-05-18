using RNGuesser.Core;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class RNGameModel : ObservableObject
    {
        public int Low { get; }
        public int High { get; }

        private int _currentLow;

        public int CurrentLow
        {
            get { return _currentLow; }
            set
            {
                _currentLow = value;
                OnPropertyChanged();
            }
        }

        private int _currentHigh;
        public int CurrentHigh
        {
            get { return _currentHigh; }
            set
            {
                _currentHigh = value;
                OnPropertyChanged();
            }
        }

        public int MaxAttempts { get; }

        private const int startingAttempt = 1;

        private int _currentAttempts = startingAttempt;

        public int CurrentAttempts
        {
            get { return _currentAttempts; }
            set
            {
                _currentAttempts = value;
                OnPropertyChanged();
            }
        }

        public int GeneratedNumber { get; set; }

        private readonly Random random;

        public RNGameModel(int low, int high, int maxAttempts)
        {
            Low = low;
            High = high;

            CurrentLow = low;
            CurrentHigh = high;

            MaxAttempts = maxAttempts;
            CurrentAttempts = startingAttempt;

            random = new Random();
            GeneratedNumber = random.Next(Low, High + 1);
        }

        public GuessResult GetNextResult(int guess)
        {
            if (guess < CurrentLow || guess > CurrentHigh)
            {
                return GuessResult.MissedRange;
            }

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
                CurrentHigh = guess - 1;
                return GuessResult.Less;
            }
            else
            {
                CurrentLow = guess + 1;
                return GuessResult.Greater;
            }
        }

        public void ResetGame()
        {
            GeneratedNumber = random.Next(Low, High + 1);
            CurrentAttempts = startingAttempt;
            CurrentLow = Low;
            CurrentHigh = High;
        }
    }
}
