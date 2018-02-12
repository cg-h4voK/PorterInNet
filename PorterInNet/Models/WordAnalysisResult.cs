using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Models
{
    public class WordAnalysisResult
    {
        #region Constructors

        public WordAnalysisResult()
        {
            sentenceIndexes = new List<int>();
        }

        #endregion

        #region Properties

        private IList<int> sentenceIndexes;

        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }

        [JsonProperty(PropertyName = "total-occurrences")]
        public int TotalOccurrences { get; set; }

        [JsonProperty(PropertyName = "sentence-indexes")]
        public int[] SentenceIndexes { get { return sentenceIndexes.ToArray(); } }

        #endregion

        #region Methods

        public void LogOccurrence(int index)
        {
            TotalOccurrences++;

            if (sentenceIndexes.Contains(index)) return;
            sentenceIndexes.Add(index);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} times at [{2}]", Word, TotalOccurrences, String.Join(",", SentenceIndexes));
        }

        #endregion
    }
}
