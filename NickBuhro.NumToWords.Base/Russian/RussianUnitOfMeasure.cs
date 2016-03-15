namespace NickBuhro.NumToWords.Russian
{
    public sealed class RussianUnitOfMeasure
    {
        public RussianGender Gender { get; }
        public string Form1 { get; }
        public string Form2 { get; }
        public string Form5 { get; }

        public RussianUnitOfMeasure(RussianGender gender, string form1, string form2, string form5)
        {
            Gender = gender;
            Form1 = form1;
            Form2 = form2;
            Form5 = form5;
        }


        #region Static definitions

        internal static readonly RussianUnitOfMeasure[] Еmpty =
        {
            new RussianUnitOfMeasure(RussianGender.Masculine, null, null, null),
            new RussianUnitOfMeasure(RussianGender.Feminine, null, null, null),
            new RussianUnitOfMeasure(RussianGender.Neuter, null, null, null),
        };
        
        internal static readonly RussianUnitOfMeasure Е3 = new RussianUnitOfMeasure(RussianGender.Feminine, "тысяча", "тысячи", "тысяч");
        internal static readonly RussianUnitOfMeasure Е6 = new RussianUnitOfMeasure(RussianGender.Masculine, "миллион", "миллиона", "миллионов");
        internal static readonly RussianUnitOfMeasure Е9 = new RussianUnitOfMeasure(RussianGender.Masculine, "миллиард", "миллиарда", "миллиардов");

        public static readonly RussianUnitOfMeasure Ruble = new RussianUnitOfMeasure(RussianGender.Masculine, "рубль", "рубля", "рублей");
        public static readonly RussianUnitOfMeasure Kopek = new RussianUnitOfMeasure(RussianGender.Feminine, "копейка", "копейки", "копеек");

        #endregion
    }
}
