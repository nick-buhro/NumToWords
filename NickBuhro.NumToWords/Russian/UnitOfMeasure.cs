namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Represents unit of measure for number formatting.
    /// </summary>
    public sealed class UnitOfMeasure
    {
        /// <summary>
        /// Definition of ruble - domestic currency of Russain Federation.
        /// </summary>
        public static readonly UnitOfMeasure Ruble = new UnitOfMeasure(Gender.Masculine, "рубль", "рубля", "рублей");
        
        /// <summary>
        /// Definition of kopek - cent equivalent for rubles.
        /// </summary>
        public static readonly UnitOfMeasure Kopek = new UnitOfMeasure(Gender.Feminine, "копейка", "копейки", "копеек");


        /// <summary>
        /// Gender of the represented unit of measure.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Unit of measure in form of one piece. For example: "рубль" (один).
        /// </summary>
        public string Form1 { get; }

        /// <summary>
        /// Unit of measure in form of two pieces. For example: "рубля" (два).
        /// </summary>
        public string Form2 { get; }

        /// <summary>
        /// Unit of measure in form of five pieces. For example: "рублей" (пять).
        /// </summary>
        public string Form5 { get; }

        /// <summary>
        /// Create instance of one unit of measure.
        /// </summary>
        /// <param name="gender">Noun gender of unit of measure. For example: <see cref="Gender.Masculine"/></param>
        /// <param name="form1">Name in form of one piece. For example: "рубль".</param>
        /// <param name="form2">Name in form of two pieces. For example: "рубля".</param>
        /// <param name="form5">Name in form of five pieces. For example: "рублей".</param>
        public UnitOfMeasure(Gender gender, string form1, string form2, string form5)
        {
            Gender = gender;
            Form1 = form1;
            Form2 = form2;
            Form5 = form5;
        }
    }
}
