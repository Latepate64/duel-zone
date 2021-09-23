namespace DuelMastersModels.Effects.Periods
{
    internal class Indefinite : Period
    {
        public override Period Copy()
        {
            return new Indefinite();
        }
    }
}
