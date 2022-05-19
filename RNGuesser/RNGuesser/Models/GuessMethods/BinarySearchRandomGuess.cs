using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models.GuessMethods
{
    public class BinarySearchRandomGuess : IGuessMethod
    {
        private readonly Random random;

        private const float deviationRate = 0.05f;

        public BinarySearchRandomGuess()
        {
            random = new Random();
        }

        public int GetNextGuess(int low, int high, int remainingAttempts)
        {
            int deviation = (int)((low + high) * deviationRate);
            BinarySearchGuess binarySearchGuess = new BinarySearchGuess();

            int nextGuess = binarySearchGuess.GetNextGuess(low, high, remainingAttempts);

            int guessable = (int)Math.Pow(2, remainingAttempts) - 1;

            int guessableLow = Math.Min(low + guessable, nextGuess);
            int guessableHigh = Math.Max(high - guessable, nextGuess);

            return Math.Clamp(nextGuess + random.Next(-deviation, deviation + 1), guessableLow, guessableHigh);
        }
    }
}
