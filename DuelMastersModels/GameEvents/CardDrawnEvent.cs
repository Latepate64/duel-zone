namespace DuelMastersModels.GameEvents
{
    public class CardDrawnEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardDrawnEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} drew {Card}.";
        }
    }
}
