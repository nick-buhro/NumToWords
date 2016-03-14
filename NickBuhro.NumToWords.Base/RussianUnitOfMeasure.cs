namespace NickBuhro.NumToWords
{
    public struct RussianUnitOfMeasure
    {
        public static readonly RussianUnitOfMeasure Ruble = new RussianUnitOfMeasure("рубль", "рубля", "рублей");
        public static readonly RussianUnitOfMeasure Kopek = new RussianUnitOfMeasure("копейка", "копейки", "копеек");

        public readonly string Single;
        public readonly string Double;
        public readonly string Many;

        /// <param name="single">Unit in single form. For examle: "рубль".</param>
        /// <param name="dbl">Unit in form for 2 pieces. For examle: "рубля".</param>
        /// <param name="many">Unit in form for 5 pieces. For example: "рублей".</param>
        public RussianUnitOfMeasure(string single, string dbl, string many)
        {
            Single = single;
            Double = dbl;
            Many = many;
        }
    }
}
