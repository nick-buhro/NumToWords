using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Implementation of logic for formatting number to words.
    /// Should be used only once.
    /// </summary>
    internal struct Algorithm
    {
        private StringBuilder _result;

        /// <summary>
        /// Constants instance. Don't forget to set before invoke Convert method.
        /// </summary>
        public Constants Constants;

        public string Convert(long number, UnitOfMeasure unit)
        {
            const long e3 = 1000;
            const long e6 = 1000000;
            const long e9 = 1000000000;
            const long e12 = 1000000000000;
                                   
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
            if (number >= e12)
                throw new ArgumentOutOfRangeException(nameof(number));

            // Write billions
            if (number >= e9)
            {
                var value = number / e9;
                Append((int)value, UnitOfMeasure.Е9);
                number = number % e9;
            }

            // Write millions
            if (number >= e6)
            {
                var value = number / e6;
                Append((int)value, UnitOfMeasure.Е6);
                number = number % e6;
            }

            // Write thouthands
            if (number >= e3)
            {
                var value = number / e3;
                Append((int)value, UnitOfMeasure.Е3);
                number = number % e3;
            }

            // Write hundreds
            if (number > 0)
            {
                Append((int)number, unit);
            }
            else
            {
                AppendUnitOfMeasure(1, unit);
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
            AppendUnitOfMeasure(value % 10, unit);
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

            if (value >= 100)
            {
                var qty = value / 100;
                value = value % 100;
                _result.Append(' ');
                _result.Append(Constants.Hundreds[qty]);                
            }

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

            if (value > 0)
            {
                _result.Append(' ');
                _result.Append(Constants.Digits[value][(int)gender]);
            }
        }

        private void AppendUnitOfMeasure(int form, UnitOfMeasure unit)
        {
            Debug.Assert(_result != null);
            Debug.Assert(form >= 0);
            Debug.Assert(form < 10);

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
            else
            {
                _result.Append(' ');
                _result.Append(unit.Form5);
            }
        }
    }
}
