namespace Common.GameEvents
{
    public class BlockEvent : GameEvent
    {
        public Card Attacker { get; set; }
        public Card Blocker { get; set; }

        public BlockEvent()
        {
        }

        public override string ToString()
        {
            return $"{Blocker} blocked {Attacker}.";
        }
    }
}
