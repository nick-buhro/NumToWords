using System;

namespace NickBuhro.NumToWords
{
    /// <summary>
    /// Base class for formatters in different languages.
    /// </summary>
    public abstract class InWordsFormatter: IFormatProvider, ICustomFormatter
    {
        object IFormatProvider.GetFormat(Type formatType)
        {
            return this;

            //if (formatType == typeof (ICustomFormatter))
            //    return this;
            //return null;
        }

        string ICustomFormatter.Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!Equals((formatProvider)))
                return null;
            
            if (string.IsNullOrEmpty(format))
                format = "W";

            switch (format)
            {
                case null:
                case "":
                case "W":
                    return Format(arg, false);
                case "C":
                    return Format(arg, true);
                default:
                    throw new FormatException($"The {format} format specifier is invalid.");
            }
        }

        private string Format(object arg, bool currency)
        {
            decimal value;
            try
            {
                value = Convert.ToDecimal(arg);
            }
            catch (Exception)
            {
                throw new FormatException($"Can't format value {arg}.");
            }

            return Format(value, currency);
        }

        protected abstract string Format(decimal arg, bool currency);
    }
}
