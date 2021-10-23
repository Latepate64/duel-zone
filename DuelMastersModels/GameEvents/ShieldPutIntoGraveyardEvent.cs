namespace DuelMastersModels.GameEvents
{
    public class ShieldPutIntoGraveyardEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public ShieldPutIntoGraveyardEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their shield zone into their graveyard.";
        }
    }
}
