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

        public int GetNextGuess(int low, int high)
        {
            int deviation = (int)((low + high) * deviationRate);

            return Math.Clamp((low + high) / 2 + random.Next(-deviation, deviation + 1), low, high);
        }
    }
}
