namespace NickBuhro.NumToWords.Russian
{
    internal sealed class Constants
    {
        public string Minus;
        public string Zero;
        public string[][] Digits;
        public string[] Tens;
        public string[] Dozens;
        public string[] Hundreds;

        public static readonly Constants Russian;

        static Constants()
        {
            var c = new Constants();
            c.Minus = "минус";
            c.Zero = "ноль";
            c.Digits = new string[10][]
                {
                    null,
                    new[] { "один", "одна", "одно" },
                    new[] { "два", "две", "два" },
                    new[] { "три", "три", "три" },
                    new[] { "четыре", "четыре", "четыре" },
                    new[] { "пять", "пять", "пять" },
                    new[] { "шесть", "шесть", "шесть" },
                    new[] { "семь", "семь", "семь" },
                    new[] { "восемь", "восемь", "восемь" },
                    new[] { "девять", "девять", "девять" },
                };
            c.Tens = new []
            {
                "десять",
                "одиннадцать",
                "двенадцать",
                "тринадцать",
                "четырнадцать",
                "пятнадцать",
                "шеснадцать",
                "семнадцать",
                "восемнадцать",
                "девятнадцать"
            };
            c.Dozens = new []
            {
                null,   
                null,
                "двадцать",
                "тридцать",
                "сорок",
                "пятьдесят",
                "шестьдесят",
                "семьдесят",
                "восемьдесят",
                "девяносто"
            };
            c.Hundreds = new []
            {
                null,
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
            Russian = c;
        }
        
    }
}
