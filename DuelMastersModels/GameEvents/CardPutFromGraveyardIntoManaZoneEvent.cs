namespace DuelMastersModels.GameEvents
{
    public class CardPutFromGraveyardIntoManaZoneEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardPutFromGraveyardIntoManaZoneEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their graveyard into their mana zone.";
        }
    }
}
