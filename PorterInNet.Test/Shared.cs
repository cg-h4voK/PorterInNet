using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Test
{
    public static class Shared
    {
        public static string BuildExpectedJson(string word = null, int occurreces = 0, string sentenceIndexes = "[]")
        {
            word = word == null ? "null" : String.Format("\"{0}\"", word);

            var format = @"{{""word"":{0},""total-occurrences"":{1},""sentence-indexes"":{2}}}";
            var result = String.Format(format, word, occurreces, sentenceIndexes);

            return result;
        }
    }
}
