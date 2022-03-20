namespace Common.GameEvents
{
    public class BlockEvent : CardEvent
    {
        public ICard BlockedCreature { get; set; }

        public BlockEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} blocked {BlockedCreature}.";
        }
    }
}
