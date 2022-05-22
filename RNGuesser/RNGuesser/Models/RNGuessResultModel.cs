using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RNGuesser.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class RNGuessResultModel
    {
        public int Low { get; set; }
        public int High { get; set; }

        public int FinalLow { get; set; }
        public int FinalHigh { get; set; }

        public int MaxAttempts { get; set; }
        public int FinalAttempts { get; set; }

        public bool ResultGuessed { get; set; }

        public bool UsedCustomGuess { get; set; }
        public bool UsedRandomGuess { get; set; }
    }
}
