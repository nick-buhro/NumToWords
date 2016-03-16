namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Convert numbers to russian words.
    /// </summary>
    public class ToRussianWordsConverter
    {
        private static readonly UnitOfMeasure[] ЕmptyUnitOfMeasures =
        {
            new UnitOfMeasure(Gender.Masculine, null, null, null),
            new UnitOfMeasure(Gender.Feminine, null, null, null),
            new UnitOfMeasure(Gender.Neuter, null, null, null),
        };
        

        public string ToWords(long number, Gender gender)
        {
            return ToWords(number, ЕmptyUnitOfMeasures[(int) gender]);
        }

        public string ToWords(long number, UnitOfMeasure unit)
        {
            return new Algorithm()
                .Convert(number, unit);
        }
    }
}
