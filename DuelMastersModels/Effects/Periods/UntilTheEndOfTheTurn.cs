namespace DuelMastersModels.Effects.Periods
{
    internal class UntilTheEndOfTheTurn : Period
    {
        public override Period Copy()
        {
            return new UntilTheEndOfTheTurn();
        }
    }
}
