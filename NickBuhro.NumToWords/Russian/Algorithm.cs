using System;
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


        private StringBuilder _result;
        
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

            _result = new StringBuilder();

            // Check for negative number
            if (number < 0)
            {
                //_result.Append(' ');
                _result.Append(Constants.Minus);
                number = -number;
            }
            else if (number == 0)
            {
                _result.Append(Constants.Zero);
            }

            // Numbers more than 999 billions is not supported
            if (number >= E12)
                throw new ArgumentOutOfRangeException(nameof(number));

            // Write billions
            if (number >= E9)
            {
                var value = number / E9;
                Append((int)value, Constants.Е9Unit);
                number = number % E9;
            }

            // Write millions
            if (number >= E6)
            {
                var value = number / E6;
                Append((int)value, Constants.Е6Unit);
                number = number % E6;
            }

            // Write thouthands
            if (number >= E3)
            {
                var value = number / E3;
                Append((int)value, Constants.Е3Unit);
                number = number % E3;
            }

            // Write hundreds
            if (number > 0)
            {
                Append((int)number, unit);
            }
            else
            {
                AppendUnitOfMeasure(5, unit);
            }

            // Finilize result
            return _result.ToString().Trim();
        }

        /// <summary>
        /// Append 3-digit part (with unit of measure) to the StringBuilder.
        /// </summary>
        /// <param name="value">Number - integer between 1 and 999.</param>
        /// <param name="unit">Unit of measure.</param>
        private void Append(int value, UnitOfMeasure unit)
        {
            Debug.Assert(_result != null);
            Debug.Assert(value > 0);
            Debug.Assert(value < 1000);

            AppendNumber(value, unit.Gender);
            AppendUnitOfMeasure(value % 100, unit);
        }

        /// <summary>
        /// Append 3-digit part (without unit of measure) to the StringBuilder.
        /// </summary>
        /// <param name="value">Number - integer between 1 and 999.</param>
        /// <param name="gender">Gender for the correct form of result number.</param>
        private void AppendNumber(int value, Gender gender)
        {
            Debug.Assert(_result != null);
            Debug.Assert(value > 0);
            Debug.Assert(value < 1000);

            // Write hundreds

            if (value >= 100)
            {
                var qty = value / 100;
                value = value % 100;
                _result.Append(' ');
                _result.Append(Constants.Hundreds[qty]);
            }

            // Write dozens

            if (value >= 20)
            {
                var qty = value / 10;
                value = value % 10;
                _result.Append(' ');
                _result.Append(Constants.Dozens[qty]);
            }
            else if (value >= 10)
            {
                var qty = value - 10;
                _result.Append(' ');
                _result.Append(Constants.Tens[qty]);
                return;
            }

            // Write digit

            if (value > 0)
            {
                _result.Append(' ');
                _result.Append(Constants.Digits[value][(int)gender]);
            }
        }

        /// <summary>
        /// Append unit of measure in the correct form.
        /// </summary>
        /// <param name="form">The last 2 digits of the number. For number 123 it should be 23.</param>
        /// <param name="unit">Unit of measure for writing.</param>
        private void AppendUnitOfMeasure(int form, UnitOfMeasure unit)
        {
            Debug.Assert(_result != null);
            Debug.Assert(form >= 0);
            Debug.Assert(form < 100);

            if (form > 20)
            {
                form = form%10;
            }
            
            if (form >= 5)
            {
                _result.Append(' ');
                _result.Append(unit.Form5);
            }
            else if (form >= 2)
            {
                _result.Append(' ');
                _result.Append(unit.Form2);
            }
            else if (form == 1)
            {
                _result.Append(' ');
                _result.Append(unit.Form1);
            }
            else    // 0 - should use form 5
            {
                _result.Append(' ');
                _result.Append(unit.Form5);
            }
        }
    }
}
