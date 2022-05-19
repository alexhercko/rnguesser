using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models.GuessMethods
{
    public interface IGuessMethod
    {
        public int GetNextGuess(int low, int high, int remainingAttempts);
    }
}
