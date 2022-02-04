namespace Common.GameEvents
{
    public class CreatureSummonedEvent : GameEvent
    {
        public Player Player { get; set; }
        public Card Creature { get; set; }

        public CreatureSummonedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} summoned {Creature}.";
        }
    }
}
