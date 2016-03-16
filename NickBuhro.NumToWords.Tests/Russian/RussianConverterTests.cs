using Microsoft.VisualStudio.TestTools.UnitTesting;
using NickBuhro.NumToWords.Russian;

namespace NickBuhro.NumToWords.Tests.Russian
{
    [TestClass]
    public sealed partial class RussianConverterTests
    {
        [TestMethod]
        public void RubleKopekTest()
        {
            var number = 123.45M;
            var expected = "сто двадцать три рубля сорок пять копеек";

            var actual = RussianConverter.FormatCurrency(number);

            Assert.AreEqual(expected, actual);
        }


        #region Helpers

        private void MasculineNumberTestHelper(long number, string expected)
        {
            var actual = RussianConverter.Format(number);
            Assert.AreEqual(expected, actual);
        }

        private void RubleNumberTestHelper(long number, string expected)
        {
            var actual = RussianConverter.Format(number, UnitOfMeasure.Ruble);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
