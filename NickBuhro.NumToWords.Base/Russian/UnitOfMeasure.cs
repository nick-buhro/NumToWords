namespace NickBuhro.NumToWords.Russian
{
    public sealed class UnitOfMeasure
    {
        public static readonly UnitOfMeasure Ruble = new UnitOfMeasure(Gender.Masculine, "рубль", "рубля", "рублей");
        public static readonly UnitOfMeasure Kopek = new UnitOfMeasure(Gender.Feminine, "копейка", "копейки", "копеек");


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
    }
}
