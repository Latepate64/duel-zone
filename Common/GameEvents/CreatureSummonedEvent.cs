namespace Common.GameEvents
{
    public class CreatureSummonedEvent : GameEvent
    {
        public IPlayer Player { get; set; }
        public ICard Creature { get; set; }

        public CreatureSummonedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} summoned {Creature}.";
        }
    }
}
