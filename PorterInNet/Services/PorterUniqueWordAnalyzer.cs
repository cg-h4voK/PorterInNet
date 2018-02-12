using PorterInNet.Contracts;
using PorterInNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Services
{
    public class PorterUniqueWordAnalyzer : IUniqueWordAnalyzer
    {
        #region Constructors

        public PorterUniqueWordAnalyzer(string[] wordExceptions)
        {
            WordExceptions = wordExceptions;
        }

        #endregion

        #region Properties

        protected IList<string> WordExceptions { get; set; }

        #endregion

        #region Methods

        public FullAnalysisResult Analyze(string input)
        {
            var result = new FullAnalysisResult();
            var stemmer = new Porter2();

            var wordSplit = input.Split(new[] { ' ', ',', '"', ':' }, StringSplitOptions.RemoveEmptyEntries);
            var sentenceIndex = 0;

            foreach (var word in wordSplit)
            {
                Action nextSentenceIndexIfApplicable = () => { };
                var currentWord = word.ToLowerInvariant();
            
                if (currentWord.EndsWith("."))
                {
                    currentWord = word.Remove(word.Length - 1, 1);
                    nextSentenceIndexIfApplicable = () => { sentenceIndex++; };

                    if (String.IsNullOrWhiteSpace(currentWord))
                    {
                        nextSentenceIndexIfApplicable();
                        continue;
                    }
                }

                if (WordExceptions.Contains(currentWord)) continue;

                var stem = stemmer.Stem(currentWord);
                
                result.LogOccurrence(stem, sentenceIndex);
                nextSentenceIndexIfApplicable();
            }

            return result;
        }

        #endregion
    }
}
