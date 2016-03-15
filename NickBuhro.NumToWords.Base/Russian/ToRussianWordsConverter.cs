using System;
using System.Diagnostics;
using System.Text;

namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Convert numbers to russian words.
    /// </summary>
    public sealed class ToRussianWordsConverter
    {
        public string ToWords(long number, RussianGender gender)
        {
            return ToWords(number, RussianUnitOfMeasure.Еmpty[(int) gender]);
        }

        public string ToWords(long number, RussianUnitOfMeasure unit)
        {
            const string minus = "минус";
            const long e3 = 1000;
            const long e6 = 1000000;
            const long e9 = 1000000000;
            const long e12 = 1000000000000;
            
            // Check for the min value that can't be represented as long positive value
            if (number == long.MinValue)
                throw new ArgumentOutOfRangeException(nameof(number));

            var sb = new StringBuilder();

            // Check for negative number
            if (number < 0)
            {
                number = -number;
                sb.Append(minus);
            }
            
            // Numbers more than 999 billions is not supported
            if (number >= e12)
                throw new ArgumentOutOfRangeException(nameof(number));

            // Write billions
            if (number >= e9)
            {
                var value = number/e9;
                Append(sb, (int)value, RussianUnitOfMeasure.Е9);
                number = number%e9;
            }

            // Write millions
            if (number >= e6)
            {
                var value = number / e6;
                Append(sb, (int)value, RussianUnitOfMeasure.Е6);
                number = number % e6;
            }

            // Write thouthands
            if (number >= e3)
            {
                var value = number / e3;
                Append(sb, (int)value, RussianUnitOfMeasure.Е3);
                number = number % e3;
            }

            // Write hundreds
            Append(sb, (int)number, unit);
            
            return sb.ToString();
        }

        /// <summary>
        /// Append 3-digit part to the StringBuilder.
        /// </summary>
        /// <param name="sb">Target for writing result.</param>
        /// <param name="value">Number - integer between 0 and 999.</param>
        /// <param name="unit">Unit of measure.</param>
        private static void Append(StringBuilder sb, int value, RussianUnitOfMeasure unit)
        {
            Debug.Assert(sb != null);
            Debug.Assert(value >= 0);
            Debug.Assert(value < 1000);


            throw new NotImplementedException();
        }
    }
}
