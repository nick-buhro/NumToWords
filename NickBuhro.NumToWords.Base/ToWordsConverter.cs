using NickBuhro.NumToWords.Russian;

namespace NickBuhro.NumToWords
{
    public abstract class ToWordsConverter
    {
        #region Static definitions

        private static readonly ToRussianWordsConverter _ru = new ToRussianWordsConverter();

        public static ToRussianWordsConverter Russian => _ru;

        #endregion

        public abstract string ToWords(long number);
    }
}
