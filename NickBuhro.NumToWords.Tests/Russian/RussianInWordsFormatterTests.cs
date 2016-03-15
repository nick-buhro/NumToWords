using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NickBuhro.NumToWords.Russian;

namespace NickBuhro.NumToWords.Tests.Russian
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

            var converter = new ToRussianWordsConverter();

            foreach (var testCase in testCases)
            {
                var actual = converter.ToWords(testCase.Item1);
                Assert.AreEqual(testCase.Item2, actual, $"Invaid convertation of value {testCase.Item1}.");
            }
        }
    }
}
