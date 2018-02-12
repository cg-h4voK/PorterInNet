using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PorterInNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Test.Models
{
    [TestClass]
    public class Test_WordAnalysisResult
    {
        private WordAnalysisResult subject;

        [TestInitialize]
        public void Init()
        {
            subject = new WordAnalysisResult();
        }
        
        [TestMethod, TestCategory(Category.Unit)]
        public void WordAnalysisResult_SerializeEmpty()
        {
            var result = JsonConvert.SerializeObject(subject);
            var expected = Shared.BuildExpectedJson();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void WordAnalysisResult_WithALL()
        {
            subject.Word = "ALL";
            subject.LogOccurrence(0);

            var result = JsonConvert.SerializeObject(subject);
            var expected = Shared.BuildExpectedJson("ALL", 1, "[0]");

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void WordAnalysisResult_WithAnalysis()
        {
            subject.Word = "analysis";
            subject.LogOccurrence(4);
            subject.LogOccurrence(5);

            var result = JsonConvert.SerializeObject(subject);
            var expected = Shared.BuildExpectedJson("analysis", 2, "[4,5]");

            Assert.AreEqual(expected, result);
        }
    }
}
