namespace DuelMastersModels.GameEvents
{
    public class CardPutFromManaZoneIntoGraveyardEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public CardPutFromManaZoneIntoGraveyardEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their mana zone into their graveyard.";
        }
    }
}
