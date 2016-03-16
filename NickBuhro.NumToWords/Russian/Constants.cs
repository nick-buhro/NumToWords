namespace NickBuhro.NumToWords.Russian
{
    /// <summary>
    /// Constant definitions for the formatting algorithm.
    /// </summary>
    internal static class Constants
    {
        public const string Minus = "минус";
        public const string Zero = "ноль";

        public static readonly string[][] Digits =
        {
            null,   // 0 - not used
            new[] {"один", "одна", "одно"},
            new[] {"два", "две", "два"},
            new[] {"три", "три", "три"},
            new[] {"четыре", "четыре", "четыре"},
            new[] {"пять", "пять", "пять"},
            new[] {"шесть", "шесть", "шесть"},
            new[] {"семь", "семь", "семь"},
            new[] {"восемь", "восемь", "восемь"},
            new[] {"девять", "девять", "девять"},
        };

        public static readonly string[] Tens =
        {
            "десять",
            "одинадцать",
            "двенадцать",
            "тринадцать",
            "четырнадцать",
            "пятнадцать",
            "шестнадцать",
            "семнадцать",
            "восемнадцать",
            "девятнадцать"
        };

        public static readonly string[] Dozens =
        {
            null,   //  0 - not used
            null,   // 10 - not used
            "двадцать",
            "тридцать",
            "сорок",
            "пятьдесят",
            "шестьдесят",
            "семьдесят",
            "восемьдесят",
            "девяносто"
        };

        public static readonly string[] Hundreds =
        {
            null,   // 0 - not used
            "сто",
            "двести",
            "триста",
            "четыреста",
            "пятьсот",
            "шестьсот",
            "семьсот",
            "восемьсот",
            "девятьсот"
        };

        public static readonly UnitOfMeasure Е3Unit = new UnitOfMeasure(Gender.Feminine, "тысяча", "тысячи", "тысяч");
        public static readonly UnitOfMeasure Е6Unit = new UnitOfMeasure(Gender.Masculine, "миллион", "миллиона", "миллионов");
        public static readonly UnitOfMeasure Е9Unit = new UnitOfMeasure(Gender.Masculine, "миллиард", "миллиарда", "миллиардов");
    }
}
