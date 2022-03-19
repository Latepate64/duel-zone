namespace Common.GameEvents
{
    public class CardRevealedEvent : GameEvent
    {
        public IPlayer Player { get; set; }
        public ICard Card { get; set; }

        public CardRevealedEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} revealed {Card} to their opponents.";
        }
    }
}
