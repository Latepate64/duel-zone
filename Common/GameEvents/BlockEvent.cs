namespace Common.GameEvents
{
    public class BlockEvent : CardEvent
    {
        public Card BlockedCreature { get; set; }

        public BlockEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} blocked {BlockedCreature}.";
        }
    }
}
