namespace DuelMastersModels.Durations
{
    public class Indefinite : Duration
    {
        public override Duration Copy()
        {
            return new Indefinite();
        }
    }
}
