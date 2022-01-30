namespace Engine.Durations
{
    public class UntilTheEndOfTheTurn : Duration
    {
        public override Duration Copy()
        {
            return new UntilTheEndOfTheTurn();
        }
    }
}
