﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models.GuessMethods
{
    public class GuessMethodPicker
    {
        public IGuessMethod GetGuessMethod(GuessMethod guessMethod)
        {
            switch (guessMethod)
            {
                case GuessMethod.BinarySearch:
                    return new BinarySearchGuess();
                case GuessMethod.BinarySearchRandom:
                    return new BinarySearchRandomGuess();
                case GuessMethod.BinarySearchRandomRange:
                    return new BinarySearchRandomRangeGuess();
                case GuessMethod.Random:
                    return new RandomGuess();
                default:
                    return null;
            }
        }
    }
}
