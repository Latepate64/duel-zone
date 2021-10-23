namespace DuelMastersModels.GameEvents
{
    public class ShieldPutIntoHandEvent : GameEvent
    {
        public Player Player { get; }
        public Card Card { get; }

        public ShieldPutIntoHandEvent(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} put {Card} from their shield zone to their hand.";
        }
    }
}
