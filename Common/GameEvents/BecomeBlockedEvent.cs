namespace Common.GameEvents
{
    public class BecomeBlockedEvent : CardEvent
    {
        public ICard Blocker { get; set; }

        public BecomeBlockedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} became blocked by {Blocker}.";
        }
    }
}
