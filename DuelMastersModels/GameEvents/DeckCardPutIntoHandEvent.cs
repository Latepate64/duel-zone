namespace DuelMastersModels.GameEvents
{
    public class DeckCardPutIntoHandEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public DeckCardPutIntoHandEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their deck into their hand.";
        }
    }
}
