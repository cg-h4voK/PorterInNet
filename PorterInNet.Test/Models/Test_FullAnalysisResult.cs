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
    public class Test_FullAnalysisResult
    {
        private FullAnalysisResult subject;
        private const string jsonFormat = "{{\"results\":[{0}]}}";

        [TestInitialize]
        public void Init()
        {
            subject = new FullAnalysisResult();
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void FullAnalysisResult_Empty()
        {
            var expected = String.Format(jsonFormat, String.Empty);
            var actual = JsonConvert.SerializeObject(subject);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void FullAnalysisResult_WithData()
        {
            subject.LogOccurrence("ALL", 0);

            var item1 = Shared.BuildExpectedJson("ALL", 1, "[0]");
            var expected = String.Format(jsonFormat, item1);
            var actual = JsonConvert.SerializeObject(subject);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void FullAnalysisResult_FullExample()
        {
            subject.LogOccurrence("ALL", 0);
            subject.LogOccurrence("alphabetized", 0);
            subject.LogOccurrence("analysis", 4);
            subject.LogOccurrence("analysis", 5);

            var item1 = Shared.BuildExpectedJson("ALL", 1, "[0]");
            var item2 = Shared.BuildExpectedJson("alphabetized", 1, "[0]");
            var item3 = Shared.BuildExpectedJson("analysis", 2, "[4,5]");

            var joinedItems = String.Join(",", item1, item2, item3);

            var expected = String.Format(jsonFormat, joinedItems);
            var actual = JsonConvert.SerializeObject(subject);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory(Category.Unit)]
        public void FullAnalysisResult_Alphabetized()
        {
            subject.LogOccurrence("zone", 1);
            subject.LogOccurrence("algorythm", 2);
            subject.LogOccurrence("zone", 2);
            subject.LogOccurrence("music", 3);
            subject.LogOccurrence("zone", 4);

            var item1 = Shared.BuildExpectedJson("algorythm", 1, "[2]");
            var item2 = Shared.BuildExpectedJson("music", 1, "[3]");
            var item3 = Shared.BuildExpectedJson("zone", 3, "[1,2,4]");

            var joinedItems = String.Join(",", item1, item2, item3);

            var expected = String.Format(jsonFormat, joinedItems);
            var actual = JsonConvert.SerializeObject(subject);

            Assert.AreEqual(expected, actual);
        }
    }
}
