using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Implementation of logic for formatting number to words.
    /// Should be used only once.
    /// </summary>
    internal struct Algorithm
    {
        private const long E3 = 1000L;
        private const long E6 = 1000000L;
        private const long E9 = 1000000000L;
        private const long E12 = 1000000000000L;

        public const long MaxValue = E12 - 1;


        private List<string> _words;
        
        /// <summary>
        /// Format integer number with unit of measure to the correct string on russian language.
        /// </summary>
        /// <example>
        /// For arguments (123, UnitOfMeasure.Ruble) method should return "сто двадцать три рубля".
        /// </example>
        public string Convert(long number, UnitOfMeasure unit)
        {
            // Check for the min value that can't be represented as long positive value
            if (number == long.MinValue)
                throw new ArgumentOutOfRangeException(nameof(number));

            _words = new List<string>();

            // Check for negative number
            if (number < 0)
            {
                //_result.Append(' ');
                _words.Add(Constants.Minus);
                number = -number;
            }
            else if (number == 0)
            {
                _words.Add(Constants.Zero);
            }

            // Numbers more than 999 billions is not supported
            if (number >= E12)
                throw new ArgumentOutOfRangeException(nameof(number));

            // Write billions
            if (number >= E9)
            {
                var value = Math.DivRem(number, E9, out number);
                Append((int)value, Constants.Е9Unit);                
            }

            // Write millions
            if (number >= E6)
            {
                var value = Math.DivRem(number, E6, out number);
                Append((int)value, Constants.Е6Unit);
            }

            // Write thouthands
            if (number >= E3)
            {
                var value = Math.DivRem(number, E3, out number);
                Append((int)value, Constants.Е3Unit);
            }

            // Write hundreds
            if (number > 0)
            {
                Append((int)number, unit);
            }
            else
            {
                var unitForm = unit.GetForm(5);
                if (!string.IsNullOrEmpty(unitForm))
                    _words.Add(unitForm);
            }

            // Finilize result
            return string.Join(" ", _words);
        }

        /// <summary>
        /// Append 3-digit part (with unit of measure) to the result.
        /// </summary>
        /// <param name="value">Number - integer between 1 and 999.</param>
        /// <param name="unit">Unit of measure.</param>
        private void Append(long value, UnitOfMeasure unit)
        {
            Debug.Assert(_words != null);
            Debug.Assert(value > 0);
            Debug.Assert(value < 1000);

            AppendNumber(value, unit.Gender);
            var unitForm = unit.GetForm(value);
            if (!string.IsNullOrEmpty(unitForm))
                _words.Add(unitForm);
        }

        /// <summary>
        /// Append 3-digit part (without unit of measure) to the result.
        /// </summary>
        /// <param name="value">Number - integer between 1 and 999.</param>
        /// <param name="gender">Gender for the correct form of result number.</param>
        private void AppendNumber(long value, Gender gender)
        {
            Debug.Assert(_words != null);
            Debug.Assert(value > 0);
            Debug.Assert(value < 1000);

            // Write hundreds
            if (value >= 100)
            {
                var qty = Math.DivRem(value, 100, out value);                
                _words.Add(Constants.Hundreds[qty]);
            }

            // Write dozens
            if (value >= 20)
            {
                var qty = Math.DivRem(value, 10, out value);
                _words.Add(Constants.Dozens[qty]);
            }
            else if (value >= 10)
            {
                var qty = value - 10;                
                _words.Add(Constants.Tens[qty]);
                return;
            }

            // Write digit
            if (value > 0)
            {
                _words.Add(Constants.Digits[value][(int)gender]);
            }
        }
    }
}
