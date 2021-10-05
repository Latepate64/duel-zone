namespace DuelMastersModels.Durations
{
    internal class Indefinite : Duration
    {
        public override Duration Copy()
        {
            return new Indefinite();
        }
    }
}
