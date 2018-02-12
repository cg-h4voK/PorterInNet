using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Models
{
    public class FullAnalysisResult
    {
        public FullAnalysisResult()
        {
            results = new SortedDictionary<string, WordAnalysisResult>();
        }

        private IDictionary<string, WordAnalysisResult> results;

        [JsonProperty(PropertyName = "results")]
        public IEnumerable<WordAnalysisResult> Results
        {
            get { return results.Values.ToArray(); }
        }

        public void LogOccurrence(string wordStem, int sentenceIndex)
        {
            WordAnalysisResult item;

            if (!results.ContainsKey(wordStem))
            {
                item = new WordAnalysisResult { Word = wordStem };

                results.Add(item.Word, item);
            }
            else
            {
                item = results[wordStem];
            }

            item.LogOccurrence(sentenceIndex);
        }
    }
}
