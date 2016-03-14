using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NickBuhro.NumToWords.Tests
{
    [TestClass]
    public class RussianInWordsFormatterTests
    {
        [TestMethod]
        public void Int32FormatTest()
        {
            var testCases = new []
            {
                new Tuple<int, string>(1, "один"),
                new Tuple<int, string>(0, "ноль"),
                new Tuple<int, string>(-5, "минус пять"),
                new Tuple<int, string>(100, "сто")
            };

            var formatter = new RussianInWordsFormatter();

            foreach (var testCase in testCases)
            {
                var actual = testCase.Item1.ToString(formatter);
                Assert.AreEqual(testCase.Item2, actual);
            }
        }
    }
}
