namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Convert numbers to russian words.
    /// </summary>
    public sealed class ToRussianWordsConverter
    {
        public string ToWords(long number, Gender gender)
        {
            return ToWords(number, UnitOfMeasure.Еmpty[(int) gender]);
        }

        public string ToWords(long number, UnitOfMeasure unit)
        {
            var alg = new Algorithm();
            alg.Constants = Constants.Russian;
            return alg.Convert(number, unit);
        }
    }
}
