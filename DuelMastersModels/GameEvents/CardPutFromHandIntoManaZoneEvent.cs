namespace DuelMastersModels.GameEvents
{
    public class CardPutFromHandIntoManaZoneEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardPutFromHandIntoManaZoneEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their hand into their mana zone.";
        }
    }
}
