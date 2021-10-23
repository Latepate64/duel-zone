namespace DuelMastersModels.GameEvents
{
    public class DiscardEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public DiscardEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} discarded {Card}.";
        }
    }
}
