using System;
using System.Diagnostics;

namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Convert numbers to russian words.
    /// </summary>
    public static class RussianConverter
    {
        private static readonly UnitOfMeasure[] ЕmptyUnitOfMeasures =
        {
            new UnitOfMeasure(Gender.Masculine, null, null, null),
            new UnitOfMeasure(Gender.Feminine, null, null, null),
            new UnitOfMeasure(Gender.Neuter, null, null, null),
        };

        /// <summary>
        /// Convert number to words on russian language (without unit of measure).
        /// </summary>
        /// <example>
        /// <code>
        /// var numInWords = RussianConverter.Format(123, Gender.Masculine);
        /// Console.WriteLine(numInWords);  // Print "сто двадцать три"
        /// </code>
        /// </example>
        /// <param name="number">Number to format.</param>
        /// <param name="gender">Gender of unit of measure. Default value is <see cref="Gender.Masculine"></see></param>
        /// <returns>Number in words on russian language.</returns>
        public static string Format(long number, Gender gender = Gender.Masculine)
        {
            Debug.Assert((int)Gender.Masculine == 0);
            Debug.Assert((int)Gender.Feminine == 1);
            Debug.Assert((int)Gender.Neuter == 2);

            return Format(number, ЕmptyUnitOfMeasures[(int) gender]);
        }

        /// <summary>
        /// Convert number to words on russian language (with unit of measure).
        /// </summary>
        /// <example>
        /// <code>
        /// var numInWords = RussianConverter.Format(123, UnitOfMeasure.Ruble);
        /// Console.WriteLine(numInWords);  // Print "сто двадцать три рубля"
        /// </code>
        /// </example>
        /// <param name="number">Number to format.</param>
        /// <param name="unit">Unit of measure.</param>
        /// <returns>Number in words on russian language with unit of measure.</returns>
        public static string Format(long number, UnitOfMeasure unit)
        {
            return new Algorithm()
                .Convert(number, unit);
        }

        /// <summary>
        /// Convert decimal number to words in russian language (with currency).
        /// </summary>
        /// <param name="number">Number to format. Can contain decimal digits (max count is specified in decimalDigitCount argument).</param>
        /// <param name="integerUnit">Currency name for integer part. Default value is <see cref="UnitOfMeasure.Ruble"/>.</param>
        /// <param name="decimalUnit">Currency name for integer part. Default value is <see cref="UnitOfMeasure.Kopek"/>.</param>
        /// <param name="decimalDigitCount">Count of decimal digits. For RUB and USD should be 2.</param>
        /// <returns>Currency amount in words on russian language.</returns>
        public static string FormatCurrency(
            decimal number, 
            UnitOfMeasure integerUnit = null,
            UnitOfMeasure decimalUnit = null, 
            int decimalDigitCount = 2)
        {
            // Check arguments

            if ((decimalDigitCount < 0) || (decimalDigitCount > 6))
                throw new ArgumentOutOfRangeException(
                    nameof(decimalDigitCount),
                    $"Value {decimalDigitCount} is invalid. Supported only values between 0 and 6.");

            if ((number > Algorithm.MaxValue) || (number < -Algorithm.MaxValue))
                throw new ArgumentOutOfRangeException(
                    nameof(number),
                    $"Value {number} is invalid. Supported only values between -{Algorithm.MaxValue} and {Algorithm.MaxValue}.");
            
            // Find number parts - integer and decimal

            var integerPart = Math.Round(number, 0);

            number = number - integerPart;
            for (var i = 0; i < decimalDigitCount; i++)
            {
                number *= 10;
            }

            var decimalPart = Math.Round(number, 0);
            if (number != decimalPart)
                throw new FormatException($"Lack of precision: number should have only {decimalDigitCount} decimal digits.");

            // Set default values

            if (integerUnit == null) integerUnit = UnitOfMeasure.Ruble;
            if (decimalUnit == null) decimalUnit = UnitOfMeasure.Kopek;

            // Format and return

            return string.Concat(
                Format((long) integerPart, integerUnit),
                " ",
                Format((long) decimalPart, decimalUnit));
        }
    }
}
