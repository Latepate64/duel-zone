namespace DuelMastersModels.Effects.Periods
{
    public class UntilTheEndOfTheTurn : Period
    {
        public override Period Copy()
        {
            return new UntilTheEndOfTheTurn();
        }
    }
}
