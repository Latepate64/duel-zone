namespace DuelMastersModels.GameEvents
{
    public class CardReturnedFromGraveyardToHandEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardReturnedFromGraveyardToHandEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} returned {Card} from their graveyard to their hand.";
        }
    }
}
