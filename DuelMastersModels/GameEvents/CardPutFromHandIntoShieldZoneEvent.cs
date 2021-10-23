namespace DuelMastersModels.GameEvents
{
    public class CardPutFromHandIntoShieldZoneEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardPutFromHandIntoShieldZoneEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their hand into their shield zone.";
        }
    }
}
