namespace Common.GameEvents
{
    public class DeckoutEvent : GameEvent
    {
        public IPlayer Player { get; set; }

        public DeckoutEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player}'s deck contains no cards.";
        }
    }
}
