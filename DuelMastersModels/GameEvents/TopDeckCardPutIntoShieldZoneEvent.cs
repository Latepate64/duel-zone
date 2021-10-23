namespace DuelMastersModels.GameEvents
{
    public class TopDeckCardPutIntoShieldZoneEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public TopDeckCardPutIntoShieldZoneEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from the top of their deck into their shield zone.";
        }
    }
}
