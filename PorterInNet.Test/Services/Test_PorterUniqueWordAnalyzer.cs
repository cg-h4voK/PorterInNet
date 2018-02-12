using Microsoft.VisualStudio.TestTools.UnitTesting;
using PorterInNet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Test.Services
{
    [TestClass]
    public class Test_PorterUniqueWordAnalyzer
    {
        private PorterUniqueWordAnalyzer subject;

        [TestInitialize]
        public void Init()
        {
            subject = new PorterUniqueWordAnalyzer(new[] { "a", "the", "and", "of", "in", "be", "also", "as" });
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_Empty()
        {
            var result = subject.Analyze(String.Empty);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(0, result.Results.Count());
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_OneWord()
        {
            var result = subject.Analyze("hello");

            Assert.AreEqual(1, result.Results.Count());

            var onlyItem = result.Results.First();

            Assert.AreEqual("hello", onlyItem.Word);
            Assert.AreEqual(1, onlyItem.TotalOccurrences);
            CollectionAssert.AreEquivalent(new[] { 0 }, onlyItem.SentenceIndexes);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueAnalyzer_EndsWithDot()
        {
            var input = "words.";
            var result = subject.Analyze(input);

            Assert.AreEqual(1, result.Results.Count());

            var onlyItem = result.Results.First();

            Assert.AreEqual("word", onlyItem.Word);
            Assert.AreEqual(1, onlyItem.TotalOccurrences);
            CollectionAssert.AreEqual(new[] { 0 }, onlyItem.SentenceIndexes);
        }
        
        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_OneSentence()
        {
            var input = "Take this paragraph of text and return an alphabetized list of ALL unique words.";
            var result = subject.Analyze(input);

            Assert.AreEqual(11, result.Results.Count());

            Assert.AreEqual("all", result.Results.First().Word);
            Assert.AreEqual("word", result.Results.Last().Word);

            Assert.IsTrue(result.Results.All(item => item.TotalOccurrences == 1));
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_ConsidersExceptions()
        {
            var input = "A a IN in AND and OF of BE be ALSO also AS as";
            var result = subject.Analyze(input);

            Assert.AreEqual(0, result.Results.Count());
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_TwoSentences()
        {
            var input = "Take this paragraph of text and return an alphabetized list of ALL unique words.  A unique word is any form of a word often communicated with essentially the same meaning.";
            var result = subject.Analyze(input);

            Assert.AreEqual(20, result.Results.Count());

            var uniqueStem = result.Results.First(x => x.Word == "uniqu");
            Assert.AreEqual(2, uniqueStem.TotalOccurrences);
            CollectionAssert.AreEquivalent(new[] { 0, 1 }, uniqueStem.SentenceIndexes);

            var wordStem = result.Results.First(x => x.Word == "word");
            Assert.AreEqual(3, wordStem.TotalOccurrences);
            CollectionAssert.AreEquivalent(new[] { 0, 1 }, wordStem.SentenceIndexes);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_SentenceWithDoubleQuotesAndRareSpaces()
        {
            var input = "The following words should not be included in your analysis or result set: \"a\", \"the\", \"and\", \"of\", \"in\", \"be\", \"also\" and \"as\".";
            var result = subject.Analyze(input);

            Assert.AreEqual(10, result.Results.Count());

            Assert.IsFalse(result.Results.Any(item => String.IsNullOrWhiteSpace(item.Word)));
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void PorterUniqueWordAnalyzer_FullParagraph()
        {
            var input = "Take this paragraph of text and return an alphabetized list of ALL unique words.  A unique word is any form of a word often communicated with essentially the same meaning. For example, fish and fishes could be defined as a unique word by using their stem fish. For each unique word found in this entire paragraph, determine the how many times the word appears in total. Also, provide an analysis of what unique sentence index position or positions the word is found. The following words should not be included in your analysis or result set: \"a\", \"the\", \"and\", \"of\", \"in\", \"be\", \"also\" and \"as\".  Your final result MUST be displayed in a readable console output in the same format as the JSON sample object shown below.";
            var result = subject.Analyze(input);

            Assert.AreEqual(64, result.Results.Count());

            var wordStem = result.Results.First(item => item.Word == "word");
            Assert.AreEqual(8, wordStem.TotalOccurrences);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5 }, wordStem.SentenceIndexes);
        }
    }
}
