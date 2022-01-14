namespace DuelMastersModels.GameEvents
{
    public class PermanentReturnedToHandEvent : GameEvent
    {
        public Player Player { get; }
        public Card Permanent { get; }

        public PermanentReturnedToHandEvent(Player player, Card permanent)
        {
            Player = player;
            Permanent = permanent;
        }

        public override string ToString(Duel duel)
        {
            return $"{Player} returned {Permanent} from the battle zone to their hand.";
        }
    }
}
