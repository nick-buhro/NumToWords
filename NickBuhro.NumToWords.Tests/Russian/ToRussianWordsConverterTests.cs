using Microsoft.VisualStudio.TestTools.UnitTesting;
using NickBuhro.NumToWords.Russian;

namespace NickBuhro.NumToWords.Tests.Russian
{
    [TestClass]
    public sealed partial class ToRussianWordsConverterTests
    {
        private void MasculineNumberTestHelper(long number, string expected)
        {
            var c = new ToRussianWordsConverter();

            var actual = c.ToWords(number, Gender.Masculine);
            Assert.AreEqual(expected, actual);
        }

        private void RubleNumberTestHelper(long number, string expected)
        {
            var c = new ToRussianWordsConverter();

            var actual = c.ToWords(number, UnitOfMeasure.Ruble);
            Assert.AreEqual(expected, actual);
        }
    }
}
