using RNGuesser.Core;
using RNGuesser.Models.Enums;
using RNGuesser.Models.GuessMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class RNGuessModel : ObservableObject
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

        private int _guessedNumber = 0;

        public int GuessedNumber
        {
            get { return _guessedNumber; }
            set
            {
                _guessedNumber = value;
                OnPropertyChanged();
            }
        }

        public GuessResult FinalGuessResult { get; set; }

        private IGuessMethod guessMethod;

        public RNGuessModel(int low, int high, int maxAttempts, IGuessMethod guessMethod)
        {
            Low = low;
            High = high;

            CurrentLow = low;
            CurrentHigh = high;

            MaxAttempts = maxAttempts;
            CurrentAttempts = startingAttempt;

            this.guessMethod = guessMethod;

            GuessedNumber = guessMethod.GetNextGuess(CurrentLow, CurrentHigh);
        }

        public void SetGuess(GuessResult guessResult)
        {
            switch (guessResult)
            {
                case GuessResult.Equal:
                    CurrentLow = GuessedNumber;
                    CurrentHigh = GuessedNumber;
                    FinalGuessResult = guessResult;
                    return;
                case GuessResult.Less:
                    CurrentHigh = GuessedNumber - 1;
                    break;
                case GuessResult.Greater:
                    CurrentLow = GuessedNumber + 1;
                    break;
            }

            if (CurrentAttempts == MaxAttempts)
            {
                FinalGuessResult = GuessResult.Loss;
                return;
            }

            CurrentAttempts++;

            GuessedNumber = guessMethod.GetNextGuess(CurrentLow, CurrentHigh);
        }

        public void ResetGuess()
        {
            CurrentAttempts = startingAttempt;
            CurrentLow = Low;
            CurrentHigh = High;
            GuessedNumber = guessMethod.GetNextGuess(CurrentLow, CurrentHigh);
        }
    }
}
