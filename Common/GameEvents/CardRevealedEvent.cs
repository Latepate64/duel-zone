namespace Common.GameEvents
{
    public class CardRevealedEvent : GameEvent
    {
        public Player Player { get; set; }
        public Card Card { get; set; }

        public CardRevealedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} revealed {Card} to their opponents.";
        }
    }
}
