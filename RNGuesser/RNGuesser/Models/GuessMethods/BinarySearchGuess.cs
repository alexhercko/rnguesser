using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models.GuessMethods
{
    public class BinarySearchGuess : IGuessMethod
    {
        public BinarySearchGuess() { }

        public int GetNextGuess(int low, int high)
        {
            return (low + high) / 2;
        }
    }
}
