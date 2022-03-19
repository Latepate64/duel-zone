namespace Engine.Durations
{
    public class UntilTheEndOfTheTurn : Duration
    {
        public override IDuration Copy()
        {
            return new UntilTheEndOfTheTurn();
        }

        public override string ToString()
        {
            return "until the end of the turn";
        }
    }
}
