namespace Engine.Durations
{
    public class UntilStartOfYourNextTurn : Duration
    {
        public override IDuration Copy()
        {
            return new UntilStartOfYourNextTurn();
        }

        public override string ToString()
        {
            return "Until the start of your next turn";
        }
    }
}
