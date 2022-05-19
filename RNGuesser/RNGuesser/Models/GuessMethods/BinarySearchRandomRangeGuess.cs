using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models.GuessMethods
{
    public class BinarySearchRandomRangeGuess : IGuessMethod
    {
        public BinarySearchRandomRangeGuess()
        {
        }

        public int GetNextGuess(int low, int high, int remainingAttempts)
        {
            BinarySearchGuess binarySearchGuess = new BinarySearchGuess();

            int guessable = (int)Math.Pow(2, remainingAttempts) - 1;

            Random random = new Random();

            int newLow = random.Next(low, high - guessable + 1);
            int newHigh = newLow + guessable;

            low = Math.Max(newLow, low);
            high = Math.Min(newHigh, high);

            return binarySearchGuess.GetNextGuess(low, high, remainingAttempts);
        }
    }
}
