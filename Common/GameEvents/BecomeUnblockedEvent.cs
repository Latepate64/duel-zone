namespace Common.GameEvents
{
    public class BecomeUnblockedEvent : CardEvent
    {

        public BecomeUnblockedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} is not blocked.";
        }
    }
}
