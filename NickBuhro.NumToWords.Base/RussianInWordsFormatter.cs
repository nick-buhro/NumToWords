using System;

namespace NickBuhro.NumToWords
{
    public sealed class RussianInWordsFormatter: InWordsFormatter
    {
        private readonly RussianUnitOfMeasure _integralUnitOfMeasure;
        private readonly RussianUnitOfMeasure _fractionalUnitOfMeasure;
        
        public RussianInWordsFormatter()
            :this(RussianUnitOfMeasure.Ruble, RussianUnitOfMeasure.Kopek) { }

        public RussianInWordsFormatter(
            RussianUnitOfMeasure integralUnitOfMeasure,
            RussianUnitOfMeasure fractionalUnitOfMeasure)
        {
            _integralUnitOfMeasure = integralUnitOfMeasure;
            _fractionalUnitOfMeasure = fractionalUnitOfMeasure;
        }


        protected override string Format(decimal arg, bool currency)
        {
            throw new NotImplementedException();
        }
    }
}
