namespace NickBuhro.NumToWords.Russian
{
    public sealed class UnitOfMeasure
    {
        public Gender Gender { get; }
        public string Form1 { get; }
        public string Form2 { get; }
        public string Form5 { get; }

        public UnitOfMeasure(Gender gender, string form1, string form2, string form5)
        {
            Gender = gender;
            Form1 = form1;
            Form2 = form2;
            Form5 = form5;
        }


        #region Static definitions

        internal static readonly UnitOfMeasure[] Еmpty =
        {
            new UnitOfMeasure(Gender.Masculine, null, null, null),
            new UnitOfMeasure(Gender.Feminine, null, null, null),
            new UnitOfMeasure(Gender.Neuter, null, null, null),
        };
        
        internal static readonly UnitOfMeasure Е3 = new UnitOfMeasure(Gender.Feminine, "тысяча", "тысячи", "тысяч");
        internal static readonly UnitOfMeasure Е6 = new UnitOfMeasure(Gender.Masculine, "миллион", "миллиона", "миллионов");
        internal static readonly UnitOfMeasure Е9 = new UnitOfMeasure(Gender.Masculine, "миллиард", "миллиарда", "миллиардов");

        public static readonly UnitOfMeasure Ruble = new UnitOfMeasure(Gender.Masculine, "рубль", "рубля", "рублей");
        public static readonly UnitOfMeasure Kopek = new UnitOfMeasure(Gender.Feminine, "копейка", "копейки", "копеек");

        #endregion
    }
}
