using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PorterInNet.Test
{
    [TestClass]
    public class Test_Porter2
    {
        private Porter2 subject;

        [TestInitialize]
        public void Init()
        {
            subject = new Porter2();
        }

        private void AssertWord(string testWord, string expectedResult)
        {
            var result = subject.Stem(testWord);

            Assert.AreEqual(expectedResult, result, "Test: '{0}'. Expected '{1}' but got '{2}' .", testWord, expectedResult, result);
        }

        [TestMethod, TestCategory(Category.Unit), TestCategory(Category.External)]
        public void Porter2_SimpleWord()
        {
            AssertWord("word", "word");
        }

        [TestMethod, TestCategory(Category.Unit), TestCategory(Category.External)]
        public void Porter2_ExamWords()
        {
            AssertWord("all", "all");
            AssertWord("alphabetized", "alphabet");
            AssertWord("analysis", "analysi");
        }

        [TestMethod, TestCategory(Category.Unit), TestCategory(Category.External)]
        public void Porter2_OtherExamWords()
        {
            AssertWord("fish", "fish");
            AssertWord("fishes", "fish");
        }

        [TestMethod, TestCategory(Category.Unit), TestCategory(Category.External)]
        public void Porter2_You()
        {
            AssertWord("you", "you");
            AssertWord("your", "your");
        }

        [TestMethod, TestCategory(Category.Unit), TestCategory(Category.External)]
        public void Porter2_Format()
        {
            AssertWord("format", "format");
            AssertWord("formatting", "format");
            AssertWord("formatted", "format");
        }

        [TestMethod, TestCategory(Category.Unit), TestCategory(Category.External)]
        public void Porter2_WordAndWords()
        {
            AssertWord("word", "word");
            AssertWord("words", "word");
        }
    }
}
