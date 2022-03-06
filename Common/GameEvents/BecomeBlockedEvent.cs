namespace Common.GameEvents
{
    public class BecomeBlockedEvent : CardEvent
    {
        public Card Blocker { get; set; }

        public BecomeBlockedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} became blocked by {Blocker}.";
        }
    }
}
