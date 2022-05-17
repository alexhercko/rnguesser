using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGuesser.Models
{
    public class RNGuessResultSaving
    {
        public Task SaveResult(RNGuessResultModel rnguessResult) => Task.Run(() =>
        {
            JsonSerializer serializer = new JsonSerializer();

            serializer.Formatting = Formatting.Indented;
            serializer.Converters.Add(new StringEnumConverter());

            List<RNGuessResultModel> results;

            string path = "./json.txt";

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        results = serializer.Deserialize<List<RNGuessResultModel>>(jr);
                    }
                }
            }
            else
            {
                results = new List<RNGuessResultModel>();
            }

            results.Add(rnguessResult);

            using (StreamWriter sw = new StreamWriter(path))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, results);
                }
            }
        });
    }
}
