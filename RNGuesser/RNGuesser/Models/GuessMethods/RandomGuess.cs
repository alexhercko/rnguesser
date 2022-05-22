using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models.GuessMethods
{
    public class RandomGuess : IGuessMethod
    {
        Random random;

        public RandomGuess()
        {   
            random = new Random();
        }

        public int GetNextGuess(int low, int high, int remainingAttempts)
        {
            return random.Next(low, high + 1);
        }
    }
}
