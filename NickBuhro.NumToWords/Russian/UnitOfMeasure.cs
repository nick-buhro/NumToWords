using System;

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

        /// <summary>
        /// Get correct unit of measure form for the specified number. Result DOES NOT include the number specified.
        /// </summary>        
        /// <param name="number">Number to determine correct unit of measure form.</param>
        /// <example>
        /// `UnitOfMeasure.Ruble.GetForm(123)` call should return "рубля".
        /// </example>
        public string GetForm(long number)
        {
            if (number < 0)
                number = Math.Abs(number);
            
            if (number >= 100)
                number %= 100;

            if (number > 20)
                number %= 10;

            if (number >= 5)
                return Form5;

            if (number >= 2)
                return Form2;

            if (number == 1)
                return Form1;
                        
            return Form5;   // 0 - should use form 5
        }
    }
}
